using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessApplication.BL
{
    class Food
    {
        public string foodName;
        public float foodPrice;
        public Food()
        {

        }
        public Food(string name, float price)
        {
            foodName = name;
            foodPrice = price;
        }
    }
}
