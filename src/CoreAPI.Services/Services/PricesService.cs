using CoreAPI.Data.Models;
using CoreAPI.Data.Repositories;
using CoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SpeedUpCoreAPIExample.CoreAPI.APIModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Services.Services
{
    public class PricesService: IPricesService
    {
        private readonly IPricesRepository _pricesRepository;

        public PricesService(IPricesRepository pricesRepository)
        {
            _pricesRepository = pricesRepository;
        }

        public async Task<IActionResult> GetPricesAsync(int productId)
        {
            try
            {
                IEnumerable<Price> pricess = await _pricesRepository.GetPricesAsync(productId);

                if (pricess != null)
                {
                    return new OkObjectResult(pricess.Select(p => new PriceViewModel()
                    {
                        Price = p.Value,
                        Supplier = p.Supplier
                    }
                    )
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.Supplier)
                    );
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }
    }
}
