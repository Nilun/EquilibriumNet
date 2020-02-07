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
        DateTime LastUpdate { get; set; }
        int LinkedDocument { get; set; }


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
                                if(c.First()!='*') pricedic[c]++;

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

        public List<Element> GetElement()
        {
            List<Element> res = new List<Element>();
            Dictionary<Element, int> count = new Dictionary<Element, int>();
            foreach (var item in Components.Select(c=>c.Element))
            {
                if (count.Keys.Contains(item))
                {
                    count[item]++;
                        }else
                {
                    count.Add(item, 1);
                }
            }
            int max = count.Values.Max();
            res = count.Where(c => c.Value == max).Select(c => c.Key).ToList();

            return res;
        }

        public string imageNameForElement(Element elem)
        {
            string s = "";
            switch (elem)
            {
                case Element.Fire:
                    s = "fire.png";
                    break;
                case Element.Wind:
                    s = "wind-hole.png";
                    break;
                case Element.Earth:
                    s = "rock.png";
                    break;
                case Element.Water:
                    s = "snowflake-2.png";
                    break;
                case Element.Order:
                    s = "nested-hearts.png";
                    break;
                case Element.Shadow:
                    s = "death-juice.png";
                    break;
                case Element.Chaos:
                    s = "cubes.png";
                    break;
                case Element.Light:
                    s = "sun.png";
                    break;
                case Element.Arcana:
                    s = "spell-book.png";
                    break;
                case Element.War:
                    s = "eye-shield.png";
                    break;
                case Element.Duality:
                    s = "eclipse.png";
                    break;
                case Element.Knowledge:
                    s = "gift-of-knowledge.png";
                    break;
                case Element.Metamagic:
                    s = "interdiction.png";
                    break;
                case Element.Utility:
                    s = "interdiction.png";
                    break;
                default:
                    s = "interdiction.png";
                    break;
            }
            return s;
        }
    }
}