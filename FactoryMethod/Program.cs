using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Amaç Yazılımdaki değişimi kontrol altında tutmaktır.
             * 
            */
            CustomerMenager customerMenager = new CustomerMenager(new LoggerFactory());
            customerMenager.Save();
            Console.ReadLine();

        }
    }
    public interface ILoggerFactory//Fabrica interfacei
    {
        ILogger CreateLogger();
    }
    public class LoggerFactory : ILoggerFactory//Fabrikamız
    {
        public ILogger CreateLogger()
        {
            //Burada iş geliştirip hangi logger seçilecek kararı verilir
            return new DbLogger();
        }
    }
  
    public interface ILogger//Logger interfacei
    {
        void Log();
    }
    public class DbLogger : ILogger//Logger implementasyonu
    {
        public void Log()
        {
            Console.WriteLine("Logged with DbLogger");
        }
    }
    public class  CustomerMenager//Fabrikamızı kullanan sınıf
    {
        private ILoggerFactory _loggerFactory;
        public CustomerMenager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
