using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entites.Products
{
  public class ProductSelectedCategory:BaseEntity
  {
    #region Properties
   
    public int ProductId { get; set; }

    public int ProductCategoryId { get; set; }

    #endregion

    #region Relations

    public Product Product { get; set; }

    public ProductCategory ProductCategory { get; set; }

    #endregion
  }
}
