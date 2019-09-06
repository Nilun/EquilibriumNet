using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;



namespace EquilibriumCore.Models
{
    public class Spell
    {
        [Key] public int ID { get; set; }
        public string name { get; set; }
        public Element Element { get; set; }
        public int IDForm { get; set; }
        public string listID { get; set; }
        [NotMapped] public List<Component> AllComponents { get; set; }
        public string IDComponents { get; set; }
        [NotMapped] public string description { get; set; }
        public int IDCaster { get; set; }



        [NotMapped] public IEnumerable<Component> Components { get => LinkComponents?.Select(a=>a.Component);}
        
        public List<SpellLinkComponent> LinkComponents { get; set; } = new List<SpellLinkComponent>();

        [NotMapped] public string cost { get; set; }
        public Spell()
        {
           
        }

        public string getSpellDescription()
        {
            bool haveform = false;
            string res = "";
           var compote = Components.Distinct();
            foreach (Component compo in compote)
            {
                                  
                    if(compo.IsForm && !haveform)
                    {
                        haveform = true;
                        res = compo.getFusedStringForLevel(Components.Count(a=>a.ID==compo.ID)) + Environment.NewLine + res;
                    }
                    else
                    {
                        res += compo.getFusedStringForLevel(Components.Count(a => a.ID == compo.ID)) + Environment.NewLine;
                    }
                 
                
            }
            if(!haveform)
            {
                res = "Apply all effect on Self " + Environment.NewLine + res;
            }
            return res;
        }

        public string getCostString()
        {
            string res = "";
           
            Dictionary<string,int> pricedic = new Dictionary<string, int>();
            foreach (Component compo in Components)
            {
                               
                    if (compo.PriceString != null)
                    {
                        string[] cost = compo.PriceString.ToUpper().Split(' ');
                        foreach (var c in cost)
                        {
                            if (c != null)
                            {
                                if (pricedic.Keys.Contains(c))
                                {
                                    pricedic[c]++;
                                }
                                else
                                {
                                    pricedic.Add(c, 1);
                                }
                            }

                        }
                    }

                
            }
            foreach (var el in pricedic)
            {
                res += " " + el.Value + " : " + el.Key;
            }
         
            return res;
        }

        public int getRange()
        {
           
            foreach (Component compo in Components)
            { 
                    if (compo.IsForm )
                    {

                        return compo.Range;
                    }
                   

              
            }
            return 0;
        }

        public int getArea()
        {
            foreach (Component compo in Components)
            {
                if (compo.IsForm)
                {

                    return compo.Area;
                }



            }
            return 0;
        }

        public void FillForeignKey()
        {
            string[] sr = IDComponents.Split(';');
            foreach (string item in sr)
            {
                if (item != "")
                {
                    string[] elem = item.Split(':');
                    int id = Convert.ToInt32(elem[0]);
                    Component compo = AllComponents.Where(a => a.ID == id).First();
                    int quantity = Convert.ToInt32(elem[1]);
                    if (compo.IsForm) quantity = 1;
                    quantity = Math.Min(quantity, 6);
                    for (int i = 0; i < quantity; i++)
                    {
                        LinkComponents.Add(new SpellLinkComponent() { Component = compo, Spell = this });
                    }


                }
            }
        }
    }
}