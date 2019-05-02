using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Services.Interfaces
{
    public interface IPricesService
    {
        Task<IActionResult> GetPricesAsync(int productId);
    }
}
