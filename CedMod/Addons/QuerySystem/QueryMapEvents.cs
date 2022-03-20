﻿using System.Collections.Generic;
using CedMod.Addons.QuerySystem.WS;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace CedMod.Addons.QuerySystem
{
    public class QueryMapEvents
    {
        public void OnWarheadDetonation()
        {
            WebSocketSystem.SendQueue.Enqueue(new QueryCommand()
            {
                Recipient = "ALL",
                Data = new Dictionary<string, string>()
                {
                    {"Type", nameof(OnWarheadDetonation)},
                    {"Message", "Warhead has been detonated"}
                }
            });
        }

        public void OnDecon(DecontaminatingEventArgs ev)
        {
            WebSocketSystem.SendQueue.Enqueue(new QueryCommand()
            {
                Recipient = "ALL",
                Data = new Dictionary<string, string>()
                {
                    {"Type", nameof(OnDecon)},
                    {"Message", "Light containment zone has been decontaminated."}
                }
            });
        }

        public void OnWarheadStart(StartingEventArgs ev)
        {
            WebSocketSystem.SendQueue.Enqueue(new QueryCommand()
            {
                Recipient = "ALL",
                Data = new Dictionary<string, string>()
                {
                    {"Type", nameof(OnWarheadStart)},
                    {
                        "Message",
                        string.Format("warhead has been started: {0} seconds",
                            Warhead.Controller.NetworktimeToDetonation)
                    }
                }
            });
        }

        public void OnWarheadCancelled(StoppingEventArgs ev)
        {
            WebSocketSystem.SendQueue.Enqueue(new QueryCommand()
            {
                Recipient = "ALL",
                Data = new Dictionary<string, string>()
                {
                    {"Type", nameof(OnWarheadCancelled)},
                    {"Message", ev.Player.Nickname + " - " + ev.Player.UserId + " has stopped the detonation."}
                }
            });
        }
    }
}