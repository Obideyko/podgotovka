﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectPodgotovka
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PodgotovkaBaseEntities : DbContext
    {
        private static PodgotovkaBaseEntities _context;
        public PodgotovkaBaseEntities()
            : base("name=PodgotovkaBaseEntities")
        {
        }

        public static PodgotovkaBaseEntities GetContext()
        {
            if (_context == null)
                _context = new PodgotovkaBaseEntities();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Emloyees> Emloyees { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
    }
}
