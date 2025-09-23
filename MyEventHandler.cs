

using K3DAsyncEngineLib;
using VLeague.src.menu;

namespace VLeague
{
    internal class MyEventHandler : EventHandler
    {
        public FrmSetting Owner;
        public MyEventHandler(FrmSetting _Owner)
        {
            Owner = _Owner;
        }

        public override void OnLogMessage(string LogMessage)
        {
            Owner.OnLogMessage(LogMessage);
        }


    }
}
