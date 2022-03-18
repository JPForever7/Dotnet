using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    interface IOrderService
    {
        void addOrder();
        void deleteOrder();
        void changeOrder();
        void searchOrder(int i);
        void showAllOrder();  
    }
}
