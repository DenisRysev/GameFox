﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameFox
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FoxingEntities2 : DbContext
    {
        public FoxingEntities2()
            : base("name=FoxingEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Жанр> Жанр { get; set; }
        public virtual DbSet<Заявка> Заявка { get; set; }
        public virtual DbSet<Игра> Игра { get; set; }
        public virtual DbSet<Игротека> Игротека { get; set; }
        public virtual DbSet<Категории> Категории { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Список> Список { get; set; }
        public virtual DbSet<Тематика> Тематика { get; set; }
        public virtual DbSet<Тип_пользователя> Тип_пользователя { get; set; }
        public virtual DbSet<Турнир> Турнир { get; set; }
    }
}
