using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entites.Products;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.DTOs.Paging;
using ServicesLayer.DTOs.Product;
using ServicesLayer.Servicse.Interface;
using ServicesLayer.Uitelites.Extinsion.Paging;

namespace ServicesLayer.Servicse.Implamtinan
{
  public class ProductService : IProductService
  {
    #region constructor

    private IGenericRepository<Product> productRepository;
    private IGenericRepository<ProductCategory> productCategoryRepository;
    private IGenericRepository<ProductGallery> productGalleryRepository;
    private IGenericRepository<ProductSelectedCategory> productSelectedCategoryRepository;
    private IGenericRepository<ProductVisit> productVisitRepository;
    public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository, IGenericRepository<ProductGallery> productGalleryRepository, IGenericRepository<ProductSelectedCategory> productSelectedCategoryRepository, IGenericRepository<ProductVisit> productVisitRepository)
    {
      this.productRepository = productRepository;
      this.productCategoryRepository = productCategoryRepository;
      this.productGalleryRepository = productGalleryRepository;
      this.productSelectedCategoryRepository = productSelectedCategoryRepository;
      this.productVisitRepository = productVisitRepository;
    }

    #endregion

    #region product

    public async Task<FilterProdcutsDTO> FilterProducts(FilterProdcutsDTO filter)
    {
      var productsQuery = productRepository.GetEntitiesQuery().AsQueryable();

      if (!string.IsNullOrEmpty(filter.Title))
       // productsQuery = productsQuery.Where(s => s.ProductName.Where(a=>EF.Functions.Like(a.p,filter.Title));
        productsQuery = productsQuery.Where(s => s.ProductName.Contains(filter.Title));

      productsQuery = productsQuery.Where(s => s.Price >= filter.StartPrice && s.Price <= filter.EndPrice);

      var count = (int)Math.Ceiling(productsQuery.Count() / (double)filter.TakeEntity);

      var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

      var products = await productsQuery.Paging(pager).ToListAsync();

      return filter.SetProducts(products).SetPaging(pager);
    }
    #endregion
    #region dispose

    public void Dispose()
    {
      productRepository?.Dispose();
      productCategoryRepository?.Dispose();
      productGalleryRepository?.Dispose();
      productSelectedCategoryRepository?.Dispose();
      productVisitRepository?.Dispose();
    }

    #endregion
  }
}
