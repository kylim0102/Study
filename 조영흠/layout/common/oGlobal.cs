using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test12
{
    internal class oGlobal
    {
    }
    public enum enLogLevel
    {
        Info, Warning, Error,




    }
    public delegate void delLogSender(object oSender, enLogLevel eLevel, string strLog);


}
