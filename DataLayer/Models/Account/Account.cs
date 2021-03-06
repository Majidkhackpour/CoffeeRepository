﻿using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enums;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Account;

namespace DataLayer.Models.Account
{
   public class Account:IAccount
    {
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public Guid GroupGuid { get; set; }
        public string DateSabt { get; set; }
        public decimal Amounth { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public AccountGroup AccountGroup { get; set; }
    }
}
