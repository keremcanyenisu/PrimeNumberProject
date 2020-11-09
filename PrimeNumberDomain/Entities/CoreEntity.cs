using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimeNumberDomain.Entities
{
    public class CoreEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
