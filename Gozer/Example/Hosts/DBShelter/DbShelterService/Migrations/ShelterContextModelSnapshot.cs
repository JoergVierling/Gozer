﻿// <auto-generated />

using Gozer.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DbShelterService.Migrations
{
    [DbContext(typeof(ShelterContext))]
    partial class ShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbShelterImplementation.Service", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssambliQualifiedName");

                    b.Property<int>("Binding");

                    b.Property<string>("EndpointAdress");

                    b.Property<DateTime>("LastCall");

                    b.HasKey("Guid");

                    b.ToTable("Service");
                });
#pragma warning restore 612, 618
        }
    }
}
