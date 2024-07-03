using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginTest
{
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(userid.Text.Equals(""))
            {
                MessageBox.Show("사용할 아이디를 입력해주세요.","USERID ERROR!",MessageBoxButtons.OK);
                userid.Focus();
            }
            else if(password.Text.Equals(""))
            {
                MessageBox.Show("사용할 비밀번호를 입력해주세요.","PASSWORD ERROR!",MessageBoxButtons.OK);
                password.Focus ();
            }
            else if(email.Text.Equals(""))
            {
                MessageBox.Show("이메일을 입력해주세요.","E-MAIL ERROR!",MessageBoxButtons.OK);
                email.Focus ();
            }
            else if(!email.Text.Contains("@"))
            {
                MessageBox.Show("@ 웹주소까지 입력해주세요.","E-MAIL ERROR!",MessageBoxButtons.OK);
                email.Focus ();
            }
            else if(address.Text.Equals(""))
            {
                MessageBox.Show("거주중인 주소를 입력해주세요.","ADDRESS ERROR!",MessageBoxButtons.OK);
                address.Focus ();
            }
            else
            {
                MessageBox.Show("가입을 환영합니다.", "WELCOME !",MessageBoxButtons.OK);
                this.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("다시 작성하시겠습니까?","RESET!",MessageBoxButtons.OKCancel);
            
            Console.WriteLine("Dialgresult: "+dr);

            if (dr == DialogResult.OK)
            {
                Console.WriteLine("확인");
                userid.Text = string.Empty;
                password.Text = string.Empty;
                email.Text = string.Empty;
                address.Text = string.Empty;
                userid.Focus();
            }
            else
            {
                Console.WriteLine("취소");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(userid.Text.Equals(""))
            {
                MessageBox.Show("확인할 아이디를 입력해주세요.", "USERID CHECK ERROR!", MessageBoxButtons.OK);
                userid.Focus();
            }
            else
            {
                MessageBox.Show("사용가능합니다!", "SUCCESS!", MessageBoxButtons.OK);
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
