using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lab_8
{
    public partial class add_info : Form
    {
        public add_info(Stopwatch time, DateTime start_time, int[] quantity_methods)
        {
            InitializeComponent();

            label1.Text = ($"Время выполнения программы - {time.ElapsedMilliseconds}ms");
            label2.Text = ($"Время запуска программы - {start_time.ToLongTimeString()}");
            label5.Text = ($"Количество выполнения метода Persons - {quantity_methods[0]} раз");
            label4.Text = ($"Количество выполнения метода IDoc - {quantity_methods[1]} раз");
            label3.Text = ($"Количество выполнения метода Subjects - {quantity_methods[2]} раз");
            label6.Text = ($"Операционная система - {Environment.OSVersion}");
        }
    }
}