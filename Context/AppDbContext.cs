﻿using LanchesMacDotnet6MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMacDotnet6MVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
         
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Lanche> Lanches { get; set; }
    }
}
