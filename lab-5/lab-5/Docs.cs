using System;
using System.Windows.Forms;

namespace lab_5
{
    public partial class Docs : Form
    {
        public string radioValue;
        public string group;
        public DateTime date;
        public int students_quant;

        public Docs()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radioValue = checker();
            group = textBox1.Text;            
            if (Int32.Parse(textBox2.Text) <= 30 && Int32.Parse(textBox2.Text) >= 0)
            {
                students_quant = Int32.Parse(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Ошибка\nВ группе от 1 до 30 человек");
            }
            string input = maskedTextBox1.Text;
            if (DateTime.TryParse(input, out DateTime date_temp))
            {
                date = date_temp;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка\nВведена неправильная дата");
            }
        }

        private string checker()
        {
            string selected = "";
            if (radioButton1.Checked)
            {
                selected = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                selected = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                selected = radioButton3.Text;
            }
            return selected;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = ("Сколько человек сдало?");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = ("Сколько человек получило зачет?");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = ("Сколько человек с идеальной посещаемостью?");
        }
    }
}
