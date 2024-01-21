﻿// <auto-generated />
using System;
using GrWhoisApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrWhoisApi.Migrations
{
    [DbContext(typeof(WhoisContext))]
    [Migration("20230521205552_AddSnapshotIsRegisteredProperty")]
    partial class AddSnapshotIsRegisteredProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4", DelegationModes.ApplyToAll);

            modelBuilder.Entity("GrWhoisApi.Models.Address", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<string>("Ip")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("longtext")
                        .HasColumnName("ip")
                        .HasComputedColumnSql("INET6_NTOA(ip_raw)");

                    b.Property<byte[]>("IpRaw")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("ip_raw");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("IpRaw")
                        .IsUnique();

                    b.ToTable("address");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Domain", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expiration");

                    b.Property<string>("Handle")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("handle");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("ProtocolNumber")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("protonum");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Handle")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("domain");
                });

            modelBuilder.Entity("GrWhoisApi.Models.DomainAddress", b =>
                {
                    b.Property<uint>("DomainId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("domain_id");

                    b.Property<uint>("AddressId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("DomainId", "AddressId", "CreatedAt");

                    b.HasIndex("AddressId");

                    b.ToTable("rel_domain_address");
                });

            modelBuilder.Entity("GrWhoisApi.Models.NameServer", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("nameserver");
                });

            modelBuilder.Entity("GrWhoisApi.Models.NameServerAddress", b =>
                {
                    b.Property<uint>("NameServerId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("nameserver_id");

                    b.Property<uint>("AddressId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("NameServerId", "AddressId", "CreatedAt");

                    b.HasIndex("AddressId");

                    b.ToTable("rel_nameserver_address");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Registrar", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.Property<string>("Url")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("registrar");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Snapshot", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("created_at");

                    b.Property<uint>("DomainId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("domain_id");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_registered");

                    b.Property<uint?>("RegistrarId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("registrar_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("RegistrarId");

                    b.ToTable("snapshot");
                });

            modelBuilder.Entity("GrWhoisApi.Models.SnapshotNameServer", b =>
                {
                    b.Property<uint>("SnapshotId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("snapshot_id");

                    b.Property<uint>("NameServerId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("nameserver_id");

                    b.HasKey("SnapshotId", "NameServerId");

                    b.HasIndex("NameServerId");

                    b.ToTable("rel_snapshot_nameserver");
                });

            modelBuilder.Entity("GrWhoisApi.Models.DomainAddress", b =>
                {
                    b.HasOne("GrWhoisApi.Models.Address", "Address")
                        .WithMany("DomainAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrWhoisApi.Models.Domain", null)
                        .WithMany("DomainAddresses")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("GrWhoisApi.Models.NameServerAddress", b =>
                {
                    b.HasOne("GrWhoisApi.Models.Address", "Address")
                        .WithMany("NameServerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrWhoisApi.Models.NameServer", null)
                        .WithMany("NameServerAddresses")
                        .HasForeignKey("NameServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Snapshot", b =>
                {
                    b.HasOne("GrWhoisApi.Models.Domain", "Domain")
                        .WithMany("Snapshots")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrWhoisApi.Models.Registrar", "Registrar")
                        .WithMany("Snapshots")
                        .HasForeignKey("RegistrarId");

                    b.Navigation("Domain");

                    b.Navigation("Registrar");
                });

            modelBuilder.Entity("GrWhoisApi.Models.SnapshotNameServer", b =>
                {
                    b.HasOne("GrWhoisApi.Models.NameServer", null)
                        .WithMany("SnapshotNameServers")
                        .HasForeignKey("NameServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrWhoisApi.Models.Snapshot", null)
                        .WithMany("SnapshotNameServers")
                        .HasForeignKey("SnapshotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrWhoisApi.Models.Address", b =>
                {
                    b.Navigation("DomainAddresses");

                    b.Navigation("NameServerAddresses");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Domain", b =>
                {
                    b.Navigation("DomainAddresses");

                    b.Navigation("Snapshots");
                });

            modelBuilder.Entity("GrWhoisApi.Models.NameServer", b =>
                {
                    b.Navigation("NameServerAddresses");

                    b.Navigation("SnapshotNameServers");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Registrar", b =>
                {
                    b.Navigation("Snapshots");
                });

            modelBuilder.Entity("GrWhoisApi.Models.Snapshot", b =>
                {
                    b.Navigation("SnapshotNameServers");
                });
#pragma warning restore 612, 618
        }
    }
}
