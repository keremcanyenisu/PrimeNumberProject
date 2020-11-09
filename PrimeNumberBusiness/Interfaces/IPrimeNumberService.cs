using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberBusiness.Interfaces
{
    public interface IPrimeNumberService
    {
        Task<int> GetPrimeNumberAsync(int index);
    }
}
