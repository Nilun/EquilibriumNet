﻿// <auto-generated />
using EquilibriumCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquilibriumCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190804162849_RulesTable")]
    partial class RulesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EquilibriumCore.Models.FeuillePersonnage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Acrobatics");

                    b.Property<int>("Athletism");

                    b.Property<int>("Body");

                    b.Property<int>("Bow");

                    b.Property<int>("Craft");

                    b.Property<int>("Elem");

                    b.Property<int>("Empath");

                    b.Property<int>("HPNow");

                    b.Property<int>("HPPerLevel");

                    b.Property<int>("History");

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

                    b.Property<int>("Speech");

                    b.Property<int>("Stealth");

                    b.Property<int>("Survival");

                    b.Property<int>("Throw");

                    b.Property<int>("TwoHand");

                    b.Property<string>("passive");

                    b.HasKey("ID");

                    b.ToTable("Feuilles");
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
#pragma warning restore 612, 618
        }
    }
}
