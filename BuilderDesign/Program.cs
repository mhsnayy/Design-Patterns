using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesign
{
    class Program
    {
        /*
         * Bir nesne örneği çıkarmak için kullanılır.
         * Kodlar ifle yazılmak yerine (UI veya BLL layer) üreticinin enjekte edilmesiyle yazılır.
        */
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builderNew = new NewCustomerProductBuilder();
            director.GenerateProduct(builderNew);
            var model = builderNew.GetModel();
            Console.WriteLine(model.DiscountedPrice);
            Console.ReadLine();
        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }
    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.Id = 1;
            model.Name = "Product 1";
            model.CategoryName = "Category 1";
            model.Price = 100;
        }

        public override void GetProductData()
        {
            model.DiscountedPrice = model.Price * (decimal)0.9;
            model.DiscountApplied = true;
        }
        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.Id = 1;
            model.Name = "Product 1";
            model.CategoryName = "Category 1";
            model.Price = 100;
        }

        public override void GetProductData()
        {
            model.DiscountedPrice = model.Price;
            model.DiscountApplied = false;
        }
        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder builder)
        {
            builder.ApplyDiscount();
            builder.GetProductData();
        }
    }
}
