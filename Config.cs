using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs;
using System.ComponentModel;

public class Config : IConfig
{
    [Description("Enable or disable the plugin.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Sets if the target player gets a message when getting shot by a teammate.")]
    public bool ShowTarget { get; set; } = true;

    [Description("Sets if the shooter gets a message when shooting a teammate.")]
    public bool ShowShooter { get; set; } = true;


    [Description("Sets if class-D gets a message when sooting antoher class-D.")]
    public bool ShowClassD { get; set; } = false;

    [Description("Sets how long the message will be displayed.")]
    public int BroadcastTime { get; set; }

    [Description("Sets in which language will the messages will be displayed (only spanish or inglish: es en).")]
    public string lang { get; set; } = "en";
}
