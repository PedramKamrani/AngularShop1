using DataLayer.Entites.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Servicse.Interface
{
 public interface ISliderservice:IDisposable
  {
    Task<List<Slider>> GetAllSliders();
    Task<List<Slider>> GetActiveSliders();
    Task AddSlider(Slider slider);
    Task UpdateSlider(Slider slider);
    Task<Slider> GetSliderById(long sliderId);
  }
}
