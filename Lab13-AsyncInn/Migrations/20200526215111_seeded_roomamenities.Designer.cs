﻿// <auto-generated />
using Lab13_AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab13_AsyncInn.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20200526215111_seeded_roomamenities")]
    partial class seeded_roomamenities
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "jacuzzi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ocean front view"
                        },
                        new
                        {
                            Id = 3,
                            Name = "bay view"
                        });
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

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = 0,
                            Name = "Single Seashell"
                        },
                        new
                        {
                            Id = 2,
                            Layout = 0,
                            Name = "Single Starfish"
                        },
                        new
                        {
                            Id = 3,
                            Layout = 1,
                            Name = "Double Turtle"
                        },
                        new
                        {
                            Id = 4,
                            Layout = 2,
                            Name = "Triple Hit"
                        },
                        new
                        {
                            Id = 5,
                            Layout = 3,
                            Name = "Four Coral"
                        },
                        new
                        {
                            Id = 6,
                            Layout = 4,
                            Name = "Five's Company"
                        });
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
