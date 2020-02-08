using EquilibriumCore.Data;
using EquilibriumCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Service
{
    public class ToolTipService : IToolTipService
    {
        public List<Tooltiper> tooltipers { get; set; }
        DataContext _context;
        public Task UpdateTooltip()
        {
            tooltipers = _context.Tooltiper.ToList();
                return Task.CompletedTask;
        }
        public ToolTipService(DataContext context)
        {
            _context = context;
            UpdateTooltip();
        }
        public string InsertTooltip(string value)
        {

            if (string.IsNullOrEmpty(value)) return "";

            string result = "";
            string[] working_array = value.Split(" ");

            foreach (string item in working_array)
            {
                Tooltiper tp = tooltipers.FirstOrDefault(t => t.keyword.ToUpper() == (item.ToUpper()));
                if (tp != null)
                {
                    result += tp.getString() + " ";
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
