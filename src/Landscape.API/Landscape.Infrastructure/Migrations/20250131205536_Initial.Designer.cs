﻿// <auto-generated />
using System;
using Landscape.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Landscape.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250131205536_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Landscape.Domain.Landmark.Landmark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_landmarks");

                    b.ToTable("landmarks", (string)null);
                });

            modelBuilder.Entity("Landscape.Domain.Landmark.Landmark", b =>
                {
                    b.OwnsOne("Landscape.Domain.Entities.Coordinate", "Coordinate", b1 =>
                        {
                            b1.Property<Guid>("LandmarkId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double precision")
                                .HasColumnName("coordinate_latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double precision")
                                .HasColumnName("coordinate_longitude");

                            b1.HasKey("LandmarkId");

                            b1.ToTable("landmarks");

                            b1.WithOwner()
                                .HasForeignKey("LandmarkId")
                                .HasConstraintName("fk_landmarks_landmarks_id");
                        });

                    b.OwnsOne("Landscape.Domain.Landmark.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("LandmarkId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Park")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_park");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_state");

                            b1.HasKey("LandmarkId");

                            b1.ToTable("landmarks");

                            b1.WithOwner()
                                .HasForeignKey("LandmarkId")
                                .HasConstraintName("fk_landmarks_landmarks_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Coordinate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
