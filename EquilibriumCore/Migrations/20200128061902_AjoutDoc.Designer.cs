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
    [Migration("20200128061902_AjoutDoc")]
    partial class AjoutDoc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EquilibriumCore.Models.Component", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Area");

                    b.Property<int>("Element");

                    b.Property<bool>("IsForm");

                    b.Property<string>("PriceString");

                    b.Property<int>("Range");

                    b.Property<string>("name");

                    b.Property<string>("text");

                    b.Property<string>("upgradesString");

                    b.Property<string>("valuesString");

                    b.HasKey("ID");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("EquilibriumCore.Models.FeuillePersonnage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Acrobatics");

                    b.Property<int>("Athletism");

                    b.Property<int>("Body");

                    b.Property<int>("Bow");

                    b.Property<int>("CraftB");

                    b.Property<int>("CraftM");

                    b.Property<int>("CraftS");

                    b.Property<int>("CraftSW");

                    b.Property<string>("Creator");

                    b.Property<int>("Elem");

                    b.Property<int>("Empath");

                    b.Property<int>("HPNow");

                    b.Property<int>("HPPerLevel");

                    b.Property<int>("History");

                    b.Property<int>("IDPartie");

                    b.Property<int>("Infusion");

                    b.Property<int>("Intimidation");

                    b.Property<int>("LOneHand");

                    b.Property<int>("Level");

                    b.Property<int>("MagicIdentif");

                    b.Property<int>("Medic");

                    b.Property<int>("MemoryBonus");

                    b.Property<int>("Metamagic");

                    b.Property<string>("Name");

                    b.Property<int>("Occult");

                    b.Property<int>("OneHand");

                    b.Property<int>("Parry");

                    b.Property<int>("Perception");

                    b.Property<int>("Primordial");

                    b.Property<string>("Race");

                    b.Property<int>("Resist");

                    b.Property<bool>("Shared");

                    b.Property<int>("Speech");

                    b.Property<int>("Stealth");

                    b.Property<string>("Stuff");

                    b.Property<int>("Survival");

                    b.Property<int>("Throw");

                    b.Property<int>("TwoHand");

                    b.Property<string>("comp");

                    b.Property<string>("passive");

                    b.Property<string>("skills");

                    b.HasKey("ID");

                    b.ToTable("Feuilles");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Partie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Joueurs");

                    b.Property<string>("MJ");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Partie");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Rules", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<bool>("IsTitle");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Skills", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Effect");

                    b.Property<string>("Ignore");

                    b.Property<string>("Name");

                    b.Property<string>("Tags");

                    b.Property<string>("cat");

                    b.Property<int>("levelMax");

                    b.Property<string>("superCat");

                    b.HasKey("ID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Spell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Element");

                    b.Property<int>("IDCaster");

                    b.Property<string>("IDComponents");

                    b.Property<int>("IDForm");

                    b.Property<string>("listID");

                    b.Property<string>("name");

                    b.HasKey("ID");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("EquilibriumCore.Models.SpellLinkComponent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComponentID");

                    b.Property<int?>("SpellID");

                    b.HasKey("ID");

                    b.HasIndex("ComponentID");

                    b.HasIndex("SpellID");

                    b.ToTable("SpellLinkComponent");
                });

            modelBuilder.Entity("EquilibriumCore.Models.Tooltiper", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("keyword");

                    b.Property<string>("tooltiptext");

                    b.HasKey("ID");

                    b.ToTable("Tooltiper");
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
