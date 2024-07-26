using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppwithADO.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}