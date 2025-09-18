using System;
using System.Windows.Forms;
using System.Threading;

namespace lab_9
{
    public partial class Persons : Form
    {
        public string name;
        public string second_name;
        public DateTime date;
        public string radioValue;

        public Persons()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int error = 1;
            var thread = new Thread(() =>
            {
                (DateTime dateTemp, int errorTemp) = errorCheckDate(maskedTextBox1.Text);
                date = dateTemp;
                error = errorTemp;
            });
            thread.Start();

            string radioValueTemp = checker();
            string nameTemp = textBox1.Text;
            string second_nameTemp = textBox2.Text;
            DateTime dateThread = DateTime.Now;

            thread.Join();

            if (error == 0)
            {
                radioValue = radioValueTemp;
                name = nameTemp;
                second_name = second_nameTemp;
                date = dateThread;
                this.Close();
            }
        }

        private static (DateTime, int) errorCheckDate(string input)
        {
            DateTime dateThread = DateTime.Now;
            int error;

            if (DateTime.TryParse(input, out DateTime dateTemp))
            {
                if (dateTemp.Year <= DateTime.Now.Year && dateTemp.Year >= 1924)
                {
                    dateThread = dateTemp;
                    error = 0;
                }
                else
                {
                    MessageBox.Show("Ошибка\nДата не реальная!");
                    error = 1;
                }
            }
            else
            {
                MessageBox.Show("Ошибка\nВведена неправильная дата");
                error = 1;
            }

            return (dateThread, error);
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
            return selected;
        }
    }
}
