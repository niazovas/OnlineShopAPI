using System;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Services.Contracts
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDto>> GetProducts();
		Task<ProductDto> GetProduct(int id);
        
    }
}

