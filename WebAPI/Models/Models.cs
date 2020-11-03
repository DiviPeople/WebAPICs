using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public long Inn { get; set; }
        public bool Type { get; set; } // если юрюлицо true
        public string Shifer { get; set; }
        public DateTime Data { get; set; }
    }

    public class Agreement
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }
        public DateTime DataOpen { get; set; }
        public DateTime DataClose { get; set; }

        // Foreign key
        public int PersonId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string StatusAggrement { get; set; }
    }

    public class Type
    {
        public int Id { get; set; }

        [Required]
        public string TypeAggrement { get; set; }
    }
}
