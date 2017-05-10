using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMessServerV3
{
    public partial class Main : Form
    {
        private readonly Listener listener;

        public List<Socket> listClients = new List<Socket>();

        public Main()
        {
            InitializeComponent();
            listener = new Listener(2014);
            listener.SocketAccepted += listener_SocketAccepted;
        }

        private void listener_SocketAccepted(Socket e)
        {
            var client = new Client(e);
            client.Received += client_Received;
            client.Disconnected += client_Disconnected;
            this.Invoke(() =>
               {
                   string ip = client.Ip.ToString().Split(':')[0];
                   var item = new ListViewItem(ip);
                   item.SubItems.Add(" "); // name
                   item.SubItems.Add(" "); // status
                   item.Tag = client;
                   clientList.Items.Add(item);
                   listClients.Add(e);
               }
             );
        }

        private void client_Disconnected(Client sender)
        {
            this.Invoke(() =>
            {
                for(int i = 0; i < clientList.Items.Count; i++)
                {
                    var client = clientList.Items[i].Tag as Client;
                    if (client.Ip == sender.Ip)
                    {
                        txtReceive.Text += "<< " + clientList.Items[i].SubItems[1].Text + " has disconnect >>\r\n";
                        BroadcastData("RefreshChat|" + txtReceive.Text);
                        clientList.Items.RemoveAt(i);
                    }
                }
            }
            );
        }

        private void BroadcastData(string data)
        {
            foreach (var socket in listClients)
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(data));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private  void client_Received(Client sender , byte[] data)
        {
            this.Invoke(() =>
            {
                for (int i = 0;  i < clientList.Items.Count; i++)
                {
                    var client = clientList.Items[i].Tag as Client;
                    if (client == null || client.Ip != sender.Ip) continue;
                    var command = Encoding.ASCII.GetString(data).Split('|');
                    switch (command[0])
                    {
                        case "Connect":
                            txtReceive.Text += "<< " + command[1] + " joined the room >>\r\n";
                            clientList.Items[i].SubItems[1].Text = command[1]; // nickname
                            clientList.Items[i].SubItems[2].Text = command[2]; // status
                            string users = string.Empty;
                            for (int j = 0; j < clientList.Items.Count; j++)
                            {
                                users += clientList.Items[j].SubItems[1].Text + "|";
                            }
                            BroadcastData("Users|" + users.TrimEnd('|'));
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            break;
                        case "Message":
                            txtReceive.Text += command[1] + " says: " + command[2] + "\r\n";
                            BroadcastData("RefreshChat|" + txtReceive.Text);
                            break;

                        //case "pMessage":
                        //    this.Invoke(() =>
                        //    {
                        //        pChat.txtReceive.Text += command[1] + " says: " + command[2] + "\r\n";
                        //    });
                        //    break;

                        //case "pChat":

                        //    break;
                    }
                }
            }
            );
        }

        private void Main_Load(object sender, EventArgs e)
        {
            listener.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            listener.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                BroadcastData("Message|" + txtInput.Text);
                txtReceive.Text += txtInput.Text + "\r\n";
                txtInput.Text = "Admin says: ";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in clientList.SelectedItems select (Client)item.Tag)
            {
                client.Send("Disconnect|");
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }
    }
}
