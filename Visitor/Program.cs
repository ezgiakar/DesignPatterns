using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager ceren = new Manager { Name = "Ceren", Salary = 1000 };
            Manager ezgi = new Manager { Name = "Ezgi", Salary = 900 };

            Worker derin = new Worker { Name = "Derin", Salary = 800 };
            Worker ali = new Worker { Name = "Ali", Salary = 800 };

            ezgi.Subordinates.Add(ceren);
            ceren.Subordinates.Add(derin);
            ceren.Subordinates.Add(ali);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(ezgi);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRise payRiseVisitor = new PayRise();

            organisationalStructure.Accept(payRiseVisitor);
            organisationalStructure.Accept(payrollVisitor);

            Console.ReadLine();


        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Worker worker);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }
    }

    class PayRise : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary* (decimal) 1.1);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal) 1.2 );
        }
    }
}
