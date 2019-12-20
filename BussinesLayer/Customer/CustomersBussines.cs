﻿using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Customer;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Customer
{
    public class CustomersBussines : ICustomers
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public decimal Amount_AvalDore { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Guid GroupGuid { get; set; }
        public string HesabNumber1 { get; set; }
        public string HesabNumber2 { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
        public SellerType Type { get; set; }
        public string CompanyName { get; set; }
        public string ShomareSabt { get; set; }
        public string EconomyNumber { get; set; }
        public string Job { get; set; }
        public decimal HadeEtebar { get; set; }
        public string DateBirth { get; set; }
        public string NahveAshnaei { get; set; }
        public string SubCode { get; set; }
        public int ClubPoint { get; set; }
        public PayType PayType { get; set; }


        public static List<CustomersBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.GetAll();
                return Mappings.Default.Map<List<CustomersBussines>>(a);
            }
        }
        public static CustomersBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.Get(guid);
                return Mappings.Default.Map<CustomersBussines>(a);
            }
        }
    }
}