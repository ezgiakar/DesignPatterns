using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCutomerProductBuilder();
            var builder2 = new OldCutomerProductBuilder();
            productDirector.GenerateProduct(builder);
            productDirector.GenerateProduct(builder2);
            var model = builder.GetModel();
            var model2 = builder2.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountAplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model2.Id);
            Console.WriteLine(model2.CategoryName);
            Console.WriteLine(model2.ProductName);
            Console.WriteLine(model2.DiscountAplied);
            Console.WriteLine(model2.DiscountedPrice);
            Console.WriteLine(model2.UnitPrice);
            Console.ReadLine();

        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountAplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCutomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice*(decimal)0.90;
            model.DiscountAplied = true;

        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    class OldCutomerProductBuilder : ProductBuilder
    {

        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountAplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
