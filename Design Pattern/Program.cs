using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Bir nesne örneği sadece 1 kere üretilip, her zaman kullanılması öngörülür. 
             * Mesela bir webde kaç kullanıcı aktif sorusunu tüm kullanıcılara ulaştırmak için.
             * Değer değiştiğinde tüm kullanıcılar etkilenir.
             * Singelton design patternde nesnenin ömrü uygulama kapanana kadar devam eder.
            */

            var customerManager = CustomerManager.CreateAsSingelton();
            customerManager.Save();

        }

        public class CustomerManager
        {
            private static CustomerManager _customerManager; //Private ve static 
            static object _lockObject = new object(); // create lock object for thread safety 
            //çoklu thread ortamında tek bir instance üretmek için kullanılır. Aynı anda 2 thread nesne üretmeye kalkarsa kilitlenir ve sırayla üretir.

            private CustomerManager()
            {

            }
            public static CustomerManager CreateAsSingelton() //static method newlenememesi lazım.
            {
               lock (_lockObject)
                {
                    if (_customerManager == null)
                    {
                        _customerManager = new CustomerManager();
                    }
                }
               return _customerManager;

                // return _customerManager ?? (_customerManager = new CustomerManager()); // in one line without lock
            }

            public void Save()
            {
                Console.WriteLine("Saved");
            }
        }
    }
}
