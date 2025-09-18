using System;
using System.Windows.Forms;

namespace lab_9
{
    public partial class Subjects : Form
    {

        public string subject;

        public Subjects()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            subject = textBox1.Text;
            this.Close();
        }
    }
}
