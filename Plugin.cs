using System;
using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
namespace WhoIsTKilling
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers EventHandler;
        public override string Name => "WhoIsTKilling";
        public override string Author => "SrSisco#2995";
        public override Version Version  => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(5,0,0);

        public override void OnEnabled()
        {
            
            EventHandler = new EventHandlers(this);
            Map.ExplodingGrenade += EventHandler.OnExplodingGrenade;
            Player.Hurting += EventHandler.OnHurting;
            Server.RoundEnded += EventHandler.OnRoundEnded;
            Log.Info("WhoIsTKilling has been enabled.");
            base.OnEnabled();

        }

        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.OnHurting;
            Map.ExplodingGrenade -= EventHandler.OnExplodingGrenade;
            Server.RoundEnded -= EventHandler.OnRoundEnded;
            EventHandler = null;
            
            Log.Info("WhoIsTKilling has been disabled.");
            base.OnDisabled();
        }
    }
}
