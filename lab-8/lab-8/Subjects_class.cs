using System.Linq;
using System;

namespace lab_8
{

    delegate string SubCheck(string subject);

    class subject
    {
        private string[] checker = { "Математика", "Иностранный", "Программирование", "Философия" };
        private string[] teachers = { "Иванов", "Петров", "Сидоров", "Зеленов" };
        Random rand = new Random();

        public int Id;
        public string Subject;

        public string teach(string Subject)
        {
            SubCheck checkSub = subject => checker.Contains(subject) ? $"{teachers[rand.Next(0, 3)]}" : "раз такого предмета нет, то и преподавателя тоже нет";
            return checkSub(Subject);
        }

        public string Check(string Subject)
        {
            SubCheck checkSub = subject => checker.Contains(subject) ? "такой предмет существует" : "такого предмета не существует";
            return checkSub(Subject);
        }
    }
}
