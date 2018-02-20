﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace vMenuClient
{
    public class EventManager : BaseScript
    {
        private static CommonFunctions cf = new CommonFunctions();
        public EventManager()
        {
            EventHandlers.Add("vMenu:GoToPlayer", new Action<int>(SummonPlayer));
            EventHandlers.Add("vMenu:KillMe", new Action(KillMe));
            EventHandlers.Add("vMenu:KickCallback", new Action<string>(KickCallback));
        }

        private void KickCallback(string reason)
        {
            MainMenu.Notify.Custom(reason, true, false);
        }

        private void KillMe()
        {
            SetEntityHealth(PlayerPedId(), 0);
        }

        private void SummonPlayer(int targetPlayer)
        {
            cf.TeleportToPlayerAsync(GetPlayerFromServerId(targetPlayer));
        }
    }
}
