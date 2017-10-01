using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccessMySqlProvider;

namespace OnatOctopusTest.Migrations
{
    [DbContext(typeof(DomainModelMySqlContext))]
    partial class DomainModelMySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("OnatOctopusTest.Models.Word", b =>
                {
                    b.Property<string>("Hashed")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Encrypted");

                    b.Property<int>("Frequency");

                    b.Property<string>("WordType");

                    b.HasKey("Hashed");

                    b.ToTable("Words");
                });
        }
    }
}
