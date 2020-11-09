using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberDomain.Entities
{
    public class PrimeNumberHistory:CoreEntity
    {
        public int Index { get; set; }

        public int PrimeNumber { get; set; }
    }
}
