using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lab_5
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        Person[] people;
        IDoc[] documents;
        subject[] subjects;
        Stopwatch time = new Stopwatch();
        DateTime start_time = DateTime.Now;
        int[] quantity_methods = new int[3];

        public Form1()
        {
            InitializeComponent();
            time.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (int.TryParse(input, out int count_person))
            {
                people = new Person[count_person];

                for (int i = 0; i < count_person; i++)
                {
                    Persons newPerson = new Persons();
                    newPerson.ShowDialog();
                    if (newPerson.radioValue == "Профессор")
                    {
                        people[i] = new Proffesor { Id = i + 1, Name = newPerson.name, Surname = newPerson.second_name, BirthDay = newPerson.date, workBook = random.Next(100000, 999999) };
                    }
                    else if (newPerson.radioValue == "Студент")
                    {
                        people[i] = new Student { Id = i + 1, Name = newPerson.name, Surname = newPerson.second_name, BirthDay = newPerson.date, recordBook = random.Next(1000000, 9999999) };
                    }
                    quantity_methods[0] += 1;
                }
            }
            else
            {
                MessageBox.Show("Ошибка\nВведите целочисленное число");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            if (int.TryParse(input, out int count_docs))
            {
                documents = new IDoc[count_docs];

                for (int i = 0; i < count_docs; i++)
                {
                    Docs newDoc = new Docs();
                    newDoc.ShowDialog();
                    if (newDoc.radioValue == "Результаты экзамена")
                    {
                        documents[i] = new Exam { Id = i + 1, Document = "экзамена", StudentsQuant = newDoc.students_quant, Group = newDoc.group, Date = newDoc.date };
                    }
                    else if (newDoc.radioValue == "Результаты зачета")
                    {
                        documents[i] = new Test { Id = i + 1, Document = "зачета", StudentsQuant = newDoc.students_quant, Group = newDoc.group, Date = newDoc.date };
                    }
                    else if (newDoc.radioValue == "Информация о ведомостях")
                    {
                        documents[i] = new State { Id = i + 1, Document = "ведомости", StudentsQuant = newDoc.students_quant, Group = newDoc.group, Date = newDoc.date };
                    }
                    quantity_methods[1] += 1;
                }
            }
            else
            {
                MessageBox.Show("Ошибка\nВведите целочисленное число");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            if (int.TryParse(input, out int count_subjects))
            {
                subjects = new subject[count_subjects];
                for (int i = 0; i < count_subjects; i++)
                {
                    Subjects newSubjects = new Subjects();
                    newSubjects.ShowDialog();
                    subjects[i] = new subject { Id = i + 1, Subject = newSubjects.subject };
                    quantity_methods[2] += 1;
                }
            }
            else
            {
                MessageBox.Show("Ошибка\nВведите целочисленное число");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result result = new Result(people, documents, subjects, time, start_time, quantity_methods);
            result.Show();
        }
    }
}