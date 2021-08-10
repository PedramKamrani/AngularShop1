using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Uitelites.Extinsion.Identity
{
  public static class IdentityUserExtention
  {
    public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
      if (claimsPrincipal != null)
      {
        var result = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
        return Convert.ToInt64(result.Value);
      }

      return default(long);
    }
  }
}
