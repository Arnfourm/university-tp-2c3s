using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace lab_9
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
            int[] errors = new int[2];
            string radioValueTemp = checker();
            string groupTemp = textBox1.Text;
            int studentsQuantTemp = 0;

            var thread = new Thread(() =>
            {
                (int studentsQuantThread, int error0) = errorCheckGroup(textBox2.Text);
                studentsQuantTemp = studentsQuantThread;
                errors[0] = error0;
            });
            thread.Start();

            (DateTime dateTemp, int error1) = errorCheckDate(maskedTextBox1.Text);
            errors[1] = error1;

            thread.Join();

            if (errors.Sum() == 0)
            {
                radioValue = radioValueTemp;
                group = groupTemp;
                students_quant = studentsQuantTemp;
                date = dateTemp;
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

        private static (int, int) errorCheckGroup(string textBox2)
        {
            isChecked Checker = countToCheck => countToCheck >= 0 && countToCheck <= 30;
            int error0;
            int studentsQuant = 0;

            if (Int32.TryParse(textBox2, out int count) && Checker(count))
            {
                studentsQuant = count;
                error0 = 0;
            }
            else
            {
                MessageBox.Show("Ошибка\nВ группе от 1 до 30 человек");
                error0 = 1;
            }

            return (studentsQuant, error0);
        }

        private static (DateTime, int) errorCheckDate(string input)
        {
            DateTime dateThread = DateTime.Now;
            int error1;

            if (DateTime.TryParse(input, out DateTime dateTemp))
            {
                if (dateTemp.Year <= DateTime.Now.Year && dateTemp.Year >= 1924)
                {
                    dateThread = dateTemp;
                    error1 = 0;
                }
                else
                {
                    MessageBox.Show("Ошибка\nДата не реальная!");
                    error1 = 1;
                }
            }
            else
            {
                MessageBox.Show("Ошибка\nВведена неправильная дата");
                error1 = 1;
            }

            return (dateThread, error1);
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
