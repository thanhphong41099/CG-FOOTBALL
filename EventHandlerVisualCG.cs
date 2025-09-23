

using K3DAsyncEngineLib;
using VLeague.src.menu;

namespace VLeague
{
    internal class EventHandlerVisualCG : EventHandler
    {
        public FrmSetting Owner;
        public EventHandlerVisualCG(FrmSetting _Owner)
        {
            Owner = _Owner;
        }

        public override void OnLogMessage(string LogMessage)
        {
            Owner.OnLogMessage(LogMessage);
        }


    }
}
