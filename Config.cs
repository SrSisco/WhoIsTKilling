using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs;
using System.ComponentModel;

public class Config : IConfig
{
    public bool Debug { get; set; } = false;
    [Description("Enable or disable the plugin.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Sets if the target player gets a message when getting shot by a teammate.")]
    public bool ShowTarget { get; set; } = true;

    [Description("Sets if the shooter gets a message when shooting a teammate.")]
    public bool ShowShooter { get; set; } = true;

    [Description("Sets if class-D gets a message when shooting antoher class-D.")]
    public bool ShowClassD { get; set; } = false;

    [Description("Sets if teammates get a broadcast when blinded by their team.")]
    public bool FlashGrenadeNotify { get; set; } = true;

    [Description("Sets how long the message will be displayed.")]
    public ushort NotificationTime { get; set; } = 5;

    [Description("Custom broadcast for the target.")]
    public string TargetBc { get; set; } = "Your teammate <b><color=red>{attackername}</color></b> has attacked you.";

    [Description("Custom broadcast for the attacker.")]
    public string AttackerBc { get; set; } = "You are attacking your teammate <b><color=red>{targetname}</color></b>.";

    [Description("Custom broadcast for the flashbang (attacker).")]
    public string FlashAttackerBc { get; set; } = "You have blinded your teammate(s).";

    [Description("Custom broadcast for the flashbang (target).")]
    public string FlashTargetBc { get; set; } = "Your teammate<b><color=red>{throwername}</color></b> blinded you.";

    [Description("How the TK notification is done (Broadcast, Hint, Console)")]
    public string NotificationMode { get; set; } = "Broadcast";
}