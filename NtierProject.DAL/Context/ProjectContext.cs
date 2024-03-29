﻿using NtierProject.Core.Entity;
using NtierProject.Map.Option;
using NtierProject.Model.Option;
using NtierProject.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NtierProject.DAL.Context
{
    public class ProjectContext:DbContext
    {
       
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-KRQ3ET7\SQLEXPRESS;Database=NtierProject;Trusted_Connection=True;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            string identity = WindowsIdentity.GetCurrent().Name;
            string computername = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string GetIp = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item.State==EntityState.Added)
                {
                    entity.CreatedUserName = identity;
                    entity.CreatedComputerName = computername;
                    entity.CreateDate = dateTime;
                    entity.CreatedIP = GetIp;
                }
                else if (item.State==EntityState.Modified)
                {
                    entity.ModifiedUserName = identity;
                    entity.ModifiedComputerName = computername;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedIP = GetIp;
                }
            }

            return base.SaveChanges();

        }
    }
}
