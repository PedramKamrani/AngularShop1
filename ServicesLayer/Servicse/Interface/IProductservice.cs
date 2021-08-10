using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entites.Products;
using ServicesLayer.DTOs.Product;

namespace ServicesLayer.Servicse.Interface
{
    public interface IProductService : IDisposable
    {
    #region product

    Task<FilterProdcutsDTO> FilterProducts(FilterProdcutsDTO filter);

    #endregion
    }
}
