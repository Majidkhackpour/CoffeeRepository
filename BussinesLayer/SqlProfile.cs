using AutoMapper;
using BussinesLayer.AccountBussines;
using BussinesLayer.Anbar;
using BussinesLayer.Customer;
using BussinesLayer.Perssonel;
using BussinesLayer.PhoneBook;
using BussinesLayer.Sellers;
using DataLayer.Models.Account;
using DataLayer.Models.Anbar;
using DataLayer.Models.Customer;
using DataLayer.Models.Perssonel;
using DataLayer.Models.Sellers;
using DataLayer.Models.Settings;

namespace BussinesLayer
{
    public class SqlProfile:Profile
    {
        public SqlProfile()
        {
            CreateMap<Hazine, HazineBussines>();
            CreateMap<HazineBussines, Hazine>();

            CreateMap<Account, AccountBussines.AccountBussines>();
            CreateMap<AccountBussines.AccountBussines, Account>();

            CreateMap<AccountGroupBussines, AccountGroup>();
            CreateMap<AccountGroup, AccountGroupBussines>();

            CreateMap<HesabGroupBussines, HesabGroup>();
            CreateMap<HesabGroup, HesabGroupBussines>();

            CreateMap<KolHesab, KolBussines>();
            CreateMap<KolBussines, KolHesab>();

            CreateMap<MoeinBussines, MoeinHesab>();
            CreateMap<MoeinHesab, MoeinBussines>();

            CreateMap<DataLayer.Models.Anbar.Anbar, AnbarBussines>();
            CreateMap<AnbarBussines, DataLayer.Models.Anbar.Anbar>();

            CreateMap<AnbarGroupBussines, AnbarGroup>();
            CreateMap<AnbarGroup, AnbarGroupBussines>();

            CreateMap<DataLayer.Models.Perssonel.Perssonel, PerssonelBussines>();
            CreateMap<PerssonelBussines, DataLayer.Models.Perssonel.Perssonel>();

            CreateMap<PerssonelGroupBussines, PerssonelGroup>();
            CreateMap<PerssonelGroup, PerssonelGroupBussines>();

            CreateMap<DataLayer.Models.PhoneBook.PhoneBook, PhoneBookBussines>();
            CreateMap<PhoneBookBussines, DataLayer.Models.PhoneBook.PhoneBook>();

            CreateMap<AppSettingBussines, AppSetting>();
            CreateMap<AppSetting, AppSettingBussines>();

            CreateMap<Seller, SellerBussines>();
            CreateMap<SellerBussines, Seller>();

            CreateMap<CustomerGroup, CustomerGroupBusiness>();
            CreateMap<CustomerGroupBusiness, CustomerGroup>();
        }
    }
}
