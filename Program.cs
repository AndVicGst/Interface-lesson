using System.Reflection;
using System.Collections;

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
            return $"{Name}";
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

    public class Prisoner : Human, IWorker
    {
        protected string? _job;
        public string? Job
        {
            set
            {
                _job = value;
            }
        }
        public Prisoner(string? name, int age, string? job) : base(name, age)
        {
            Job = job;
        }
        public void Work()
        {
            Console.WriteLine($"{this}: {_job}");
        }
    }
    public class Boss : Human, ISalary
    {
        protected int? _salary;
        public int Salary
        {
            set
            {
                _salary= value;
            }
        }
        public Boss(string? name, int age, int salary) : base(name, age)
        {
            Salary = salary;
        }
        public string getSalaryInfo()
        {
            return $"{this}: {_salary} денег";
        }
    }

    class Personal : IEnumerable
    {
        List<Human> personal;
        public Personal(List<Human> personal)
        {
            this.personal = personal;
        }
        public List<IWorker> Workers
        {
            get
            {
                List<IWorker> workers = new();
                foreach (Human human in personal) if ((human as IWorker) != null) workers.Add(human as IWorker);
                return workers;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return personal.GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Worker sasha = new Worker("Саша", 30, "кручу");
            //Worker anton = new Worker("Антон", 25, "еду");
            //Worker[] workers = { anton, sasha };
            //anton.Salary = 200;
            sasha.Salary = 300;

            //Console.WriteLine();
            //foreach (Worker worker in workers)
            //{
            //    Console.WriteLine(worker.getSalaryInfo());
            //}
            Prisoner evgen = new Prisoner("Евгений", 20, "копаю");
            //Prisoner kolya = new Prisoner("Коля", 20, "несу");
            //IWorker[] workers1 = { anton, sasha, evgen };

            //foreach(IWorker worker in workers1)
            //{
            //    Console.WriteLine(
            //        (worker as ISalary)?.getSalaryInfo()
            //        );
            //}

            //foreach (IWorker worker in workers1)
            //{
            //    worker.Work();
            //}
            Boss boss = new Boss("Boss", 40, 500);

            //Human[] humans = { anton, sasha, evgen, boss, kolya };

            //foreach (Human human in humans)
            //{
            //    if ((human as IWorker) != null) (human as IWorker)?.Work();
            //}
            //Console.WriteLine();
            //foreach (Human human in humans)
            //{
            //    if ((human as ISalary) != null)  Console.WriteLine((human as ISalary)?.getSalaryInfo());
            //}
            List<Human> humans = new List<Human>();
            humans.Add(sasha);
            humans.Add(evgen);  
            humans.Add(boss);   
            Personal personal = new(humans);
            foreach(Human human in personal)
            {
                Console.WriteLine(human);
            }    
            foreach (IWorker worker in personal.Workers)
            {
                worker.Work();
            }


        }
    }
}