using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerJunction.Models
{
    public class Product//Model For Product
    {
        public int ID { get; set; }//Primary Key For Product Model
        public int BrandID { get; set; }//Id Which Connected With Brand Model
        public Brand Brand { get; set; }// Brand Attribute Which Come from Brand table
        public string name { get; set; }
        public int price { get; set; }
        public string Size { get; set; }

    }
}

