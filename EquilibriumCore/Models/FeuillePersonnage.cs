using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EquilibriumCore.Models
{
    public class FeuillePersonnage
    {
        [Key] public int ID { get; set; }
        public string Creator { get; set; }
        public bool Shared { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }
        public int Level { get; set; } = 1;
        public int HPPerLevel { get; set; } = 3;
        public int HPNow { get; set; } = 0;
        [NotMapped] public int HPMax { get => 10 + Level * HPPerLevel + Body * 5; }
        public int MemoryBonus { get; set; }
        [NotMapped] public int Memory { get => (int)Math.Truncate((double)(3 + Level / 2)) + MemoryBonus; }
        
        //5 + (int)Math.Truncate((double)((Level - 1) / 2))
        public int SkillPoint { get => getSkillPoint(); }
        public int ClassPoint { get => getClassPoint(); }

        public int OneHand { get; set; }
        public int LOneHand { get; set; }
        public int TwoHand { get; set; }
        public int Throw { get; set; }
        public int Bow { get; set; }
        public int Body { get; set; }
        public int Parry { get; set; }

        public int Elem { get; set; }
        public int Occult { get; set; }
        public int Primordial { get; set; }
      //  public int Metamagic { get; set; }
        public int Infusion { get; set; }
        public int Resist { get; set; }
        public int MagicIdentif { get; set; }

        public int Stealth { get; set; }
        public int Survival { get; set; }
        public int Perception { get; set; }
        public int Speech { get; set; }
        public int History { get; set; }
        public int Medic { get; set; }
        public int Empath { get; set; }
        public int Athletism { get; set; }
        public int Acrobatics { get; set; }

        public int CraftB { get; set; }
        public int CraftSW { get; set; }
        public int CraftS { get; set; }
        public int CraftM { get; set; }

        public int Intimidation { get; set; }

        public int Art { get; set; }
        public int ShadowCraft { get; set; }
        public int Disrupt { get; set; }
        public int Teaching { get; set; }
        public int AnimalH { get; set; }
        public int MageWeap { get; set; }


        public int Brutality { get => 1 + TwoHand + Bow + Primordial + Athletism + CraftB + Intimidation+ Disrupt; }
        public int Swiftness { get => 1 + OneHand  + MagicIdentif + Survival + Empath + CraftSW + Art+ MageWeap; }
        public int Spirit { get => 1 + Elem + Infusion + Perception + History + Medic + CraftS+ AnimalH+ Teaching; }
        public int Malice { get => 1 + LOneHand + Occult + Stealth + Speech + Throw + CraftM+ ShadowCraft; }
        public int Vitality { get => 1 + Parry + Body + Resist + Acrobatics; }

        public string passive { get; set; }
        public string Stuff { get; set; }
        public string skills { get; set; }
        public string comp { get; set; }


        public int IDPartie { get; set; }

        public DateTime LastUpdate { get; set; }
        int LinkedDocument { get; set; }
        [NotMapped] public string partie { get; set; }
        [NotMapped] public int  Initiative { get => Malice + Swiftness;}

        [NotMapped] public bool openSpells { get; set; } = false;

        [NotMapped] public bool showHidable { get; set; } = true;
        [NotMapped] public List<Partie> partiePossible = new List<Partie>();
        [NotMapped] public List<Spell> Spells { get; set; } = new List<Spell>();
        [NotMapped] public List<Tooltiper> tipspells { get; set; } = new List<Tooltiper>();
        [NotMapped] public List<Skills> ListSkills { get; set; } = new List<Skills>();
        [NotMapped] public List<Attaque> ListAttaques { get; set; } = new List<Attaque>();

        public FeuillePersonnage ()
        {
            Level = 1;
        }
        public void calculateLevelOfSkills()
        {
            var tempList = ListSkills;
            List<Skills> nList = new List<Skills>();
            foreach (Skills s in tempList.Distinct())
            {
                Skills ns = s;
                ns.CurrentLevel = tempList.Count((a)=>a.Name==s.Name);
                nList.Add(ns);
            }
            ListSkills = nList;
        }

        public int getClassPoint()
        {
            int result = 2;
            for (int i = 1; i <= Level; i++)
            {
                if((i%5)==0)
                {
                    result += 2;
                }else
                {
                    result += i % 2 == 0 ? 1 : 0;
                }

            }
            return result;
        }

        public int getSkillPoint()
        {
            int result = 0;
            for (int i = 1; i <= Level; i++)
            {
                if (i==1)
                {
                    result += 5;
                }
                else
                {
                    if ((i%5)==0)
                    {
                        result += 2;
                    }
                    else if ((i % 2) > 0)
                    {
                        result += 1;
                    }
                    
                }
            }
            return result;
        }
        public string InsertTooltip(string value)
        {

           

            string result = "";
            string[] working_array = value.Split(" ");

            foreach (string item in working_array)
            {
                Tooltiper tp = tipspells.FirstOrDefault(t => t.keyword.ToUpper() == (item.ToUpper()));
                if (tp != null)
                {
                    result += tp.getString() +" ";
                }
                else
                {
                    result += item + " ";
                }
            }


            return result;


        }
    }
}