using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App01.Model.Domain.Entities;
using App01.Model.Domain.ObjectValues;

namespace App01.Model.Infra.Data.Mappings.EF
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            //builder.Property(c => c.Username)                .IsRequired()                .HasColumnName("Username");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Active)
                .IsRequired()
                .HasColumnName("Active");

           builder.OwnsOne(m => m.Authentication, a =>
            {
                a.Property(p => p.Username).HasMaxLength(40)
                    .HasColumnName("Username")
                    .IsRequired();
                a.Property(p => p.Password).HasMaxLength(30)
                    .HasColumnName("Password")
                    .IsRequired();
            });
        }
    }
}