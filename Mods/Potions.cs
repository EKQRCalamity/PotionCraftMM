using PotionCraft.ManagersSystem;
using PotionCraft.ManagersSystem.Potion;
using PotionCraft.ScriptableObjects;
using PotionCraft.ScriptableObjects.Potion;
using PotionCraft.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potions.Mods
{
    internal class Potions
    {
        static PotionManager pManager = new PotionManager();
        internal static List<PotionEffect> allEffects = PotionEffect.allPotionEffects;
        internal static void AddPotionEffect(PotionEffect potionEffect)
        {
            if (allEffects.Contains(potionEffect))
            {
                pManager.AddEffect(potionEffect.name, 3);
            }
        }

        internal static void AddPotionEffect(string name)
        {
            pManager.AddEffect(name, 3);
        }

        internal static void AddAllEffects()
        {
            foreach (PotionEffect potionEffect in allEffects)
            {
                Logger.Log($"Adding {potionEffect.name} at tier 3");
                pManager.AddEffect(potionEffect.name, 3);
            }
        }

        internal static void AddRandomEffects()
        {
            pManager.AddMixedPotions();
        }

        internal static void ResetPotion()
        {
            pManager.ResetPotion();
        }

        internal static void AddAllPotions()
        {
            foreach (PotionEffect allPotionEffect in PotionEffect.allPotionEffects)
            {
                AddPotionsWithEffect(allPotionEffect);
            }
        }

        private static void AddPotionsWithEffect(PotionEffect selectedEffect)
        {
            for (int i = 1; i <= 3; i++)
            {
                PotionEffect[] array = new PotionEffect[i];
                for (int j = 0; j < i; j++)
                {
                    array[j] = selectedEffect;
                }
                Potion item = PotionGenerator.GeneratePotion(array);
                Managers.Player.inventory.AddItem(item, 10);
            }
        }
    }
}
