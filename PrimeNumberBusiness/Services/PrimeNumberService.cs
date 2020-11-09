
using Microsoft.EntityFrameworkCore;
using PrimeNumberBusiness.Interfaces;
using PrimeNumberCore.Exceptions;
using PrimeNumberCore.Extentions;
using PrimeNumberDomain.Context;
using PrimeNumberDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberBusiness.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        private readonly PrimeNumberContext _primeNumberContext;


        public PrimeNumberService(PrimeNumberContext primeNumberContext)
        {
            _primeNumberContext = primeNumberContext;
        }

        public async Task<int> GetPrimeNumberAsync(int index)
        {
            if (index <= 0)
            {
                throw new BusinessException("not valid index!");
            }
            else if (index == 1)
            {
                return await Task.FromResult(2);
            }

            var existingCalculation = await _primeNumberContext.PrimeNumberHistories.FirstOrDefaultAsync(x => x.Index == index);

            if (existingCalculation != null)
            {
                return await Task.FromResult(existingCalculation.PrimeNumber);
            }

            List<int> calculatedPrimeNumbers = new List<int> { 2 };

            for (int i = 3; ; i += 2)
            {
                if (i.IsPrime())
                {
                    calculatedPrimeNumbers.Add(i);
                }

                if(calculatedPrimeNumbers.Count == index)
                {

                    var primeNumber = new PrimeNumberHistory
                    {
                        Index = index,
                        PrimeNumber = i
                    };

                    _primeNumberContext.Add(primeNumber);
                    await _primeNumberContext.SaveChangesAsync();

                    break;
                }
            }

            return await Task.FromResult(calculatedPrimeNumbers.LastOrDefault());
        }
    }
}
