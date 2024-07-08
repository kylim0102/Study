using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Azure 스토리지에서 다운로드하고자 하는 파일명
            string blobName = download.Text;
            // Azure 스토리지로부터 다운로드할 파일을 저장할 경로 + 파일명
            // ex) D://test/images/dog.jpg
            string downloadFilePath = @"C:\Users\YJ\Desktop\image\" + download.Text;

            await DownloadFileAsync(blobName, downloadFilePath);
        }

        // Azure 스토리지 연결 문자열
        // 보안 문제 상 연결 문자열은 비공개, KAKAO TALK 참고
        private string connectionString = "";
        // Azure 스토리지 명
        private string containerName = "";

        public async Task DownloadFileAsync(string blobName, string downloadFilePath)
        {
            connectionString = storagekey.Text;
            containerName = storagename.Text;

            Console.WriteLine("커넥팅 스트링: " + connectionString);
            Console.WriteLine("컨테이너 네임"+containerName);

            // Azure 스토리지 클라이언트 연결
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);


            // 다운로드 할 Blob에 대한 참조 가져오기
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            bool exists = await blobClient.ExistsAsync();

            if(!exists)
            {
                // 다운로드 하려는 파일이 Azure 스토리지에 없는 경우
                MessageBox.Show("Azure Storage에 해당 파일이 존재하지 않습니다.", "DOWNLOAD ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("다운로드를 시작합니다.", "DOWNLOAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Blob의 내용을 다운로드하여 BlobDownloadInfo 객체에 저장
                BlobDownloadInfo download = await blobClient.DownloadAsync();


                // 로컬 파일 시스팀에 다운로드한 Blob의 내용을 저장
                using (FileStream fs = File.OpenWrite(downloadFilePath))
                {
                    /*
                     C# using 문

                    1. 특정 객체를 사용한 후 자동으로 리소스를 해제하도록 사용 됨
                    2. 주로 파일, 데이터베이스 연결, 네트워크 연결 등과 같이 직접적으로 시스템 리소스를 사용하는 객체와 함께 사용됨

                    hoon
                    {
                        using문을 잘 활용하면 예외처리할 때 도움이 될 듯 함.
                    }
                     */

                    await download.Content.CopyToAsync(fs);
                    fs.Close();
                }
            }
            
        }

        private async Task LoadStorageList()
        {
            try
            {
                connectionString = storagekey.Text;
                containerName = storagename.Text;
                // Blob 서비스 클라이언트 생성
                var blobServiceClient = new BlobServiceClient(connectionString);

                // 컨테이너 클라이언트 생성
                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                int size = containerClient.GetBlobs().Count();

                List<BlobItem> items = containerClient.GetBlobs().ToList();

                listBox1.Items.Clear();

                for (int i = 0; i < size; i++) 
                {
                    listBox1.Items.Add(items[i].Name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task UploadFile()
        {
            connectionString = storagekey.Text;
            containerName = storagename.Text;

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadStorageList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    textBox1.Text = filePath;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
