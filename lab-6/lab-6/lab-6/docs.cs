namespace lab_6
{
    interface IDoc
    {
        int Id { get; set; }
        string Document { get; set; }
        string Group { get; set; }
        DateOnly Date { get; set; }
        int StudentsQuant { get; set; }

        string WhatADoc();
        string results();
    }

    class Exam : IDoc
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Group { get; set; }
        public DateOnly Date { get; set; }
        public int StudentsQuant { get; set; }

        public string WhatADoc()
        {
            return "экзаменационный документ";
        }
        public string results()
        {
            return $"количество сдавших экзамен - {StudentsQuant}";
        }
    }

    class Test : IDoc
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Group { get; set; }
        public DateOnly Date { get; set; }
        public int StudentsQuant { get; set; }

        public string WhatADoc()
        {
            return "документ о зачетах";
        }
        public string results()
        {
            return $"количество сдавших зачет - {StudentsQuant}";
        }
    }

    class State : IDoc
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Group { get; set; }
        public DateOnly Date { get; set; }
        public int StudentsQuant { get; set; }

        public string WhatADoc()
        {
            return "ведомость";
        }
        public string results()
        {
            return $"количество идеальных посещений - {StudentsQuant}";
        }
    }
}
