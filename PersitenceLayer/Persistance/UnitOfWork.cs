using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Core;

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
