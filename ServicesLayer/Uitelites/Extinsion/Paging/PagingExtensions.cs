using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLayer.DTOs.Paging;

namespace ServicesLayer.Uitelites.Extinsion.Paging
{

    public static class PagingExtensions
    {
      public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging pager)
      {
        return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
      }
    }
  }

