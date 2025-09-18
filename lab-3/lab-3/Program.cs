namespace university
{
    class Program
    {
        static void Main(string[] args)
        {
            Employe[] stuff = new Employe[10];

            stuff[0] = new Proffesor { Name = "Игорь", BirthDay = new DateTime(1999, 5, 1) };
            stuff[1] = new Student { Name = "Воу, опять Игорь", BirthDay = new DateTime(1999, 5, 1) };
            stuff[2] = new Student { Name = "А, снова Игорь?!", BirthDay = new DateTime(1999, 5, 1) };
            stuff[3] = new Student { Name = "Опять Игорь...", BirthDay = new DateTime(1999, 5, 1) };
            stuff[4] = new Student { Name = "Да сколько можно..", BirthDay = new DateTime(1999, 5, 1) };
            for (int i = 0; i < stuff.Length; i++) {
                Console.WriteLine("Мое имя - {0}, родился {1} и я {2}", stuff[i].Name, stuff[i].BirthDay, stuff[i].WhoAmI());
            }
        }
    }

    abstract class Employe
    {
        public string Name;
        public DateTime BirthDay;

        public abstract string WhoAmI();
    }
    class Student : Employe
    {
        public override string WhoAmI()
        {
            return "Я аспирант!";
        }
    }
    class Proffesor : Employe
    {
        public override string WhoAmI()
        {
            return "Я профессор!";
        }
    }
}