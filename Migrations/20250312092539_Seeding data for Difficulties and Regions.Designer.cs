﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZRegionWalksAPI.Data;

#nullable disable

namespace NZRegionWalksAPI.Migrations
{
    [DbContext(typeof(NZRegionWalksDbContext))]
    [Migration("20250312092539_Seeding data for Difficulties and Regions")]
    partial class SeedingdataforDifficultiesandRegions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZRegionWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09acb658-9fb7-4cb9-a2cc-507236c088f4"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("4c736a86-7e36-4ad5-b228-f807d8cddd33"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("c7656a0a-8d3a-459f-8f54-fdfca219afb0"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZRegionWalksAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0126ad40-97c6-4082-8b2f-0088a644156c"),
                            Code = "AUK",
                            Name = "Auckland",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/auckland/auckland-region.jpg"
                        },
                        new
                        {
                            Id = new Guid("071f8490-aa7c-47e7-9313-2bd79a5542de"),
                            Code = "WLG",
                            Name = "Wellington",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/wellington/wellington-region.jpg"
                        },
                        new
                        {
                            Id = new Guid("2ff92ecb-1eba-4424-9f5c-f5a8361ddb5c"),
                            Code = "CAN",
                            Name = "Canterbury",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/canterbury/canterbury-region.jpg"
                        },
                        new
                        {
                            Id = new Guid("41981686-7482-4c4a-9dd9-5125868a25cf"),
                            Code = "OTA",
                            Name = "Otago",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/otago/otago-region.jpg"
                        },
                        new
                        {
                            Id = new Guid("7754f540-1fe9-4e27-aa90-08af22acb110"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/southland/southland-region.jpg"
                        },
                        new
                        {
                            Id = new Guid("a4a43444-236e-4a70-9c6a-5f5dd75966b4"),
                            Code = "WKO",
                            Name = "Waikato",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/regions/waikato/waikato-region.jpg"
                        });
                });

            modelBuilder.Entity("NZRegionWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZRegionWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZRegionWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZRegionWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
