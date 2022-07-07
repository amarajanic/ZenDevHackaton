using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenDevAPI.Models
{
    public class LocationVM
    {
        public int ID { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string Name { get; set; }
    }
}
