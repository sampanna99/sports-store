﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name = "P1" },
                new Product {ProductId = 2, Name = "P2" },
                new Product {ProductId = 3, Name = "P3" },
                new Product {ProductId = 4, Name = "P4" },
                new Product {ProductId = 5, Name = "P5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            //act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            //after adding the viewmodel

            ProductListViewModel result = (ProductListViewModel)controller.List(null, 2).Model;


            //assert
            Product[] prodArray = result.Products.ToArray(); //I changed here some after adding the view model
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");

        }
    }

    //[TestMethod]
    //public void Can_Generate_Page_Links()
    //{

    //}

    //[TestMethod]

}
