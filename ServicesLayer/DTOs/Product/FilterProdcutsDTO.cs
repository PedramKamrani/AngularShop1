using ServicesLayer.DTOs.Paging;
using System.Collections.Generic;

namespace ServicesLayer.DTOs.Product
{
  public class FilterProdcutsDTO : BasePaging
  {
  
    public string Title { get; set; }

    public int StartPrice { get; set; }

    public int EndPrice { get; set; }
    public List<DataLayer.Entites.Products.Product> Products { get; set; }

    public FilterProdcutsDTO SetPaging(BasePaging paging)
    {
      this.PageId = paging.PageId;
      this.PageCount = paging.PageCount;
      this.StartPage = paging.StartPage;
      this.EndPage = paging.EndPage;
      this.TakeEntity = paging.TakeEntity;
      this.SkipEntity = paging.SkipEntity;
      this.ActivePage = paging.ActivePage;
      return this;
    }

    public FilterProdcutsDTO SetProducts(List<DataLayer.Entites.Products.Product> products)
    {
      this.Products = products;
      return this;
    }

  }
}
