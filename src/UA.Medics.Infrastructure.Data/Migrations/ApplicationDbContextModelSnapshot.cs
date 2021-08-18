﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UA.Medics.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("UA.Medics.Domain.Doctor", b =>
                {
                    b.Property<int>("PartyTempId")
                        .HasColumnType("integer");

                    b.Property<Guid>("LegalEntityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EmployeeSpeciality")
                        .HasColumnType("text");

                    b.Property<Guid?>("LegalEntityDivisionId")
                        .HasColumnType("uuid");

                    b.Property<string>("PartyName")
                        .HasColumnType("text");

                    b.HasKey("PartyTempId", "LegalEntityId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("UA.Medics.Domain.LegalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CareType")
                        .HasColumnType("text");

                    b.Property<string>("Edrpou")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Lat")
                        .HasColumnType("text");

                    b.Property<string>("Lng")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PropertyType")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationAddresses")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationArea")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationSettlement")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LegalEntity");
                });

            modelBuilder.Entity("UA.Medics.Domain.LegalEntityDivision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Lat")
                        .HasColumnType("text");

                    b.Property<Guid>("LegalEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Lng")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceAddresses")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceArea")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceRegion")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceSettlement")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceSettlementKoatuu")
                        .HasColumnType("text");

                    b.Property<string>("ResidenceSettlementType")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LegalEntityDivision");
                });

            modelBuilder.Entity("UA.Medics.Domain.StatsByDoctorAge", b =>
                {
                    b.Property<DateTime>("StatsDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("LegalEntityId")
                        .HasColumnType("uuid");

                    b.Property<int>("PartyTempId")
                        .HasColumnType("integer");

                    b.Property<string>("PersonAgeGroup")
                        .HasColumnType("text");

                    b.Property<int>("CountDeclarations")
                        .HasColumnType("integer");

                    b.HasKey("StatsDate", "LegalEntityId", "PartyTempId", "PersonAgeGroup");

                    b.ToTable("StatsByDoctorAge");
                });
#pragma warning restore 612, 618
        }
    }
}
