using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMessServerV3
{
    class Client
    {
        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);
        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;

        public IPEndPoint Ip { get; set; }

        public Socket socketClient;

        public Client(Socket accepted)
        {
            socketClient = accepted;
            Ip = (IPEndPoint)socketClient.RemoteEndPoint;
            socketClient.BeginReceive(new byte[] { 0 }, 0, 0, 0, new AsyncCallback(Callback), null);
        }

        public void Callback(IAsyncResult ar)
        {
            try
            {
                socketClient.EndReceive(ar);
                var buffer = new byte[socketClient.ReceiveBufferSize];
                var rec = socketClient.Receive(buffer, buffer.Length, 0);
                if (rec < buffer.Length)
                {
                    Array.Resize(ref buffer , rec);
                }
                if(Received != null)
                {
                    Received(this,buffer);
                }
                socketClient.BeginReceive(new byte[] { 0 }, 0, 0, 0, new AsyncCallback(Callback), null);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lose Connect","Warring",MessageBoxButtons.OK);
                Console.WriteLine(e.Message);
            }
        }

        public void Send(string data)
        {
            var buffer = Encoding.ASCII.GetBytes(data);
            socketClient.BeginSend(buffer,0,buffer.Length, SocketFlags.None,ar => socketClient.EndSend(ar),buffer);
        }
        public void Close()
        {
            socketClient.Dispose();
            socketClient.Close();
        }
    }
}
