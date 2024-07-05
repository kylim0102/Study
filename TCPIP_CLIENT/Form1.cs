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

namespace TCPIP_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpClient client;

        private void button2_Click(object sender, EventArgs e)
        {
            NetworkStream stream = client.GetStream();

            string text = textBox1.Text;
            var messageBuffer = Encoding.UTF8.GetBytes(text);
            stream.Write(messageBuffer, 0, messageBuffer.Length);

            listBox1.Items.Add("Me: "+text);
        }

        private async Task HandelClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            int read;
            while((read = await stream.ReadAsync(buffer , 0 , buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, read);
                listBox1.Items.Add("Server: "+message);
                MessageBox.Show(message,"Server",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new TcpClient();
            //await client.ConnectAsync(IPAddress.Parse("192.168.78.234"), 8090);
            await client.ConnectAsync(IPAddress.Parse("192.168.52.11"), 8090);
            _ = HandelClient(client);
           // _ = ReceiveMessage();
        }


        private async Task ReceiveMessage()
        {

            TcpClient client = new TcpClient();
            await client.ConnectAsync("192.168.78.234",8090);

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int read;

            while((read = await stream.ReadAsync(buffer ,0 , buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, read);
                MessageBox.Show(message,"Server",MessageBoxButtons.OK,MessageBoxIcon.Information);

                listBox1.Items.Add("Server: "+message);
            }
        }
    }
}
