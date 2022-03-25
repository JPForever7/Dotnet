using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    [Serializable]
    public class OrderDetails
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public OrderDetails ()
        {
            number = 0;
            price = 0;
            name = string.Empty;
        }

        public OrderDetails (int number,double price,string name)
        {
            this.number = number;
            this.price = price;
            this.name = name;
        }

        public double getPrice ()
        {
            return price * number;
        }


    }
}
