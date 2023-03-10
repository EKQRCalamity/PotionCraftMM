using PotionCraft.Assemblies.AchievementsSystem;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potions.Mods
{
    internal class Achievements
    {
        private static Dictionary<string, PotionCraft.Assemblies.AchievementsSystem.Achievement> list = new Dictionary<string, PotionCraft.Assemblies.AchievementsSystem.Achievement>();
        
        internal static void Init()
        {
            foreach (Achievement item in Achievement.LoadAchievements().Item2)
            {
                try
                {
                    list.Add(item.name, item);
                }
                catch (ArgumentException message)
                {
                    Logger.Log(message);
                }
            }
        }

        internal static void UnlockAll()
        {
            foreach (Achievement achievement in list.Values)
            {
                Logger.Log($"Unlocking achievement {achievement.name}!");
                AchievementsManager.UnlockAchievement(achievement, false);
                AchievementsManager.UnlockAchievement(achievement, true);
            }
        }

        internal static void ResetAll()
        {
            Logger.Log($"Resetting all achievements");
            AchievementsManager.ResetAllAchievements();
        }
    }
}
