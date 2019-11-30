using AutoMapper;
using BussinesLayer.AccountBussines;
using DataLayer.Models.Account;

namespace BussinesLayer
{
    public class SqlProfile:Profile
    {
        public SqlProfile()
        {
            CreateMap<Hazine, HazineBussines>();
            CreateMap<HazineBussines, Hazine>();
        }
    }
}
