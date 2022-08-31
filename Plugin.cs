using System;
using Exiled.API.Features;
using WhoIsTKilling;
using Player = Exiled.Events.Handlers.Player;

namespace WhoIsTKilling
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers EventHandler;
        public override string Name => "WhoIsTKilling";
        public override string Author => "SrSisco#2995";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            EventHandler = new EventHandlers(this);

            Player.Hurting += EventHandler.OnHurting;
            Log.Info("WhoIsTKilling has been enabled.");
            base.OnEnabled();

        }

        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.OnHurting;
            EventHandler = null;
            
            Log.Info("WhoIsTKilling has been disabled.");
            base.OnDisabled();
        }
    }
}
