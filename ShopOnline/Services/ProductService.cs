using System;
using System.Net.Http.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Services.Contracts;

namespace ShopOnline.Services
{
	public class ProductService:IProductService
	{
		private readonly HttpClient httpClient;
		public ProductService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

     public async Task<IEnumerable<ProductDto>> GetProducts()
        {
			try
			{
				var response= await this.httpClient.GetAsync("api/Product");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
						return Enumerable.Empty<ProductDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }

			catch (Exception )
			{
				throw;
			}
        }


        public async Task<ProductDto> GetProduct(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Product/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }



    }
}

