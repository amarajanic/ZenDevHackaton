using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZenDevLibrary.DbModels
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Datum { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPositive { get; set; }
        public string File { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
