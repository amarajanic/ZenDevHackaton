using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZenDevLibrary.DbModels
{
    public class SubType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
    }
}
