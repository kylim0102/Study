using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener listener;
        private TcpClient client;
        private async void button1_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Parse("192.168.52.11"), 8090);
            listener.Start();

            while (true)
            {
                TcpClient Client = await listener.AcceptTcpClientAsync();

                _ = HandleClient(Client);


            }
        }
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] Sizebuffer = new byte[4];
            int read;


            while (true)
            {
                read = await stream.ReadAsync(Sizebuffer, 0, Sizebuffer.Length);
                if (read == 0)
                    break;

                int size = BitConverter.ToInt32(Sizebuffer);
                byte[] buffer = new byte[size];
                read = await stream.ReadAsync(buffer, 0, buffer.Length);

                if (read == 0)
                    break;

                string message = Encoding.UTF8.GetString(buffer, 0, read);

                listBox1.Items.Add(message);

                var messageBuffer = Encoding.UTF8.GetBytes($"서버에서 다시 보냅니다. : {message}");
                stream.Write(messageBuffer);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
