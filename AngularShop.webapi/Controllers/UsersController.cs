using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  ServicesLayer.Servicse.Interface;

namespace AngularShop.webapi.Controllers
{
  public class UsersController : SiteController
  {
    #region constructor

    private IUserService userService;

    public UsersController(IUserService userService)
    {
      this.userService = userService;
    }

    #endregion

    #region users list

    [HttpGet]
    public async Task<IActionResult> Users()
    {
      return new ObjectResult(await userService.GetAllUsers());
    }

    #endregion
  }
}
