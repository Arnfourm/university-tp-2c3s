namespace DelegateGropuAddressDemo
{
    public delegate void StudentRatingProcessor(Group group);
    enum RatingStatus { Passed, Notpassed };
    class StudentGroupActions
    {
        //печать рейтинговой ведомости
        public static void PrintRatingVedomost(Group group)
        {
            Console.WriteLine($"Рейтинговая ведомость группы {group.GroupTitle}");
            for (int i = 0; i < group.GroupSize; i++)
            {
                Console.WriteLine($"Студент {i+1}. ФИО - {group[i].FIO}");
                Console.Write("Оценки: ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{group[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        //расчет рейтинга студентов
        public static void CalculateRatings(Group group)
        {
            int summBalls;
            for (int i = 0; i < group.GroupSize; i++)
            {
                summBalls = 0;
                for (int j = 0; j < 4; j++)
                {
                    summBalls += group[i][j];
                }
                if (summBalls >= (10 * 4 / 2)) group[i].Rating = (int)RatingStatus.Passed;
                else group[i].Rating = (int)RatingStatus.Notpassed;
            }
        }
        
        //печать зачетной ведомости
        public static void PrintRankingList(Group group)
        {
            Console.WriteLine($"\nЗачетная ведомость группы {group.GroupTitle}");
            for (int i = 0; i < group.GroupSize; i++)
            {
                Console.Write($"Студент {i+1} - ");
                Console.WriteLine((group[i].Rating == (int)RatingStatus.Passed) ? "ЗАЧТЕНО" : "НЕЗАЧТЕНО");
            }
        }
    }

    public class Student
    {
        String fio;
        public String FIO { set { fio = value; } get { return fio; } }
        Byte[] balls;
        public Byte this[int i] { get { return balls[i]; } set { balls[i] = value; } }
        int rating;
        public int Rating { get { return rating; } set { rating = value; } }
        public Student(String FIO)
        {
            rating = 0;
            balls = new Byte[4];
            fio = FIO;
        }
    }

    public class Group
    {
        int groupSize;
        string groupTitle = "";
        public string GroupTitle { get { return groupTitle; } }
        public int GroupSize { get { return groupSize; } }
        Student[] students;
        public Student this[int i] { get { return students[i]; } }
        public Group(string Title, int Size)
        {
            groupTitle = Title;
            groupSize = Size;
            students = new Student[Size];
        }
        public void InitRandom()
        {
            try
            {
                var rnd = new Random();
                for (int i = 0; i < GroupSize; i++)
                {
                    String randomString = "";
                    for (int j = 0; j < 5; j++)
                        randomString += (rnd.Next(255).ToString());
                    students[i] = new Student(randomString);
                    for (int j = 0; j < 4; j++) students[i][j] = (byte)rnd.Next(10);
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Group ist110 = new Group("IST110", 10);
            ist110.InitRandom();

            StudentRatingProcessor studentRating;
            StudentRatingProcessor Print = StudentGroupActions.PrintRatingVedomost;
            StudentRatingProcessor Calculate = StudentGroupActions.CalculateRatings;
            StudentRatingProcessor PrintList = StudentGroupActions.PrintRankingList;
            studentRating = Print;
            studentRating += Calculate;
            studentRating += PrintList;
            studentRating(ist110);

            Console.ReadLine();
        }
    }
 }
