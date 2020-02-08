using System.Collections.Generic;
using System.Threading.Tasks;
using EquilibriumCore.Models;

namespace EquilibriumCore.Service
{
    public interface IToolTipService
    {
        List<Tooltiper> tooltipers { get; set; }

        string InsertTooltip(string value);
        Task UpdateTooltip();
    }
}