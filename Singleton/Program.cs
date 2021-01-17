using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
            // return _customerManager ?? (_customerManager = new CustomerManager());
        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
