using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }

        public string UserID { get; set; }
    }
}
