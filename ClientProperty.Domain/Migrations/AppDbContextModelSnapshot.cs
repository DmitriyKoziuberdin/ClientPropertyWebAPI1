﻿// <auto-generated />
using System;
using ClientProperty.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientProperty.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientProperty.Domain.Entities.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("CurrentValue")
                        .HasColumnType("double precision")
                        .HasColumnName("current_value");

                    b.Property<int>("DaysOfPropertyOwnership")
                        .HasColumnType("integer")
                        .HasColumnName("days_of_property_ownership");

                    b.Property<double>("InitialValue")
                        .HasColumnType("double precision")
                        .HasColumnName("initial_value");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PriceLossPeriod")
                        .HasColumnType("text")
                        .HasColumnName("price_loss_period");

                    b.Property<double>("PriceLossSelectedPeriod")
                        .HasColumnType("double precision")
                        .HasColumnName("price_loss_selected_period");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("purchase_date");

                    b.Property<string>("TypeOfProperty")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type_of_property");

                    b.HasKey("Id")
                        .HasName("pk_properties");

                    b.ToTable("properties", (string)null);
                });

            modelBuilder.Entity("ClientProperty.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<double>("CurrentSumOfUserProperty")
                        .HasColumnType("double precision")
                        .HasColumnName("current_sum_of_user_property");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<double>("InitialSumOfUserProperty")
                        .HasColumnType("double precision")
                        .HasColumnName("initial_sum_of_user_property");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<string>("Telephone")
                        .HasColumnType("text")
                        .HasColumnName("telephone");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ClientProperty.Domain.Entities.UserProperty", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint")
                        .HasColumnName("property_id");

                    b.HasKey("UserId", "PropertyId")
                        .HasName("pk_user_property");

                    b.HasIndex("PropertyId")
                        .HasDatabaseName("ix_user_property_property_id");

                    b.ToTable("user_property", (string)null);
                });

            modelBuilder.Entity("ClientProperty.Domain.Entities.UserProperty", b =>
                {
                    b.HasOne("ClientProperty.Domain.Entities.Property", "Property")
                        .WithMany("UserProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_property_properties_property_id");

                    b.HasOne("ClientProperty.Domain.Entities.User", "User")
                        .WithMany("UserProperties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_property_users_user_id");

                    b.Navigation("Property");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientProperty.Domain.Entities.Property", b =>
                {
                    b.Navigation("UserProperties");
                });

            modelBuilder.Entity("ClientProperty.Domain.Entities.User", b =>
                {
                    b.Navigation("UserProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
