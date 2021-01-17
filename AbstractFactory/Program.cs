using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message); 
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string message);
    }
    public class MemCache : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogging();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        Logging _logging;
        Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = crossCuttingConcernsFactory.CreateLogging();
            _caching = crossCuttingConcernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products listed!");
        }
    }

}
