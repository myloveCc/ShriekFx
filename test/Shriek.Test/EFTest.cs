﻿using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Shriek.Utils;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shriek.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shriek.Test
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void TestDbContext()
        {
            var services = new ServiceCollection();

            var connectionStringBuilder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder { DataSource = "test.db" };
            var connectionString = connectionStringBuilder.ToString();

            services.AddDbContext<testDbContext>(options =>
                options.UseSqlite(connectionString));

            var container = services.BuildServiceProvider();
            var context = container.GetService<testDbContext>();

            Assert.IsNotNull(context);
        }
    }

    public class testDbContext : BaseDbContext
    {
        public testDbContext(DbContextOptions<testDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbContextOptionsBuilder builder { get; private set; }

        public DbSet<testEntity1> testEntity1 { get; set; }

        public DbSet<testEntity2> testEntity2 { get; set; }
    }

    public class testEntity1
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class testEntity2
    {
        [Key]
        public int Id { get; set; }
    }

    public class testEntity1Map : IEntityTypeConfiguration<testEntity1>
    {
        public void Configure(EntityTypeBuilder<testEntity1> builder)
        {
            builder.Property(c => c.Name)
                 .HasColumnName("testName");
        }
    }
}