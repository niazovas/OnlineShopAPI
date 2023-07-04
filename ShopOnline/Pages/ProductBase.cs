using System;
using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Services;
using ShopOnline.Services.Contracts;

namespace ShopOnline.Pages
{
	public class ProductBase:ComponentBase
	{
		[Inject]

		public IProductService ProductService { get; set; }

		public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProducts();
            
        }
        protected IOrderedEnumerable<IGrouping<int,ProductDto>> GetGroupedProductsCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;

        }
        protected string GetCategoryName(IGrouping<int,ProductDto> groupedProductsDtos)
        {
            return groupedProductsDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductsDtos.Key).CategoryName;
        }
    }
}

