using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    interface IPageImplementer
    {
        bool Insert();
        bool Update(int index);
        bool Delete(int index);
    }
}
