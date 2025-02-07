﻿// <auto-generated />
using System;
using Client.Infrastructure.DbContexts.Chunk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Client.Infrastructure.Migrations.FdmChunkDb
{
    [DbContext(typeof(FdmChunkDbContext))]
    partial class FdmChunkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Client.Domain.Entites.DownloadFileChunk", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("DownloadFileChunkStatus")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DownloadFileId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("End")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Start")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TempFilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DownloadFileChunks");
                });
#pragma warning restore 612, 618
        }
    }
}
