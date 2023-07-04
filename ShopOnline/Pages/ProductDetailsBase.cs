using System;
using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Services.Contracts;

namespace ShopOnline.Pages
{
	public class ProductDetailsBase:ComponentBase
	{
		[Parameter]
		public int Id { get; set; }

		[Inject]
		public IProductService ProductService { get; set; }

		public ProductDto Product { get; set; }

		public string  ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
			try
			{
				Product = await ProductService.GetProduct(Id);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
        }


    }
}

