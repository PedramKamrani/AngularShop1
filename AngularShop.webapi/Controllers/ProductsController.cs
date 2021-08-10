using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTOs.Product;
using ServicesLayer.Servicse.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesLayer.Uitelites.Comman;

namespace AngularShop.webapi.Controllers
{
 
  public class ProductsController : SiteController
  {
    #region Constracture

    private IProductService productService;

    public ProductsController(IProductService productService)
    {
      this.productService = productService;
    }

    #endregion

    #region products

    [HttpGet("filter-products")]
    public async Task<IActionResult> GetProducts([FromQuery] FilterProdcutsDTO filter)
    {
     
      var products = await productService.FilterProducts(filter);
      return JsonResponseStatus.Success(products);
    }

    #endregion
  }
}
