using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //test add()
        [TestMethod]
        public void addOrderTest()
        {
            Order a = new Order(123, "food");
            Order b = new Order(123, "water");
            
            Assert.IsTrue(OrderService.addOrder(a));
            Assert.IsTrue(OrderService.addOrder(b));

        }

        [TestMethod]
        public void deleteOrderTest()
        {

            Order a = new Order(123, "food");
            Order b = new Order(123, "water");
            OrderService.addOrder(a);

            Assert.IsTrue(OrderService.deleteOrder(a));
            Assert.IsTrue(OrderService.deleteOrder(b));
        }

        [TestMethod]
        public void searchOrderTest()
        {
            int id = -2;// indicate that the id doesn't exist
            List<Order> nulllist = null;
            List<Order> b = OrderService.searchOrder(id);
            CollectionAssert.Equals(nulllist, b);

            List<Order> c = OrderService.searchOrder(-2,-2);
            CollectionAssert.Equals(nulllist, c);


        }

        [TestMethod]
        public void changeOrderTest()
        {
            Order a = new Order(123, "food"); 
            OrderService.addOrder(a);

            Assert.IsTrue(OrderService.changeOrder(-22));

        }

    }
