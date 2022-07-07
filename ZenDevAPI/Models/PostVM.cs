using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenDevAPI.Models
{
    public class PostVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int TypeID { get; set; }
        //public string Type { get; set; }
        public bool IsPositive { get; set; }
        public string File { get; set; }

        public int LocationID { get; set; }
    }
}
