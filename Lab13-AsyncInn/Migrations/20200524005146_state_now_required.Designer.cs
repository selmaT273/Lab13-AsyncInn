﻿// <auto-generated />
using System;
using Lab13_AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab13_AsyncInn.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20200524005146_state_now_required")]
    partial class state_now_required
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab13_AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Princess Royale",
                            State = "Maryland"
                        },
                        new
                        {
                            Id = 2,
                            Name = "The Carousel",
                            State = "Maryland"
                        });
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("money");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomId");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmenitiesId")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AmenitiesId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenitiesId");

                    b.HasIndex("AmenitiesId")
                        .IsUnique();

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Hotel", "Hotel")
                        .WithOne("HotelRoom")
                        .HasForeignKey("Lab13_AsyncInn.Models.HotelRoom", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab13_AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.Room", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Amenities", "Amenities")
                        .WithMany()
                        .HasForeignKey("AmenitiesId");
                });

            modelBuilder.Entity("Lab13_AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("Lab13_AsyncInn.Models.Amenities", "Amenities")
                        .WithOne("RoomAmenities")
                        .HasForeignKey("Lab13_AsyncInn.Models.RoomAmenities", "AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab13_AsyncInn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}