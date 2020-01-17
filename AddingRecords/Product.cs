using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingRecords
{
    public class Product
    {
        //declaration of local attributes
        private string StrProductCode;
        private string strDescription;
        private decimal decPrice;

        //constructor
        public Product() { }

        //assign properties to passed in values with the product class.
        public Product(string c, string d, decimal p)
        {
            ProdCode = c;
            Description = d;
            Price = p;
        }

        //declare properties
        public string ProdCode
        {
            get
            {
                return StrProductCode;
            }
            set
            {
                StrProductCode = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }
        public decimal Price
        {
            get
            {
                return decPrice;
            }
            set
            {
                decPrice = value;
            }
        }
    }
}
