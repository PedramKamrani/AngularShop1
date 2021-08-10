using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entites.Account
{
 public class UserRole
  {
    #region properties

    public int UserId { get; set; }

    public int RoleId { get; set; }

    #endregion

    #region Relations
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    #endregion
  }
}
