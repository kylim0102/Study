using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// bmi 계산
        /// </summary>
        /// <param name="dkg"></param>
        /// <param name="dcm"></param>
        /// <returns></returns>
        private double cal(double dkg, double dcm)
        {
            double dRet = Math.Round(dkg / (dcm * dcm),1);

            return dRet;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
           
            double dcm = double.Parse(textBox1.Text) / 100;   //cm 값을 m 로 변환
            double dkg = double.Parse(textBox2.Text);
            // 값 계산
            double dRet = cal(dkg, dcm);
            int tb = (int)(dRet * 10);
                if (tb < 150)
                {
                    tb = 150;
                }
                else if(tb > 280)
                {
                    tb = 280;
                }

            // 트랙바로 이동
            tbarRet.Value = tb;
            String result = res(dRet);
            lbiRet.Text = $"BMI 지수 [{dRet}]로 비만도 결과 [{result}]입니다.";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
             

        private String res(double dRet)
        {
            String strRet = string.Empty;
            if (dRet < 18.5)
            {
                strRet = "저체중";
            }
            else if (18.5 <= dRet && dRet < 23)
            {
                strRet = "정상";
            }
            else if (23 <= dRet && dRet < 25)
            {
                strRet = "과체중";
            }
            else if (25 <= dRet)
            {
                strRet = "비만";
            }
            return strRet;
        }
    }
}
