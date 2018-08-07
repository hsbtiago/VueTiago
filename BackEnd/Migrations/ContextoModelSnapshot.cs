﻿// <auto-generated />
using System;
using MeAluga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("MeAluga.Models.Aluguel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContratoId");

                    b.Property<DateTime?>("DataPagamento");

                    b.Property<decimal>("Valor");

                    b.Property<decimal?>("ValorPago");

                    b.Property<DateTime>("Vencimento");

                    b.Property<string>("observacao")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("MeAluga.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataRegistro");

                    b.Property<int?>("GarantiaId");

                    b.Property<int?>("ImovelId");

                    b.Property<DateTime>("Inicio");

                    b.Property<int?>("LocatarioId");

                    b.Property<string>("Observacao")
                        .HasMaxLength(300);

                    b.Property<DateTime>("Termino");

                    b.HasKey("Id");

                    b.HasIndex("GarantiaId");

                    b.HasIndex("ImovelId");

                    b.HasIndex("LocatarioId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("MeAluga.Models.Garantia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FiadorId");

                    b.Property<decimal?>("valorCaucao");

                    b.HasKey("Id");

                    b.HasIndex("FiadorId");

                    b.ToTable("Garantia");
                });

            modelBuilder.Entity("MeAluga.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataRegistro");

                    b.HasKey("Id");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("MeAluga.Models.Locatario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Locatarios");
                });

            modelBuilder.Entity("MeAluga.Models.Aluguel", b =>
                {
                    b.HasOne("MeAluga.Models.Contrato", "Contrato")
                        .WithMany("Alugueis")
                        .HasForeignKey("ContratoId");
                });

            modelBuilder.Entity("MeAluga.Models.Contrato", b =>
                {
                    b.HasOne("MeAluga.Models.Garantia", "Garantia")
                        .WithMany()
                        .HasForeignKey("GarantiaId");

                    b.HasOne("MeAluga.Models.Imovel", "Imovel")
                        .WithMany("Contratos")
                        .HasForeignKey("ImovelId");

                    b.HasOne("MeAluga.Models.Locatario", "Locatario")
                        .WithMany("Contratos")
                        .HasForeignKey("LocatarioId");
                });

            modelBuilder.Entity("MeAluga.Models.Garantia", b =>
                {
                    b.HasOne("MeAluga.Models.Locatario", "Fiador")
                        .WithMany()
                        .HasForeignKey("FiadorId");
                });

            modelBuilder.Entity("MeAluga.Models.Imovel", b =>
                {
                    b.OwnsOne("MeAluga.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ImovelId");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100);

                            b1.Property<string>("Estado")
                                .HasMaxLength(50);

                            b1.Property<string>("Numero")
                                .HasMaxLength(10);

                            b1.Property<string>("Rua")
                                .HasMaxLength(50);

                            b1.ToTable("Imoveis");

                            b1.HasOne("MeAluga.Models.Imovel")
                                .WithOne("Endereco")
                                .HasForeignKey("MeAluga.Models.Endereco", "ImovelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MeAluga.Models.Locatario", b =>
                {
                    b.OwnsOne("MeAluga.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("LocatarioId");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100);

                            b1.Property<string>("Estado")
                                .HasMaxLength(50);

                            b1.Property<string>("Numero")
                                .HasMaxLength(10);

                            b1.Property<string>("Rua")
                                .HasMaxLength(50);

                            b1.ToTable("Locatarios");

                            b1.HasOne("MeAluga.Models.Locatario")
                                .WithOne("Endereco")
                                .HasForeignKey("MeAluga.Models.Endereco", "LocatarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}