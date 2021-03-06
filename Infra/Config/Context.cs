﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infra.Config
{
    public class Context : DbContext
    {
        private IConfiguration _configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(RetornarUrlDaConexao());
        }

        public Context(DbContextOptions<Context> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }

        public string RetornarUrlDaConexao()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
