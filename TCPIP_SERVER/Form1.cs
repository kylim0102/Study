using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPIP_SERVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener listener;
        private readonly BindingList<TcpClient> clients = new BindingList<TcpClient>();

        // 클라이언트로부터 메시지 수신 후 ListBox에 내용 추가
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int read;

            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, read);
                MessageBox.Show(message,"Client",MessageBoxButtons.OK,MessageBoxIcon.Information);

                listBox1.Items.Add("Client: "+message);
                //var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                //tream.Write(messageBuffer, 0, messageBuffer.Length);
            }

        }

        private async Task SendMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int read;

            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                //string message = Encoding.UTF8.GetString(buffer, 0, read);
                //MessageBox.Show(message, "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);


                var messageBuffer = Encoding.UTF8.GetBytes(textBox1.Text);
                stream.Write(messageBuffer, 0, messageBuffer.Length);
                listBox1.Items.Add("Me: : " + messageBuffer);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Parse("192.168.52.11"), 8090);
            
            listener.Start();

            while (true)
            {
                TcpClient newclient = await listener.AcceptTcpClientAsync();
                clients.Add(newclient);
                _ = HandleClient(newclient);



            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            // 클라이언트에게 메시지 전송
            //TcpClient client = await listener.AcceptTcpClientAsync();
            string message = textBox1.Text;
            foreach (TcpClient client in clients)
            { 
                NetworkStream stream = client.GetStream();
            

            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(messageBuffer,0,messageBuffer.Length);
            

            }
            listBox1.Items.Add("Me: " + message);
        }
    }
}
