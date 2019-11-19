using System;
using DataLayer.Models.Settings;

namespace DataLayer.Core
{
  public  interface IAppSetting:IRepository<AppSetting>
  {
      Guid GetLast();
  }
}
