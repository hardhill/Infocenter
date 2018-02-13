using ChatServ.Models;
using MongoDB.Driver;
using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChatServ
{
    public partial class frmMain : Form
    {
        private MyServer myServer;

        private DbChat dbChat;
        public frmMain()
        {
            InitializeComponent();
           
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            string port = ConfigurationManager.ConnectionStrings["Port"].ConnectionString;
            string host = ConfigurationManager.ConnectionStrings["Host"].ConnectionString;
            Memo1.Clear();
            dbChat = new DbChat("MongoDb");
            myServer = new MyServer(host, Convert.ToInt32(port));
            myServer.OnErrorSetupInit += MyServer_OnErrorSetupInit;
            myServer.OnStartServer += MyServer_OnStartServer;
            myServer.OnErrorStartServer += MyServer_OnErrorStartServer;
            myServer.OnStopServer += MyServer_OnStopServer;
            myServer.OnNewSessionConnected += MyServer_OnNewSessionConnected;
            myServer.OnSessionClose += MyServer_OnSessionClose;
            myServer.Setup();
           
        }

        private void MyServer_OnSessionClose(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Memo1.BeginInvoke((MethodInvoker)(delegate {
                Memo1.AppendText("Disconnect["+value.ToString()+"]:\t" + session.SessionID + "\r\n");
            }));
        }

        //новый клиент подсоединился (новая сессия)
        private void MyServer_OnNewSessionConnected(WebSocketSession session)
        {
            Memo1.BeginInvoke((MethodInvoker)(delegate{
                Memo1.AppendText("Connect:\t\t\t" + session.SessionID + "\r\n");
            }));
            
        }

        
        private void MyServer_OnStopServer(DateTime dt)
        {
            Memo1.AppendText(dt.ToString("yyyy-MM-dd HH:mm:ss.fff\t") + "Server stoped\r\n");
        }

        private void MyServer_OnErrorStartServer(string error)
        {
            Memo1.AppendText(error + "\r\n");
        }

        private void MyServer_OnStartServer(DateTime dt)
        {
            Memo1.AppendText(dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\tserver started!\r\n");
        }

        private void MyServer_OnErrorSetupInit(string error)
        {
            MessageBox.Show(error);
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            myServer.Start();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            myServer.Stop();
        }

        
    }
}
