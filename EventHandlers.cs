
using System;
using WhoIsTKilling;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;


namespace WhoIsTKilling
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        internal void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Target is null || ev.Attacker is null) return;
            if (ev.Attacker.Role == RoleType.ClassD && ev.Target.Role == RoleType.ClassD) return;
            if (ev.Attacker == ev.Target) return;

            if (ev.Attacker.LeadingTeam == ev.Target.LeadingTeam)
            {
                if (plugin.Config.ShowTarget == true)
                {
                    if (plugin.Config.lang == "es")
                    {
                        ev.Target.Broadcast((ushort)plugin.Config.BroadcastTime, $"Tu compañero {ev.Attacker.Nickname} te ha hecho daño.");
                    }
                    if (plugin.Config.lang == "en")
                    {
                        ev.Target.Broadcast((ushort)plugin.Config.BroadcastTime, $"Your teammate {ev.Attacker.Nickname} attacked you.");
                    }

                }

                if (plugin.Config.ShowShooter == true)
                {
                    if (plugin.Config.lang == "es")
                    {
                        ev.Target.Broadcast((ushort)plugin.Config.BroadcastTime, $"Le has hecho daño a tu compañero {ev.Attacker.Nickname}.");
                    }
                    if (plugin.Config.lang == "en")
                    {
                        ev.Target.Broadcast((ushort)plugin.Config.BroadcastTime, $"You attacked {ev.Attacker.Nickname}.");
                    }
                }

            }
        }
    }
}