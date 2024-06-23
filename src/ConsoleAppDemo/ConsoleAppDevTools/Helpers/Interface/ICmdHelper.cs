using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevTools.Helpers.Interface
{
    public interface ICmdHelper
    {
        void RunCmd(params string[] arguments);
    }
}
