using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        //id

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        //forign keys
        public int BrandId { get; set; }
        public int TypeId { get; set; }

        //navigation properties
        public ProductBrand ProductBrand { get; set; }

        public ProductType ProductType { get; set; }



    }
}
