using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test12.ucPanel
{
    public partial class ucScreen3 : UserControl
    {
        public event delLogSender eLogSender;
        public ucScreen3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eLogSender("Screen3 Button", enLogLevel.Info, "Button Click");
        }
    }
}
