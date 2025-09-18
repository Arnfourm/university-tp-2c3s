using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace lab_9
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        List<Person> people = new List<Person>();
        List<IDoc> documents = new List<IDoc>();
        List<subject> subjects = new List<subject>();
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
                for (int i = 0; i < count_person; i++)
                {
                    Persons newPerson = new Persons();
                    newPerson.ShowDialog();
                    if (newPerson.radioValue == "Профессор")
                    {
                        people.Add(new Proffesor {
                            Id = people.Count + 1,
                            Name = newPerson.name,
                            Surname = newPerson.second_name, 
                            BirthDay = newPerson.date, 
                            workBook = random.Next(100000, 999999) 
                        });
                    }
                    else if (newPerson.radioValue == "Студент")
                    {
                        people.Add(new Student { 
                            Id = people.Count + 1, 
                            Name = newPerson.name,
                            Surname = newPerson.second_name, 
                            BirthDay = newPerson.date,
                            recordBook = random.Next(1000000, 9999999)
                        });
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
                for (int i = 0; i < count_docs; i++)
                {
                    Docs newDoc = new Docs();
                    newDoc.ShowDialog();
                    if (newDoc.radioValue == "Результаты экзамена")
                    {
                        documents.Add(new Exam { 
                            Id = documents.Count + 1, 
                            Document = "экзамена",
                            StudentsQuant = newDoc.students_quant,
                            Group = newDoc.group, 
                            Date = newDoc.date 
                        });
                    }
                    else if (newDoc.radioValue == "Результаты зачета")
                    {
                        documents.Add(new Test { 
                            Id = documents.Count + 1,
                            Document = "зачета", 
                            StudentsQuant = newDoc.students_quant,
                            Group = newDoc.group,
                            Date = newDoc.date 
                        });
                    }
                    else if (newDoc.radioValue == "Информация о ведомостях")
                    {
                        documents.Add(new State {
                            Id = documents.Count + 1,
                            Document = "ведомости", 
                            StudentsQuant = newDoc.students_quant,
                            Group = newDoc.group, 
                            Date = newDoc.date
                        });
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
                for (int i = 0; i < count_subjects; i++)
                {
                    Subjects newSubjects = new Subjects();
                    newSubjects.ShowDialog();
                    subjects.Add(new subject { 
                        Id = subjects.Count + 1,
                        Subject = newSubjects.subject
                    });
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
            Result result = new Result(people.ToArray(), documents.ToArray(), subjects.ToArray(), time, start_time, quantity_methods);
            result.Show();
        }
    }
}