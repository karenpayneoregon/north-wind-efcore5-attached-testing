﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindEntityLocalData.Models;

#nullable disable

namespace NorthWindEntityLocalData.Data.Configurations
{
    public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> entity)
        {
            entity.HasKey(e => e.ContactId);

            entity.Property(e => e.ContactId).HasComment("Id");

            entity.Property(e => e.ContactTypeIdentifier).HasComment("Contact Type Id");

            entity.Property(e => e.FirstName).HasComment("First name");

            entity.Property(e => e.LastName).HasComment("Last name");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Contacts_ContactType");
        }
    }
}
