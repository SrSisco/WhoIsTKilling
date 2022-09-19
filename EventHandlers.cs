
using System;
using WhoIsTKilling;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Enums;

namespace WhoIsTKilling
{
    public class EventHandlers
    {
        public string attackername;
        public string targetname;
        public string throwername;
        private readonly Plugin plugin;
        
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        internal void OnHurting(HurtingEventArgs ev)
        {
            attackername = ev.Attacker.Nickname;
            targetname = ev.Target.Nickname;
          
            if (ev.Target is null || ev.Attacker is null) return;
            if (ev.Attacker.Role == RoleType.ClassD && ev.Target.Role == RoleType.ClassD) return;
            if (ev.Attacker == ev.Target) return;

            if (ev.Attacker.LeadingTeam == ev.Target.LeadingTeam)
            {

                if (plugin.Config.ShowTarget == true)
                {
                    ev.Target.Broadcast(plugin.Config.BroadcastTime, plugin.Config.TargetBc);

                }

                if (plugin.Config.ShowShooter == true)
                {
                    ev.Target.Broadcast(plugin.Config.BroadcastTime, plugin.Config.TargetBc);
                }

            }
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            attackername = null;
            targetname = null;
            throwername = null;
        }
        internal void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            throwername = ev.Thrower.Nickname;
            if (!plugin.Config.FlashGrenadeNotify) return;
            if (ev.GrenadeType != GrenadeType.Flashbang) return;

            foreach (Exiled.API.Features.Player player in ev.TargetsToAffect)
            {
                player.Broadcast(plugin.Config.BroadcastTime, plugin.Config.FlashTargetBc); 
            }
            ev.Thrower.Broadcast(plugin.Config.BroadcastTime, plugin.Config.FlashAttackerBc);  
        }
    }
}