using System;
using System.Linq;
using System.Windows.Forms;

namespace lab_8
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
            int[] errors = new int[2];
            radioValue = checker();
            name = textBox1.Text;
            second_name = textBox2.Text;
            string input = maskedTextBox1.Text;
            if (DateTime.TryParse(input, out DateTime date_temp))
            {
                if (date_temp.Year <= DateTime.Now.Year && date_temp.Year >= 1924)
                {
                    date = date_temp;
                    errors[0] = 0;
                }
                else
                {
                    MessageBox.Show("Ошибка\nДата не реальная!");
                    errors[0] = 1;
                }
                errors[1] = 0;
            }
            else
            {
                MessageBox.Show("Ошибка\nВведена неправильная дата");
                errors[1] = 1;
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
            return selected;
        }
    }
}
