﻿using System;
using System.Collections.Generic;
using BussinesLayer.AccountBussines;
using BussinesLayer.Anbar;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.BankHesab;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Banks
{
    public class BanksBussines : IBanks
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string HalfCode { get; set; }
        public string Name { get; set; }
        public EnumBankHesabType Type { get; set; }
        public string ShobeName { get; set; }
        public string ShobeCode { get; set; }
        public string HesabNumber { get; set; }
        public string DarandeName { get; set; }
        public bool Poss { get; set; }
        public string DateEftetah { get; set; }
        public decimal AmountAvalDore { get; set; }
        public Guid MoeinAmountAvalDore { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }


        public AccountBussines.AccountBussines Account
        {
            get
            {
                var account = AccountBussines.AccountBussines.Get(Guid) ?? new AccountBussines.AccountBussines();
                account.Guid = Guid;
                account.HesabType = HesabType.Bank;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = AccountGroupBussines.Get((int)HesabType.Bank).Guid;
                account.Half_Code = HalfCode;
                account.Name = Name;
                account.State = Status;
                return account;
            }
        }


        public static List<BanksBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.GetAll();
                return Mappings.Default.Map<List<BanksBussines>>(a);
            }
        }
        public static BanksBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.Get(guid);
                return Mappings.Default.Map<BanksBussines>(a);
            }
        }
        public bool Save()
        {
            var tran = new DataBaseManager();
            string TranName = "Tran" + System.Guid.NewGuid().ToString();
            try
            {
                using (var _context = new UnitOfWork())
                {
                    tran.BeginTransaction(TranName);
                    tran.CommitTransaction(TranName);
                    var b = Mappings.Default.Map<Account>(Account);
                    var resAccount = _context.AccountRepository.Save(b);
                    if (resAccount)
                    {
                        var a = Mappings.Default.Map<DataLayer.Models.BankHesab.Banks>(this);
                        var res = _context.Banks.Save(a);
                        _context.Set_Save();
                        _context.Dispose();
                    }

                    return true;
                }
            }
            catch (Exception exception)
            {
                tran.RollBackTransaction(TranName);
                return false;
            }
        }
        public static BanksBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.Change_Status(accGuid, status);
                return Mappings.Default.Map<BanksBussines>(a);
            }
        }
        public static List<BanksBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.Search(search);
                return Mappings.Default.Map<List<BanksBussines>>(a);
            }
        }
    }
}
