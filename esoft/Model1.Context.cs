﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace esoft
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class eSoftEntities : DbContext
    {

        private static eSoftEntities _context;

        public eSoftEntities()
            : base("name=eSoftEntities")
        {
        }

        public static eSoftEntities GetContext()
        {
            if (_context == null)
            {
                _context = new eSoftEntities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Apartmens> Apartmens { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Demand> Demand { get; set; }
        public virtual DbSet<DemandApartments> DemandApartments { get; set; }
        public virtual DbSet<DemandHouse> DemandHouse { get; set; }
        public virtual DbSet<DemandLand> DemandLand { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<Land> Land { get; set; }
        public virtual DbSet<ObjectNmobles> ObjectNmobles { get; set; }
        public virtual DbSet<Realtor> Realtor { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeObjectNmobles> TypeObjectNmobles { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ListUsers> ListUsers { get; set; }
    }
}
