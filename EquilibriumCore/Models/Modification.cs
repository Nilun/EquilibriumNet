using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Modification
    {
        [Key] public int ID { get; set; }
        public string Categorie { get; set; }
        public string SousCategorie { get; set; }
        public string TexteOld { get; set; }
        public string TexteNew { get; set; }
        public int? IDUpdate { get; set; }

        public string GetUpdate()
        {
            string result = "";

            string markOld = "";
            string markNew = "";
            string[] parseOld = TexteOld.Split(" ");
            string[] parseNew = TexteNew.Split(" ");

            int i = 0;
                for ( i = 0; i < parseOld.Count() ; i++)
                {
                if (parseOld.Count()>= parseNew.Count())
                {
                    if (parseNew.Count() > i)
                    {
                        if (parseOld[i] != parseNew[i])
                        {
                            markOld += "<s>" + parseOld[i] + "</s> ";
                            markNew += "<b>" + parseNew[i] + "</b> ";
                        }
                        else
                        {
                            markOld += parseOld[i]+" ";
                            markNew += parseNew[i] + " ";
                        }
                    }else
                    {
                        markOld += "<s>" + parseOld[i] + "</s> ";
                    }
                }
                   
                }
            if (parseOld.Count() < parseNew.Count())
            {
                for (; i < parseNew.Count(); i++)
                {
                    markNew += "<b>" + parseNew[i] + "</b> ";
                }
            }



                return markOld + "  ⟹  " + markNew;
        }
    }
   

}
