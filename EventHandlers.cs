
using System;
using WhoIsTKilling;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;

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
            targetname = ev.Player.Nickname;
          
            if (ev.Player is null || ev.Attacker is null) return;
            if (ev.Attacker.Role == RoleTypeId.ClassD && ev.Player.Role == RoleTypeId.ClassD) return;
            if (ev.Attacker == ev.Player) return;

            if (ev.Attacker.LeadingTeam == ev.Player.LeadingTeam)
            {

                if (plugin.Config.ShowTarget == true)
                {
                    switch (plugin.Config.NotificationMode)
                    {
                        case ("Broadcast"):
                            ev.Player.Broadcast(plugin.Config.NotificationTime, plugin.Config.TargetBc);
                            break;
                        case ("Hint"):
                            ev.Player.ShowHint(plugin.Config.TargetBc, plugin.Config.NotificationTime);
                            break;
                        case ("Console"):
                            ev.Player.SendConsoleMessage(plugin.Config.TargetBc, "yellow");
                            break;
                    }
                    

                }

                if (plugin.Config.ShowShooter == true)
                {
                    switch (plugin.Config.NotificationMode)
                    {
                        case ("Broadcast"):
                            ev.Player.Broadcast(plugin.Config.NotificationTime, plugin.Config.AttackerBc);
                            break;
                        case ("Hint"):
                            ev.Player.ShowHint(plugin.Config.AttackerBc, plugin.Config.NotificationTime);
                            break;
                        case ("Console"):
                            ev.Player.SendConsoleMessage(plugin.Config.AttackerBc, "yellow");
                            break;
                    }
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
            throwername = ev.Player.Nickname;
            if (!plugin.Config.FlashGrenadeNotify) return;
            if (ev.Projectile.ProjectileType != ProjectileType.Flashbang) return;

            foreach (Exiled.API.Features.Player player in ev.TargetsToAffect)
            {
                switch (plugin.Config.NotificationMode)
                {
                    case ("Broadcast"):
                        ev.Player.Broadcast(plugin.Config.NotificationTime, plugin.Config.FlashTargetBc);
                        break;
                    case ("Hint"):
                        ev.Player.ShowHint(plugin.Config.FlashTargetBc, plugin.Config.NotificationTime);
                        break;
                    case ("Console"):
                        ev.Player.SendConsoleMessage(plugin.Config.FlashTargetBc, "yellow");
                        break;
                }
            }
            switch (plugin.Config.NotificationMode)
            {
                case ("Broadcast"):
                    ev.Player.Broadcast(plugin.Config.NotificationTime, plugin.Config.FlashAttackerBc);
                    break;
                case ("Hint"):
                    ev.Player.ShowHint(plugin.Config.FlashAttackerBc, plugin.Config.NotificationTime);
                    break;
                case ("Console"):
                    ev.Player.SendConsoleMessage(plugin.Config.FlashAttackerBc, "yellow");
                    break;
            } 
        }
    }
}