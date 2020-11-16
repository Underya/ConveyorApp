using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ConveyorApp;

namespace UniTest.ConveyorApp
{
    [TestClass]
    public class ProductObjectTest
    {
        [TestMethod]
        public void CreateGood() 
        {
            ProductObject product = new ProductObject(ProductType.good);
        }

        [TestMethod]
        public void CreateDefective()
        {
            ProductObject product = new ProductObject(ProductType.defective);
        }

        [TestMethod]
        public void CheckType()
        {
            ProductObject product = new ProductObject(ProductType.defective);
            Assert.AreEqual(ProductType.defective, product.Type);
        }

        [TestMethod]
        public void CheckDeffictive()
        {
            ProductObject product = new ProductObject(ProductType.defective);
            Assert.IsTrue(product.IsDefective());
        }

        [TestMethod]
        public void CheckGood()
        {
            ProductObject product = new ProductObject(ProductType.good);
            Assert.IsTrue(product.IsGood());
        }

        [TestMethod]
        public void Id()
        {
            ProductObject product = new ProductObject(ProductType.good);
            int id = product.Id;
        }

        [TestMethod]
        public void CheckDifferentid()
        {
            ProductObject product = new ProductObject(ProductType.good);
            ProductObject product2 = new ProductObject(ProductType.good);
            Assert.AreNotEqual(product.Id, product2.Id);
        }
    }
}
