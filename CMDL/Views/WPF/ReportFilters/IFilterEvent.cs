using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMDL.Views.WPF.ReportFilters
{
    public interface IFilterEvent
    {
        event Action<ReportClass, object> SearchEvent;
    }
}
