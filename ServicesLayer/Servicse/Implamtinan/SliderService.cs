using DataLayer.Entites.Sliders;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Servicse.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Servicse.Implamtinan
{
 public class SliderService:ISliderservice
  {
    #region constructor

    private IGenericRepository<Slider> _sliderRepository;

    public SliderService(IGenericRepository<Slider> sliderRepository)
    {
      _sliderRepository = sliderRepository;
    }

    #endregion

    #region slider

    public async Task<List<Slider>> GetAllSliders()
    {
      
      return await _sliderRepository.GetEntitiesQuery().ToListAsync();
    }

    public async Task<List<Slider>> GetActiveSliders()
    {
      return await _sliderRepository.GetEntitiesQuery().Where(s => !s.IsDelete).ToListAsync();
    }

    public async Task AddSlider(Slider slider)
    {
      await _sliderRepository.AddEntity(slider);
       _sliderRepository.SaveChanges();
    }

    public async Task UpdateSlider(Slider slider)
    {
      _sliderRepository.UpdateEntity(slider);
       _sliderRepository.SaveChanges();
    }

    public async Task<Slider> GetSliderById(long sliderId)
    {
      return await _sliderRepository.GetEntityById(sliderId);
    }

    #endregion

    #region dispose

    public void Dispose()
    {
      _sliderRepository?.Dispose();
    }

    #endregion
  }
}
