using System;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Core.Anbar;
using DataLayer.Core.Bank;
using DataLayer.Core.Customer;
using DataLayer.Core.Perssonel;
using DataLayer.Core.PhoneBook;
using DataLayer.Core.Sandooq;
using DataLayer.Core.Sellers;

namespace PersitenceLayer.Persistance
{
    public class UnitOfWork : IDisposable
    {
        private readonly ModelContext db = new ModelContext();
        private IHazineRepository _hazineRepository;
        private IKolRepository _kolRepository;
        private IHesabGroupRepository _hesabGroupRepository;
        private IMoeinRepository _moeinRepository;
        private IAccountRepository _accountRepository;
        private IAccountGroupRepository _accountGroupRepository;
        private IAnbarGroupRepository _anbarGroupRepository;
        private IAnbarRepository _anbarRepository;
        private IAppSetting _appSetting;
        private IPerssonelGroupRepository _perssonelGroupRepository;
        private IPerssonelRepository _perssonelRepository;
        private IPhoneBookRepository _phoneBookRepository;
        private ISellerRpository _sellerRpository;
        private ICustomerGroupRepository _cusGroup;
        private ICustomersRepository _customers;
        private IBanksRepository _banks;
        private ISafeRepository _safe;

        public void Dispose()
        {
            db.Dispose();
        }

        public void Set_Save()
        {
            db.SaveChanges();
        }
        public IHazineRepository HazineRepository
        {
            get
            {
                if (_hazineRepository == null)
                {
                    _hazineRepository = new HazinePersistanceRepository(db);
                }

                return _hazineRepository;
            }
        }
        public IKolRepository KolRepository
        {
            get
            {
                if (_kolRepository == null)
                {
                    _kolRepository = new KolPersistanceRepository(db);
                }

                return _kolRepository;
            }
        }
        public IHesabGroupRepository HesabGroupRepository
        {
            get
            {
                if (_hesabGroupRepository == null)
                {
                    _hesabGroupRepository = new HesabGroupPersistanceRepository(db);
                }

                return _hesabGroupRepository;
            }
        }
        public IMoeinRepository MoeinRepository
        {
            get
            {
                if (_moeinRepository == null)
                {
                    _moeinRepository = new MoeinPersistenceRepository(db);
                }

                return _moeinRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountPersistanceRepository(db);
                }

                return _accountRepository;
            }
        }
        public IAccountGroupRepository AccountGroupRepository
        {
            get
            {
                if (_accountGroupRepository == null)
                {
                    _accountGroupRepository = new AccountGroupPersistanceRepository(db);
                }

                return _accountGroupRepository;
            }
        }

        public IAnbarGroupRepository AnbarGroupRepository =>
            _anbarGroupRepository ?? (_anbarGroupRepository = new AnbarGroupPersistanceRepository(db));

        public IAnbarRepository AnbarRepository
        {
            get
            {
                if (_anbarRepository == null)
                {
                    _anbarRepository = new AnbarPersistanceRepository(db);
                }

                return _anbarRepository;
            }
        }
        public IAppSetting AppSetting
        {
            get
            {
                if (_appSetting == null)
                {
                    _appSetting = new AppSettingPersistanceRepository(db);
                }

                return _appSetting;
            }
        }
        public IPerssonelGroupRepository PerssonelGroup
        {
            get
            {
                if (_perssonelGroupRepository == null)
                {
                    _perssonelGroupRepository = new PerssonelGroupPersistanceRepository(db);
                }

                return _perssonelGroupRepository;
            }
        }
        public IPerssonelRepository Perssonel
        {
            get
            {
                if (_perssonelRepository == null)
                {
                    _perssonelRepository = new PerssonelPersistanceRepository(db);
                }

                return _perssonelRepository;
            }
        }
        public IPhoneBookRepository PhoneBook
        {
            get
            {
                if (_phoneBookRepository == null)
                {
                    _phoneBookRepository = new PhoneBookPersistanceRepository(db);
                }

                return _phoneBookRepository;
            }
        }

        public ISellerRpository Seller => _sellerRpository ?? (_sellerRpository = new SellerPersistanceRepository(db));

        public ICustomerGroupRepository CusGroup =>
            _cusGroup ?? (_cusGroup = new CustomerGroupPersistanceRepository(db));

        public ICustomersRepository Customers => _customers ?? (_customers = new CutomersPersistanceRepository(db));
        public IBanksRepository Banks => _banks ?? (_banks = new BankPersistanceRepository(db));
        public ISafeRepository Safe => _safe ?? (_safe = new SafePersistanceRepository(db));
    }
}
