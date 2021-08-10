using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entites.Products
{
 public class ProductGallery:BaseEntity
  {
    #region properties
    
    public int ProductId { get; set; }

    [Display(Name = "نام تصویر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
    public string ImageName { get; set; }

    #endregion

    #region relations
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    #endregion
  }
}
