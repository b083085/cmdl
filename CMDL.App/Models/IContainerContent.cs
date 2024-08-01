using CMDL.App.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDL.App.Models
{
    public interface IContainerContent
    {
        ContainerView ContainerView { get; }
    }
}
