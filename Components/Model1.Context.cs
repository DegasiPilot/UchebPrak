﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchebPrak.Components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UchebPratika_Entities : DbContext
    {
        public UchebPratika_Entities()
            : base("name=UchebPratika_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Akademiki> Akademiki { get; set; }
        public virtual DbSet<cveti_VashaFamilia> cveti_VashaFamilia { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Engineer> Engineer { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }
        public virtual DbSet<Fakultet> Fakultet { get; set; }
        public virtual DbSet<Gimnazisty> Gimnazisty { get; set; }
        public virtual DbSet<Jivotnie_VashaFamilia> Jivotnie_VashaFamilia { get; set; }
        public virtual DbSet<Kafedra> Kafedra { get; set; }
        public virtual DbSet<Prepodavatel> Prepodavatel { get; set; }
        public virtual DbSet<Specialnost> Specialnost { get; set; }
        public virtual DbSet<strani> strani { get; set; }
        public virtual DbSet<Strani_VashaFamilia> Strani_VashaFamilia { get; set; }
        public virtual DbSet<strani2> strani2 { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ycheniki> ycheniki { get; set; }
        public virtual DbSet<ypravlenie> ypravlenie { get; set; }
        public virtual DbSet<Ypravlenie_VashaFamilia> Ypravlenie_VashaFamilia { get; set; }
        public virtual DbSet<Zav_Kafedra> Zav_Kafedra { get; set; }
        public virtual DbSet<Zayavka> Zayavka { get; set; }
        public virtual DbSet<Examen_Student> Examen_Student { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
    }
}
