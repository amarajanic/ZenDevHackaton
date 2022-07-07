using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZenDevLibrary.DbModels
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string Name { get; set; }
    }
}
