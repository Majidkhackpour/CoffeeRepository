using System;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Core.Anbar;

namespace PersitenceLayer.Persistance
{
    public class UnitOfWork : IDisposable
    {
        private ModelContext db = new ModelContext();
        private IHazineRepository _hazineRepository;
        private IKolRepository _kolRepository;
        private IHesabGroupRepository _hesabGroupRepository;
        private IMoeinRepository _moeinRepository;
        private IAccountRepository _accountRepository;
        private IAccountGroupRepository _accountGroupRepository;
        private IAnbarGroupRepository _anbarGroupRepository;
        private IAnbarRepository _anbarRepository;
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
        public IAnbarGroupRepository AnbarGroupRepository
        {
            get
            {
                if (_anbarGroupRepository == null)
                {
                    _anbarGroupRepository = new AnbarGroupPersistanceRepository(db);
                }

                return _anbarGroupRepository;
            }
        }
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
        public void Dispose()
        {
            db.Dispose();
        }

        public void Set_Save()
        {
            db.SaveChanges();
        }
    }
}
