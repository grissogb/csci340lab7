using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTrees.Models
{
    public class Tree
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime PlantingDate { get; set; }
        public decimal Age { get; set; }
        public string Species { get; set; }
        public decimal Height { get; set; }
        public decimal Circumference { get; set; }



    }
}
