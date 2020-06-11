using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeExamClientSocket
{
    public partial class Form1 : Form
    {
        Client client;
        public string fileNameToSend;
           public Form1()
        {
            InitializeComponent();
             client = new Client();
        }
        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            client.SetServerIPAddress(serverIptxt.Text);
            client.SetPortNumber(serverPortTxt.Text);
            client.ConnectToServer();
        }

        private void sendToServerBtn_Click(object sender, EventArgs e)
        {
            client.SendToServer(textToSend.Text);
            
        }

        
    }
}
