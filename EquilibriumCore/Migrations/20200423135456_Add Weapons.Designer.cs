﻿// <auto-generated />
using System;
using EquilibriumCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquilibriumCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200423135456_Add Weapons")]
    partial class AddWeapons
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EquilibriumCore.Models.Attaque", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Portée")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Attaque");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Component", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<bool>("IsForm")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PriceString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("upgradesString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("valuesString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Document", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Price")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("typeEquipement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipement");
                });

            modelBuilder.Entity("EquilibriumCore.Models.FeuillePersonnage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Acrobatics")
                        .HasColumnType("int");

                    b.Property<int>("AnimalH")
                        .HasColumnType("int");

                    b.Property<int>("Art")
                        .HasColumnType("int");

                    b.Property<int>("Athletism")
                        .HasColumnType("int");

                    b.Property<int>("Body")
                        .HasColumnType("int");

                    b.Property<int>("Bow")
                        .HasColumnType("int");

                    b.Property<int>("CraftB")
                        .HasColumnType("int");

                    b.Property<int>("CraftM")
                        .HasColumnType("int");

                    b.Property<int>("CraftS")
                        .HasColumnType("int");

                    b.Property<int>("CraftSW")
                        .HasColumnType("int");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Disrupt")
                        .HasColumnType("int");

                    b.Property<int>("Elem")
                        .HasColumnType("int");

                    b.Property<int>("Empath")
                        .HasColumnType("int");

                    b.Property<int>("HPNow")
                        .HasColumnType("int");

                    b.Property<int>("HPPerLevel")
                        .HasColumnType("int");

                    b.Property<int>("History")
                        .HasColumnType("int");

                    b.Property<int>("IDPartie")
                        .HasColumnType("int");

                    b.Property<int>("Infusion")
                        .HasColumnType("int");

                    b.Property<int>("Intimidation")
                        .HasColumnType("int");

                    b.Property<int>("LOneHand")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MageWeap")
                        .HasColumnType("int");

                    b.Property<int>("MagicIdentif")
                        .HasColumnType("int");

                    b.Property<int>("Medic")
                        .HasColumnType("int");

                    b.Property<int>("MemoryBonus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Occult")
                        .HasColumnType("int");

                    b.Property<int>("OneHand")
                        .HasColumnType("int");

                    b.Property<int>("Parry")
                        .HasColumnType("int");

                    b.Property<int>("Perception")
                        .HasColumnType("int");

                    b.Property<int>("Primordial")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Resist")
                        .HasColumnType("int");

                    b.Property<int>("ShadowCraft")
                        .HasColumnType("int");

                    b.Property<bool>("Shared")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Speech")
                        .HasColumnType("int");

                    b.Property<int>("Stealth")
                        .HasColumnType("int");

                    b.Property<string>("Stuff")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Survival")
                        .HasColumnType("int");

                    b.Property<int>("Teaching")
                        .HasColumnType("int");

                    b.Property<int>("Throw")
                        .HasColumnType("int");

                    b.Property<int>("TwoHand")
                        .HasColumnType("int");

                    b.Property<string>("comp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("passive")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("skills")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Feuilles");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Modification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categorie")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("IDUpdate")
                        .HasColumnType("int");

                    b.Property<string>("SousCategorie")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TexteNew")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TexteOld")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Modification");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Partie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Joueurs")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MJ")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Partie");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Rules", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Skills", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ignore")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("cat")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("levelMax")
                        .HasColumnType("int");

                    b.Property<string>("superCat")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Spell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<int>("IDCaster")
                        .HasColumnType("int");

                    b.Property<string>("IDComponents")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IDForm")
                        .HasColumnType("int");

                    b.Property<string>("listID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("EquilibriumCore.Models.SpellLinkComponent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ComponentID")
                        .HasColumnType("int");

                    b.Property<int?>("SpellID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ComponentID");

                    b.HasIndex("SpellID");

                    b.ToTable("SpellLinkComponent");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Tooltiper", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("keyword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tooltiptext")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Tooltiper");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Update", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Sortie")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("Update");
                });

            modelBuilder.Entity("EquilibriumCore.Models.SpellLinkComponent", b =>
                {
                    b.HasOne("EquilibriumCore.Models.Component", "Component")
                        .WithMany("Links")
                        .HasForeignKey("ComponentID");

                    b.HasOne("EquilibriumCore.Models.Spell", "Spell")
                        .WithMany("LinkComponents")
                        .HasForeignKey("SpellID");
                });
#pragma warning restore 612, 618
        }
    }
}
