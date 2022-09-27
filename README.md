# WhoIsTKilling

![downloads](https://img.shields.io/github/downloads/SrSisco/WhoIsTKilling/total?style=for-the-badge)
This plugin will display a broadcast to a player when attacked by their team

# Configs
        
  ## **IsEnabled**
   Enable or disable the plugin.
   Type: boolean
   Default: true

  ## **ShowTarget**
   Sets if the target player gets a message when getting shot by a teammate.
   Type: boolean
   Default: true

  ## **ShowShooter**
   Sets if the shooter gets a message when shooting a teammate.
   Type: boolean
   Default: true

  ## **FlashGrenadeNotify**
   Sets if teammates get a broadcast when blinded by their team.
   Type: boolean
   Default: true
   
  ## **ShowClassD**
   Sets if class-D gets a message when shooting another class-D.
   Type: boolean
   Default: false
   
  ## **BroadcastTime**
   Sets how long the message will be displayed.
   Type: integer
   Default: 5

  ## **TargetBc**
   Custom broadcast for the target.
   Type: String
   Default: ``Your teammate <b><color=red>{attackername}</color></b> has attacked you.``
   
  ## **AttackerBc**
   Custom broadcast for the attacker.
   Type: String
   Default: ``You are attacking your teammate <b><color=red>{targetname}</color></b>.``
   
   ## **FlashAttackerBc**
   Custom broadcast for the flashbang (target).
   Type: String
   Default: ``Your teammate <b><color=red>{throwername}</color></b> blinded you.``
   
  ## **FlashTargetBc**
   Custom broadcast for the flashbang (attacker).
   Type: String
   Default: ``You have blinded your teammate(s).``
