using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotionCraft.ManagersSystem;
using PotionCraft.ManagersSystem.Player;
using UnityEngine;

namespace Potions.Mods
{
    internal class Reputation
    {
        static PlayerManager playerManager = new PlayerManager();
        internal static void AddKarma(int karma)
        {
            Logger.Log("Player.AddKarma called!", LogType.Magenta);
            Managers.Player.AddKarma(karma);
        }
        internal static void AddPop(int rep)
        {
            Logger.Log("PlayerManager.AddPopularity called!", LogType.Magenta);
            Managers.Player.AddPopularity(rep);
        }
        internal static void AddEXP(int exp)
        {
            Logger.Log("Player.AddExperience called!", LogType.Magenta);
            if (exp < 0)
            {
                exp = 0;
            }
            Managers.Player.AddExperience(exp);
        }
        internal static void AddGold(int gold)
        {
            Logger.Log("Player.AddGold called!", LogType.Magenta);
            Managers.Player.AddGold(Mathf.Max(-Managers.Player.Gold, gold));
        }
    }
}
