using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace test12
{
    public partial class Form1 : Form
    {

        MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder();

        ucPanel.ucScreen1 ucSc1 = new ucPanel.ucScreen1();
        ucPanel.ucScreen2 ucSc2 = new ucPanel.ucScreen2();
        ucPanel.ucScreen3 ucSc3 = new ucPanel.ucScreen3();
        ucPanel.main main = new ucPanel.main();

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormLoad(object sender, EventArgs e)
        {
            ucSc1.eLogSender += ucSc_eLogSender;
            ucSc2.eLogSender += ucSc_eLogSender;
            ucSc3.eLogSender += ucSc_eLogSender;

            pMain.Controls.Add(main);
        }
        #region del Event
        private void ucSc_eLogSender(object sender, enLogLevel eLevel, String StrLog)
        {
            Log(eLevel, $"[{sender.ToString()}] {StrLog}");
        }
        #endregion
        #region 버튼 Event
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            pMain.Controls.Clear();
            pMain.Controls.Add(ucSc1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            pMain.Controls.Clear();
            pMain.Controls.Add(ucSc2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            pMain.Controls.Clear();
            pMain.Controls.Add(ucSc3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region Log OverLoading
        private void Log(enLogLevel eLevel, String LogDesc)
        {
            DateTime dtime = DateTime.Now;
            string LogInfo = $"{dtime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            listBox1.Items.Insert(0, LogInfo);
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Server = "kiosk.mysql.database.azure.com";
            conn.Port = 3306;
            conn.Database = "kiosk";
            conn.UserID = "youngjin";
            conn.Password = "admin123456789;";

            MySqlConnection con = new MySqlConnection(conn.ConnectionString);
                try
                {
                    con.Open();
                    lblStatus.Text = "Connection successful!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Connection failed: " + ex.Message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

