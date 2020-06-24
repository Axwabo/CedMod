﻿using System;
using EXILED;
using EXILED.Extensions;
using MEC;
using UnityEngine;

namespace CedMod
{
    public class Commands
    {
        public Plugin Plugin;
        public Commands(Plugin plugin) => Plugin = plugin;
        public void OnRoundEnd()
        {
            IsEnabled = false;
            Timing.KillCoroutines("LightsOut");
        }
        public void OnCommand(ref RACommandEvent ev)
        {
            string[] command = ev.Command.Split(' ');
            switch (command[0].ToUpper())
            {
                
                case "LIGHTSOUT":
                    ev.Allow = false;
                    if (command.Length < 2)
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#Usage: LightsOut <OnlyHeavy>", false, true, "");
                        break;
                    }
                    if (!CheckPermissions(ev.Sender, command[0], PlayerPermissions.FacilityManagement))
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#No perms to LightsOut bro.", false, true, "");
                        break;
                    }
                    if (IsEnabled == false)
                    {
                        IsEnabled = true;
                        Timing.RunCoroutine(Functions.LightsOut(Convert.ToBoolean(command[1])), "LightsOut");
                        ev.Sender.RaReply(command[0].ToUpper() + "#Lights have been turned off", true, true, "");
                        break;
                    }
                    else
                    {
                        if (IsEnabled)
                        {
                            IsEnabled = false;
                            Timing.KillCoroutines("LightsOut");
                            ev.Sender.RaReply(command[0].ToUpper() + "#Lights have been turned on", true, true, "");
                            break;
                        }
                    }
                    ev.Sender.RaReply(command[0].ToUpper() + "#Something went wrong", false, true, "");
                    break;
                case "DISABLEFFA":
                    ev.Allow = false;
                    if (!CheckPermissions(ev.Sender, command[0], PlayerPermissions.FacilityManagement))
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#No perms to DisableFFA bro.", false, true, "");
                        break;
                    }
                    FriendlyFireAutoBan.AdminDisabled = !FriendlyFireAutoBan.AdminDisabled;
                    if (FriendlyFireAutoBan.AdminDisabled)
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#FFA is now Disabled FFA wil reset at round end unless FFA is disabled", true, true, "");
                    }
                    else
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#FFA is now Enabled FFA wil reset at round end unless FFA is disabled", true, true, "");
                    }
                    break;
                case "STUITER":
                    ev.Allow = false;
                    if (!CheckPermissions(ev.Sender, command[0], PlayerPermissions.FacilityManagement))
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#No perms to Stuiter bro.", false, true, "");
                        break;
                    }
                    if (command.Length < 2)
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#Usage: stuiter [spec|all]", false, true, "");
                        break;
                    }
                    switch (command[1].ToUpper())
                    {
                        case "ALL":
                            Cassie.CassieMessage("xmas_bouncyballs", false, false);
                            foreach (GameObject player in PlayerManager.players)
                            {
                                CharacterClassManager component = player.GetComponent<CharacterClassManager>();
                                component.SetClassID(RoleType.Tutorial);
                                component.GetComponent<PlayerStats>()._health = 100;
                                component.GetComponent<Inventory>().items.Clear();
                                component.GetComponent<Inventory>().AddNewItem(ItemType.SCP018);
                                component.GodMode = false;
                            }
                            break;
                        default:
                            Cassie.CassieMessage("xmas_bouncyballs", false, false);
                            foreach (GameObject player in PlayerManager.players)
                            {
                                CharacterClassManager component = player.GetComponent<CharacterClassManager>();
                                if (component.CurClass == RoleType.Spectator)
                                {
                                    component.SetClassID(RoleType.Tutorial);
                                    component.GetComponent<PlayerStats>()._health = 100;
                                    component.GetComponent<Inventory>().items.Clear();
                                    component.GetComponent<Inventory>().AddNewItem(ItemType.SCP018);
                                    component.GodMode = false;
                                }
                            }
                            break;
                    }
                    break;
                case "AIRSTRIKE":
                    ev.Allow = false;
                    if (!CheckPermissions(ev.Sender, command[0], PlayerPermissions.FacilityManagement))
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#No perms to airbomb bro.", false, true, "");
                        break;
                    }
                    if (command.Length < 3)
                    {
                        ev.Sender.RaReply(command[0].ToUpper() + "#Usage: AIRSTRIKE <delay> <duration>", false, true, "");
                        break;
                    }
                    Timing.RunCoroutine(Functions.Coroutines.AirSupportBomb(Convert.ToInt32(command[1]), Convert.ToInt32(command[2])), "airstrike");
                    ev.Sender.RaReply(command[0].ToUpper() + "#Done", true, true, "");
                    break;
            }
        }
        public bool IsEnabled;
        private static bool CheckPermissions(CommandSender sender, string queryZero, PlayerPermissions perm, string replyScreen = "", bool reply = true)
        {
            if (ServerStatic.IsDedicated && sender.FullPermissions)
            {
                return true;
            }
            if (PermissionsHandler.IsPermitted(sender.Permissions, perm))
            {
                return true;
            }
            if (reply)
            {
                sender.RaReply(queryZero + "#You don't have permissions to execute this command.\nMissing permission: " + perm, false, true, replyScreen);
            }
            return false;
        }
    }
}
