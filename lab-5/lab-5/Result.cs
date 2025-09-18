using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lab_5
{
    public partial class Result : Form
    {
        Stopwatch time;
        DateTime start_time;
        int[] quantity_methods;

        internal Result(Person[] people, IDoc[] documents, subject[] subjects, Stopwatch time, DateTime start_time, int[] quantity_methods)
        {
            InitializeComponent();
            this.time = time;
            this.start_time = start_time;
            this.quantity_methods = quantity_methods;

            if (people != null)
            {
                for (int i = 0; i < people.Length; i++)
                {
                    if (people[i] != null && people[i] is Proffesor prof)
                    {
                        label1.Text += ($"id преподавателя - {prof.Id}, его имя - {prof.Name}, фамилия - {prof.Surname}, родился {prof.BirthDay.ToShortDateString()}, номер трудовой книжки - {prof.workBook}\n\n");
                    }
                    else if (people[i] != null && people[i] is Student student)
                    {
                        label1.Text += ($"id студента - {student.Id}, его имя - {student.Name}, фамилия - {student.Surname}, родился {student.BirthDay.ToShortDateString()}, номер зачетки - {student.recordBook}\n\n");
                    }
                }
            }
            if (documents != null)
            {
                for (int i = 0; i < documents.Length; i++)
                {
                    if (documents[i] != null)
                    {
                        label2.Text += ($"id документа - {documents[i].Id}, название документа - {documents[i].WhatADoc()}, необходим для {documents[i].Document}, группа - {documents[i].Group}, {documents[i].results()}, дата подписания документа {documents[i].Date.ToShortDateString()}\n\n");
                    }
                }
            }
            if (subjects != null)
            {
                for (int i = 0; i < subjects.Length; i++)
                {
                    label3.Text += ($"id предмета - {subjects[i].Id}, предмет - {subjects[i].Subject}, {subjects[i].Check(subjects[i].Subject)}, преподаватель - {subjects[i].teach(subjects[i].Subject)}\n\n");
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            add_info add_Info = new add_info(time, start_time, quantity_methods);
            add_Info.Show();
        }
    }
}
