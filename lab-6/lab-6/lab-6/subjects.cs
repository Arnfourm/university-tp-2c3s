namespace lab_6
{
    class subjects
    {
        private string[] checker = { "Math", "Program", "Eng", "Chem" };
        private string[] teachers = { "Иванов", "Петров", "Сидоров", "Зеленов" };
        Random rand = new Random();

        public int Id;
        public string Subject;

        public string teach(string Subject)
        {
            if (checker.Contains(Subject))
            {
                return $"{teachers[rand.Next(0, 3)]}";
            }
            else
            {
                return "раз такого предмета нет, то и преподавателя тоже нет";
            }
        }

        public string Check(string Subject)
        {
            if (checker.Contains(Subject))
            {
                return "такой предмет существует";
            }
            else
            {
                return "такого предмета не существует";
            }
        }
    }
}