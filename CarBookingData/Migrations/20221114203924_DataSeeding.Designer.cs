// <auto-generated />
using System;
using CarBookingData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarBookingData.Migrations
{
    [DbContext(typeof(CarBookingDbContext))]
    [Migration("20221114203924_DataSeeding")]
    partial class DataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarBookingData.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RegnNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("MakeId");

                    b.HasIndex("StyleId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarBookingData.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            CreatedBy = "Sajesh",
                            CreatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1422),
                            MakeId = 4,
                            Name = "Jazz",
                            UpdatedBy = "Sajesh",
                            UpdatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1424)
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Sajesh",
                            CreatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1427),
                            MakeId = 5,
                            Name = "RX400",
                            UpdatedBy = "Sajesh",
                            UpdatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1429)
                        });
                });

            modelBuilder.Entity("CarBookingData.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            CreatedBy = "Sajesh",
                            CreatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1264),
                            Name = "Honda",
                            UpdatedBy = "Sajesh",
                            UpdatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1314)
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Sajesh",
                            CreatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1320),
                            Name = "Mercides",
                            UpdatedBy = "Sajesh",
                            UpdatedDate = new DateTime(2022, 11, 14, 20, 39, 24, 491, DateTimeKind.Local).AddTicks(1322)
                        });
                });

            modelBuilder.Entity("CarBookingData.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("CarBookingData.Car", b =>
                {
                    b.HasOne("CarBookingData.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBookingData.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBookingData.Style", "Style")
                        .WithMany("Cars")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("Make");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("CarBookingData.CarModel", b =>
                {
                    b.HasOne("CarBookingData.Make", "Make")
                        .WithMany("CarModels")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarBookingData.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBookingData.Make", b =>
                {
                    b.Navigation("CarModels");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBookingData.Style", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
