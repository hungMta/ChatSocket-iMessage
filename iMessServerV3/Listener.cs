using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace iMessServerV3
{
    class Listener
    {
        private Socket socketServer;
        
        public bool Listening { get; set; }
        public int Port { get; set; }

        public Listener(int port)
        {
            this.Port = port;
            socketServer = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);
        }

        public void Start()
        {
            if (Listening) return;
            socketServer.Bind(new IPEndPoint(0,Port));
            socketServer.Listen(0);
            socketServer.BeginAccept(Callback,null);
            Listening = true;
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;

        private void Callback(IAsyncResult ar)
        {
            try
            {
                var s = socketServer.EndAccept(ar);
                if (SocketAccepted != null) SocketAccepted(s);
                {
                    socketServer.BeginAccept(Callback,null);
                }
            }

            catch (Exeption ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Stop()
        {
            if (!Listening) return;
            if (socketServer.Connected)
            {
                socketServer.Shutdown(SocketShutdown.Both);
            }
            socketServer.Close();
            socketServer = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);
            
        }

    }
}
