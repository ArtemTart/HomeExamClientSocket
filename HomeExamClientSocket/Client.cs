using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeExamClientSocket
{
    public class Client
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;
        string folderOnServer;
        string clearPath;
        public Client()
        {
            mClient = null;
            mServerPort = -1;
            mServerIPAddress = null;
        }
        public IPAddress ServerIPAddress => mServerIPAddress;
        public int ServerPort => mServerPort;
        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;

            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {
                Debug.WriteLine("Invalid server IP supplied.");
                return false;
            }

            mServerIPAddress = ipaddr;

            return true;
        }

        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Debug.WriteLine("Invalid port number supplied, return.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Debug.WriteLine("Port number must be between 0 and 65535.");
                return false;
            }

            mServerPort = portNumber;

            return true;
        }

        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                }
            }
        }

        public async Task SendToServer(string strInputUser)
        {
            if (string.IsNullOrEmpty(strInputUser))
            {
                Debug.WriteLine("Empty string supplied to send.");
                return;
            }

            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;

                    await clientStreamWriter.WriteAsync(strInputUser);
                    Debug.WriteLine($"Data sent... {strInputUser}");
                }
            }
        }
        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }
            try
            {
                await mClient.ConnectAsync(mServerIPAddress, mServerPort);
                Debug.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}",
                mServerIPAddress, mServerPort));
                ReadDataAsync(mClient);
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                throw;
            }
        }
        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[512];
                int readByteCount = 0;
                Array.Clear(buff, 0, buff.Length);
                while (true)
                {
                   
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);// the command that awaits to recieve messages from client 
                    if (readByteCount <= 0)
                    {
                        Array.Clear(buff, 0, buff.Length);
                        Debug.WriteLine("Disconnected from server.");
                        mClient.Close();
                        break;
                    }
                  
                    string messageRecieved = new string(buff);

                    if (messageRecieved.Contains("path*"))
                    {
                        checkeIfStringPath(messageRecieved);
                        
                    }
                    if (messageRecieved.Contains("send file path to download"))
                    {
                        recieveData();
                    }
                    
                    Debug.WriteLine(string.Format("Received bytes: {0} - Message: {1}", readByteCount, new string(buff)));
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                throw;
            }

        }

        private void recieveData()
        {
            NetworkStream serverStream = mClient.GetStream();
            StreamReader reader = new StreamReader(serverStream);
            StreamWriter writer = new StreamWriter(serverStream);
            writer.AutoFlush = true;
            writer.WriteLine(@"C:\Logs\ttt.rar"); // need to fatch the filename i want to download

            string name = "c:\\ftpService\\";  // location here to download
            string temp = null;
            //reading the message from server that file found or filename


            string name1 = reader.ReadLine(); //                          the program chrashed here probably with the file name;
            if (name1 == "File not found")
            {
                writer.Close();
                reader.Close();
                return;
            }
            //logic of extracting file name from the given path
            for (int i = name1.Length; i >= 1; i--)
            {
                char c = name1[i - 1];
                if (c == '/') break;
                temp += c;
            }
            //setting the path for opening file at the client side like "c:\ftpService\xyz.cs"
            for (int i = temp.Length; i >= 1; i--)
            {
                char c = temp[i - 1];
                name += c;
            }

            Stream destinationfilestream;
            try
            {
                destinationfilestream = File.OpenWrite(name);
            }
            catch
            {
                writer.WriteLine("File not found");
                serverStream.Close();
                return;
            }
            const int buffsize = 1024;
            try
            {
                BufferedStream bufferedinput = new BufferedStream(serverStream);

                BufferedStream bufferedoutput = new BufferedStream(destinationfilestream);
                int bytesread;
                
                byte[] buffer = new Byte[buffsize];

                while ((bytesread = bufferedinput.Read(buffer, 0, buffsize)) > 0)
                {
                    bufferedoutput.Write(buffer, 0, bytesread);
                }
                bufferedoutput.Flush();

                bufferedinput.Close();
                bufferedoutput.Close();

            }
            catch (Exception)
            {
                writer.Close();
                reader.Close();
            }
            reader.Close();
            writer.Close();

        }
    

        public void checkeIfStringPath(string path)
        {
           clearPath=path.Substring(5, 7); // cut the path for the folder on the server 
        }

    }
}

