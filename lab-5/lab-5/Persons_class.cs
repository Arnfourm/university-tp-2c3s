using System;

namespace lab_5
{
    class Person
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateTime BirthDay;
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