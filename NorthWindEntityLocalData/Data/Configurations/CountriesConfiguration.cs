﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindEntityLocalData.Models;

#nullable disable

namespace NorthWindEntityLocalData.Data.Configurations
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> entity)
        {
            entity.HasKey(e => e.CountryIdentifier);
        }
    }
}