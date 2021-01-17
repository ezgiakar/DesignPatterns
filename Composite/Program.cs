using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee olcay = new Employee { Name = "Olcay Akar"} ;
            Employee berat = new Employee { Name = "Berat Akar" };

            olcay.AddSubordinat(berat);

            Employee berkay = new Employee { Name = "Berkay Akar" };

            olcay.AddSubordinat(berkay);

            Employee ilknur = new Employee { Name = "İlknur Akar" };
            Contractor ali = new Contractor { Name = "Ali" };
            berkay.AddSubordinat(ali);

           

            

            berkay.AddSubordinat(ilknur);
            

            Console.WriteLine(olcay.Name);

            foreach (Employee manager in olcay)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
         string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>  //foreach ile gezebileceğimiz bir ortam yaratmaktadır
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinat(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinat(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
