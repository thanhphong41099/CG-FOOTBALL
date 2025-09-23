using System;
using System.Diagnostics;

namespace VLeague.src.helper
{
    internal class Handler
    {
        public static void handlerError(string funtional,Exception exception)
        {
            if (FrmKarismaMenu.FrmSetting != null) // Check if FrmSetting is not null
            {
                FrmKarismaMenu.FrmSetting.OnLogMessage("Does not exits in >>" + funtional + "<<  :" + exception.Message);
            }
        }
    }
}
