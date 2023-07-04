using System;
using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Pages
{
	public class DisplayProductBase:ComponentBase
	{
		[Parameter]
		public IEnumerable<ProductDto> Products { get; set; }
	
	}
}

