using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ServerMess
{
    public partial class ServerMess : Form
    {
        Socket server;
        IPEndPoint ipe; // gom dia chia ip cua server va port
        List<Socket> listSocketClient = new List<Socket>();
        IPAddress myIp;
        Thread serverThread;
        public ServerMess()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            AsynchronousSocketListener asyn = new AsynchronousSocketListener();
            asyn.StartListening();
        }

        public IPAddress getIp()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName()); // lay duoc tat ca cac Ip cua may ra
            foreach (IPAddress ip in hostEntry.AddressList)
            {
                if(ip.AddressFamily.ToString() == "InterNetWork")
                {
                    return ip;
                }
            }
            return null;
        }

        public void initServer()
        {
            myIp = getIp();
            ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2017);
            server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);
        }

        public void initThreadServer()
        {
            serverThread = new Thread(ListenClient);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        public void ListenClient()
        {
            server.Bind(ipe); // bat dau lang nghe
            server.Listen(0); // tối đa kết nối 3 client cùng 1 lúc
            while (true) // khi co ket noi
            {
                Socket socketClient = server.Accept();
                listSocketClient.Add(socketClient);
                rtbContext.AppendText("Conected from : " + socketClient.RemoteEndPoint.ToString());
                rtbContext.ScrollToCaret();

                server.BeginAccept(new AsyncCallback(AcceptCallBack),server);

                Thread clientSessionThread = new Thread(ClientSession);
                clientSessionThread.IsBackground = true;
                clientSessionThread.Start(socketClient);
                
            }

        }
        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);


        }



        public void ClientSession(object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                byte[] buff = new byte[1024];
                int recevie = socket.Receive(buff);   // nhan du lieu tu client
                //rtbContext.AppendText("Client : " + System.Text.Encoding.Default.GetString(recevie));
                rtbContext.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            initServer();
            initThreadServer();
            rtbContext.AppendText("Started Server");
            rtbContext.ScrollToCaret();
        }

        private void btnSendBC_Click(object sender, EventArgs e)
        {
            string mess = rtbSendBroadCast.Text;
            byte[] buff = new byte[1024];
            buff = Encoding.ASCII.GetBytes(mess);
            foreach(Socket clientSK in listSocketClient)
            {
                clientSK.Send(buff,buff.Length,SocketFlags.None);
            }
        }
    }
}
