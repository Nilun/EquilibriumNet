using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Skills
    {
        [Key] public int ID { get; set; }
        public string superCat { get; set; }
        public string cat { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public int levelMax { get; set; }
        public string Tags { get; set; }
        public string Ignore { get; set; }
        [NotMapped]public string currentEffect { get => getEffect(); }
        [NotMapped] int currentLevel;
        [NotMapped] public int CurrentLevel {get =>  currentLevel;set => setLevel(value);}
        public Skills()
        {
            this.superCat = "";
            this.cat = "";
            Name = "";
            Effect = "";
            this.levelMax = 0;
            Tags = "";
        }
        public Skills(string superCat, string cat, string name, string effect, int levelMax)
        {
            this.superCat = superCat;
            this.cat = cat;
            Name = name;
            Effect = effect;
            this.levelMax = levelMax;
            Tags = "";
        }
        public void setLevel(int value)
        {
            if(value>levelMax)
            {
                currentLevel = levelMax;
            }else
            {
                currentLevel = value;
            }
        }
        public string getEffect()
        {
            string s = "";
            string[] ignored;
            if (Ignore != null && Ignore != ""  && Ignore.Contains(';'))
            {
                 ignored = Ignore.Split(";");
            }else if (Ignore != null && Ignore != "")
            {
                ignored = new string[1];
                ignored[0] = Ignore;
            } else
            {
                ignored = new string[0];
            }
            foreach (char c in Effect)
            {
                int outVal;
                if(int.TryParse(c.ToString(),out outVal) && !ignored.Contains( c.ToString()))
                {
                    s += outVal * CurrentLevel;
                }else
                {
                    s += c;
                }
            }
            return s;
        }
        public string getIDComposed()
        {
            return superCat + "," + cat + "," + Tags;
        }
    }
}
