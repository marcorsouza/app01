﻿// <auto-generated />
using System;
using App01.Model.Infra.Data.Context.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App01.Model.Infra.Data.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20190703005722_Add_Tabela_User")]
    partial class Add_Tabela_User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("App01.Model.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("App01.Model.Domain.Entities.User", b =>
                {
                    b.OwnsOne("App01.Model.Domain.ObjectValues.Authentication", "Authentication", b1 =>
                        {
                            b1.Property<int?>("UserId");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnName("User_Password")
                                .HasMaxLength(30);

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasColumnName("User_Username")
                                .HasMaxLength(40);

                            b1.ToTable("User");

                            b1.HasOne("App01.Model.Domain.Entities.User")
                                .WithOne("Authentication")
                                .HasForeignKey("App01.Model.Domain.ObjectValues.Authentication", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
