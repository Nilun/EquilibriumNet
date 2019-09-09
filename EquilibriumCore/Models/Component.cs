using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{

    public class Component
    {
        [Key] public int ID { get; set; }

        public string name { get; set; }
        public Element Element { get; set; }
        public string PriceString { get; set; }
        public bool IsForm { get; set; }
        public int Range { get; set; } = 0;
        public int Area { get; set; } = 0;

        public string text { get; set; }


        public string valuesString { get; set; }


        public string upgradesString { get; set; }

        public List<SpellLinkComponent> Links{get;set;}
        

        [NotMapped] public string GlobalDescription { get => getFusedString(); }
        

        public string getFusedString()
        {
            string res = "";
            if (valuesString == null) return text;
           res = String.Format(text, valuesString.Split(";"));

            return res;
        }

        public string getFusedStringForDescription()
        {
            try
            {
                if (valuesString == null) return text;

                string res = "";
                List<string> datas = new List<string>();

                string[] valuesBase = valuesString.Split(';');
                string[] valuesBaseUp = upgradesString.Split(';');

                for (int i = 0; i < valuesBase.Count(); i++)
                {
                    datas.Add(valuesBase[i] + "(+" + valuesBaseUp[i] + ")");
                }

                res = String.Format(text, datas.ToArray());

                return res;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public string getFusedStringForLevel(int level)
        {
            if (valuesString == null) return text;

            string res = "";

            string[] valuesBase = valuesString.Split(';');
            List<double> valbase = new List<double>();
            foreach (string item in valuesBase)
            {
                valbase.Add(Convert.ToDouble(item.Replace(',', '.'), CultureInfo.InvariantCulture));
            }

            string[] valuesBaseUp = upgradesString.Split(';');
            List<double> valbaseup = new List<double>();
            foreach (string item in valuesBaseUp)
            {
                valbaseup.Add(Convert.ToDouble(item.Replace(',', '.'),CultureInfo.InvariantCulture));
            }
            
                for (int j = 0; j < valbaseup.Count; j++)
                {
                    valbase[j] = valbase[j] + valbaseup[j]*level;
                }
            



            res = String.Format(text, valbase.Select(a=>a.ToString()).ToArray());

            return res;
        }

    
    }
}
