using System.Reflection;

namespace ConsoleApp4
{
    public class Human
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Human(string? name, int age)
        {
            this.Name = name;
            this.Age = age;
        }   
        public override string ToString()
        {
            return $"{Name}\n";
        }

    }
    public interface IWorker
    {
        string? Job { set; }
        void Work();      
    }

    public interface ISalary
    {
        int Salary { set; }    
        string getSalaryInfo();
    }

    public class Worker : Human, IWorker, ISalary
    {
        protected string? _job;
        protected int _salary;
        public string? Job
        { 
            set 
            {if ((value ?? "").Contains(' '))
                    _job = "работаю";
                else _job = value;
            } 
        }
        public int Salary { 
            set
            {
                if (value < 0) _salary = 0;
                else _salary = value;
            } 
        }
        public Worker(string? name, int age, string? job) : base(name, age) 
        {
            Job = job;      
        }
        public void Work()
        {
            Salary = _salary;
            Console.WriteLine($"{this.ToString()} : {_job}");
        }
        public string getSalaryInfo()
        {
            return $"{this}: {_salary} денег";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Worker sasha = new Worker("Саша", 30, "кручу" );
            Worker anton = new Worker("Антон", 25, "еду");
            Worker[] workers = { anton, sasha };
            anton.Salary = 200;
            sasha.Salary = 300;
            foreach(Worker worker in workers)
            {
                worker.Work();
            }
            Console.WriteLine();
            foreach (Worker worker in workers)
            {
                worker.getSalaryInfo();
            }


        }
    }
}