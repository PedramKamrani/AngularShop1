using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entites.Products
{
  public class ProductCategory:BaseEntity
  {
    #region Properties
    public string Title { get; set; }

    public int? ParentId { get; set; }


    #endregion

    #region Relations

    [ForeignKey("ParentId")]
    public ProductCategory ParentCategory { get; set; }

    public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

    #endregion
  }
}
