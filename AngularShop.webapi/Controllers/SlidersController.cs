using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Servicse.Implamtinan;
using ServicesLayer.Servicse.Interface;
using ServicesLayer.Uitelites.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AngularShop.webapi.Controllers
{
  public class SlidersController : SiteController
  {
    #region constructor

    private ISliderservice _sliderService;

    public SlidersController(SliderService sliderService)
    {
     _sliderService = sliderService;
    }

    #endregion

    #region all active sliders

    [HttpGet("GetActiveSliders")]
    
    public async Task<IActionResult> GetActiveSliders()
    {
      Thread.Sleep(1000);
      var sliders = await _sliderService.GetActiveSliders();

      return JsonResponseStatus.Success(sliders);
    }

    #endregion
  }
}
