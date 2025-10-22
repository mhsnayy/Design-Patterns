using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesign
{
    class Program
    {
        /*
             * Amaç nesne üretim maliyetlerini minimize etmektir.
             * Mevcut classdan bir kopyasını oluşturarak yeni bir nesne üretiriz.
             
        */
        static void Main(string[] args)
        {
            Customer customer1 =new Customer 
            {   City="Ankara", 
                FirstName="Muhsin",
                LastName = "AY",
                Id =1};

            Customer customer2 = (Customer) customer1.Clone();
            customer2.FirstName = "Ahmet";
            Console.WriteLine("Customer1: " + customer1.FirstName);
            Console.Write("Customer2: " + customer2.FirstName);
            Console.ReadLine();
        }

        public abstract class Person
        {
            public abstract Person Clone();
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Customer : Person
        {
            public override Person Clone()
            {
                return (Person)this.MemberwiseClone();
            }
            public string City { get; set; }
        }
    }
}
