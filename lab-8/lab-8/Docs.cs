using System;
using System.Linq;
using System.Windows.Forms;

namespace lab_8
{

    delegate bool isChecked(int toCheckValue);

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
            int[] errors = new int[3];

            radioValue = checker();
            group = textBox1.Text;

            isChecked Checker = countToCheck => countToCheck >= 0 && countToCheck <= 30;

            if (Int32.TryParse(textBox2.Text, out int count) && Checker(count))
            {
                students_quant = count;
                errors[0] = 0;
            }
            else
            {
                MessageBox.Show("Ошибка\nВ группе от 1 до 30 человек");
                errors[0] = 1;
            }
            string input = maskedTextBox1.Text;
            if (DateTime.TryParse(input, out DateTime date_temp))
            {
                if (date_temp.Year <= DateTime.Now.Year && date_temp.Year >= 1924)
                {
                    date = date_temp;
                    errors[1] = 0;
                }
                else
                {
                    MessageBox.Show("Ошибка\nДата не реальная!");
                    errors[1] = 1;
                }
                errors[2] = 0;
            }
            else
            {
                MessageBox.Show("Ошибка\nВведена неправильная дата");
                errors[2] = 1;
            }
            if (errors.Sum() == 0)
            {
                this.Close();
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
