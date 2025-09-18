using lab_7;
using System.Diagnostics;

namespace university
{
    public delegate void Handler();

    class Program
    {
        static event Handler Handler;
        static List<Person> people = new List<Person>();
        static List<IDoc> docs = new List<IDoc>();
        static List<subjects> subjects = new List<subjects>();
        static Stopwatch time = new Stopwatch();
        static DateTime startTime = DateTime.Now;
        static int[] quantityMethods = new int[3];

        static void Main(string[] args)
        {
            Random rand = new Random();
            time.Start();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("Для ввода человека - 1");
                Console.WriteLine("Для ввода документов - 2");
                Console.WriteLine("Для ввода предметов - 3");
                Console.WriteLine("Для вывода результатов - 4");
                string operationString = Console.ReadLine();
                if (!int.TryParse(operationString, out int operation) || operation < 0 || operation > 4)
                {
                    Console.WriteLine("\nВведите корректное число");
                    continue;
                }
                if (operation == 1)
                {
                    Console.WriteLine("\nВведите количество людей");
                    string countpersonsString = Console.ReadLine();
                    if (!int.TryParse(countpersonsString, out int countpersons) || countpersons < 0)
                    {
                        Console.WriteLine("\nВведено некорректное число");
                        continue;
                    }
                    Console.WriteLine("\nЧтобы выбрать профессора - введите 1. \nЧтобы выбрать студента - введите 2");

                    for (int i = 0; i < countpersons; i++)
                    {
                        Console.WriteLine("\nКого хотите выбрать?");
                        string typepersonString = Console.ReadLine();
                        if (!int.TryParse(typepersonString, out int person) || person < 0 || person > 2)
                        {
                            Console.WriteLine("\nВведено некорректное число");
                            continue;
                        }
                        Console.WriteLine("\nВведите имя и фамилию");
                        string nm = Console.ReadLine();
                        string[] name = nm.Split(' ');

                        if (person == 1)
                        {
                            people.Add(new Proffesor { Id = people.Count + 1, Name = name[0], Surname = name[1], BirthDay = new DateOnly(rand.Next(1950, 2010), rand.Next(1, 12), rand.Next(1, 30)), workBook = rand.Next(100000, 999999) });
                        }
                        else if (person == 2)
                        {
                            people.Add(new Student { Id = people.Count + 1, Name = name[0], Surname = name[1], BirthDay = new DateOnly(rand.Next(1950, 2010), rand.Next(1, 12), rand.Next(1, 30)), recordBook = rand.Next(1000000, 9999999) });
                        }
                        quantityMethods[0]++;
                    }
                }

                if (operation == 2)
                {
                    Console.WriteLine("\nСколько документов?");
                    string countdocsString = Console.ReadLine();
                    if (!int.TryParse(countdocsString, out int countdocs) || countdocs < 0)
                    {
                        Console.WriteLine("\nВведено некорректное число");
                        continue;
                    }
                    Console.WriteLine("\nЧтобы выбрать результаты экзамена - введите 1 \nЧтобы выбрать результаты зачета - введите 2 \nЧтобы выбрать информацию о ведомостях - введите 3");
                    for (int i = 0; i < countdocs; i++)
                    {
                        Console.WriteLine("\nЧто хотите выбрать?");
                        string typedocsString = Console.ReadLine();
                        if (!int.TryParse(typedocsString, out int typedocs) || typedocs < 0 || typedocs  > 3)
                        {
                            Console.WriteLine("\nВведено некорректное число");
                            continue;
                        }
                        Console.WriteLine("\nВведите группу");
                        string group = Console.ReadLine();
                        if (typedocs == 1)
                        {
                            docs.Add(new Exam { Id = docs.Count + 1, Document = "экзамена", StudentsQuant = rand.Next(1, 30), Group = group, Date = new DateOnly(rand.Next(2000, 2024), rand.Next(1, 12), rand.Next(1, 30)) });
                        }
                        else if (typedocs == 2)
                        {
                            docs.Add(new Test { Id = docs.Count + 1, Document = "зачета", StudentsQuant = rand.Next(1, 30), Group = group, Date = new DateOnly(rand.Next(2000, 2024), rand.Next(1, 12), rand.Next(1, 30)) });
                        }
                        else if (typedocs == 3)
                        {
                            docs.Add(new State { Id = docs.Count + 1, Document = "ведомости", StudentsQuant = rand.Next(1, 30), Group = group, Date = new DateOnly(rand.Next(2000, 2024), rand.Next(1, 12), rand.Next(1, 30)) });
                        }
                        quantityMethods[1]++;
                    }
                }

                if (operation == 3)
                {
                    Console.WriteLine("\nВведите количество дисциплин");
                    string countsubjectString = Console.ReadLine();
                    if (!int.TryParse(countsubjectString, out int countsubject) || countsubject < 0)
                    {
                        Console.WriteLine("\nВведено некорректное число");
                        continue;
                    }

                    for (int i = 0; i < countsubject; i++)
                    {
                        Console.WriteLine("\nВведите название предмета");
                        string subject_name = Console.ReadLine();
                        subjects.Add(new subjects { Id = subjects.Count + 1, Subject = subject_name });
                        quantityMethods[2]++;
                    }
                }

                if (operation == 4)
                {
                    Handler = PrintPeople;
                    Handler += PrintDocs;
                    Handler += PrintSubjects;
                    Handler += AddInfo;

                    Handler();
                }
            }
        }

        static void PrintPeople()
        {
            Console.WriteLine("\nИнформация о людях:");
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i] != null && people[i] is Proffesor prof)
                {
                    Console.WriteLine($"id преподавателя - {prof.Id}, его имя - {prof.Name}, фамилия - {prof.Surname}, родился {prof.BirthDay.ToShortDateString()}, номер трудовой книжки - {prof.workBook}");
                }
                else if (people[i] != null && people[i] is Student student)
                {
                    Console.WriteLine($"id студента - {student.Id}, его имя - {student.Name}, фамилия - {student.Surname}, родился {student.BirthDay.ToShortDateString()}, номер зачетки - {student.recordBook}");
                }
            }
        }

        static void PrintDocs()
        {
            Console.WriteLine("\nИнформация о документах:");
            for (int i = 0; i < docs.Count; i++)
            {
                if (docs[i] != null)
                {
                    Console.WriteLine($"id документа - {docs[i].Id}, название документа - {docs[i].WhatADoc()}, необходим для {docs[i].Document}, группа - {docs[i].Group}, {docs[i].results()}, дата подписания документа {docs[i].Date.ToShortDateString()}");
                }
            }
        }

        static void PrintSubjects()
        {
            Console.WriteLine("\nИнформация о предметах:");
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.WriteLine($"id предмета - {subjects[i].Id}, предмет - {subjects[i].Subject}, {subjects[i].Check(subjects[i].Subject)}, преподаватель - {subjects[i].teach(subjects[i].Subject)}");
            }
        }

        static void AddInfo()
        {
            Console.WriteLine("\nДополнительная информация:");
            Console.WriteLine($"Время выполнения программы - {time.ElapsedMilliseconds}ms\nВремя запуска программы - {startTime.ToLongTimeString()}\nКоличество выполнения метода Persons - {quantityMethods[0]} раз\nКоличество выполнения метода IDoc - {quantityMethods[1]} раз\nКоличество выполнения метода Subjects - {quantityMethods[2]} раз\nОперационная система - {Environment.OSVersion}");
        }
    }
}