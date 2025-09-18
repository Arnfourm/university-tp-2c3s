using System;
using System.Windows.Forms;


namespace lab_5
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
            radioValue = checker();
            name = textBox1.Text;
            second_name = textBox2.Text;
            string input = maskedTextBox1.Text;
            if (DateTime.TryParse(input, out DateTime date_temp)){
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
            return selected;
        }
    }
}
