namespace ServicesLayer.DTOs.Paging
{
  public static class Pager
  {
    public static BasePaging Build(int pagecount, int pagenumber, int take)
    {
      if (pagenumber <= 1)
        pagenumber = 1;
      return new BasePaging
      {
        PageId=pagenumber,
        ActivePage=pagenumber,
        PageCount=pagecount,
        StartPage=pagenumber-3<=0?1:pagenumber-3,
        EndPage=pagenumber+3>pagecount?pagecount:pagenumber+3,
        SkipEntity=(pagenumber-1)*take,
        TakeEntity=take,
      };
    }
  }
}
