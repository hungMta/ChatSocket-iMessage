using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace iMessV2
{
    public partial class iMess : Form
    {
        private Socket socketClient;
        private Thread threadClient;
        private IPEndPoint ipEndPoint;

        public iMess()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            initConnect();
        }

        private void initConnect()
        {
            threadClient = new Thread(ConnectToServer);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        private void ConnectToServer()
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),2017);
            socketClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);
            socketClient.Connect(ipEndPoint);
            Thread lisent = new Thread(LisentServer);
            lisent.IsBackground = true;
            lisent.Start();
        }

        private void LisentServer(Object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                try
                { 
                byte[] buff = new byte[1024];
                int recevie = socket.Receive(buff);

                rtbChatLog.AppendText("Server : " + socket.RemoteEndPoint.ToString());
                rtbChatLog.ScrollToCaret();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string mess = rtbMessage.Text;
            byte[] buff = new byte[1024];
            buff = Encoding.ASCII.GetBytes(mess);
            socketClient.Send(buff);
        }
    }
}
