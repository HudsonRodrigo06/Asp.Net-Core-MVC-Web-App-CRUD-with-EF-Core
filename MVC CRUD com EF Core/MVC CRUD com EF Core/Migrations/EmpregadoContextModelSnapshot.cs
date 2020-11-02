﻿// <auto-generated />
using MVC_CRUD_com_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_CRUD_com_EF_Core.Migrations
{
    [DbContext(typeof(EmpregadoContext))]
    partial class EmpregadoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVC_CRUD_com_EF_Core.Models.Empregado", b =>
                {
                    b.Property<int>("EmpregadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("EmpCode")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LocalTrabalho")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("EmpregadoId");

                    b.ToTable("Empregados");
                });
#pragma warning restore 612, 618
        }
    }
}
