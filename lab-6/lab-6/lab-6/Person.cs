namespace lab_6
{
    class Person
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateOnly BirthDay;
    }
    class Student : Person
    {
        public int recordBook;
    }
    class Proffesor : Person
    {
        public int workBook;
    }
}