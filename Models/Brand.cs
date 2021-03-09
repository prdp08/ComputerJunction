using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerJunction.Models
{
    public class Brand //Model For Table Brand
    {
        public int ID { get; set; }//Primary Key For Brand Model
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }//Navigation Conected with Product Model

    }
}
