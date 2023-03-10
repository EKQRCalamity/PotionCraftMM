using PotionCraft.ManagersSystem.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potions.Mods
{
    internal class General
    {
        internal static DebugManager debugManager = new DebugManager();
        internal static void UnlockLegendary()
        {
            Logger.Log("Unlock Legendary Recipes called!", LogType.Blue);
            debugManager.UnlockLegendaryRecipes();
        }

        internal static void UnlockPotionBase()
        {

            Logger.Log("Unlock Potion Base called!", LogType.Blue);
            debugManager.UnlockPotionBases();
        }

        internal static void StartNextDay()
        {
            Logger.Log("Start Next Day called!", LogType.Blue);
            debugManager.StartNextDay();
        }

        internal static void SpawnYoda()
        {
            Logger.Log("Spawn Yoda called!", LogType.Blue);
            debugManager.SpawnYoda();
        }

        internal static void SpawnRichTrader()
        {
            Logger.Log("Spawn Rich Trader called!", LogType.Blue);
            debugManager.SpawnRichTrader();
        }

        internal static void SpawnGenerousCustomer()
        {
            Logger.Log("Spawn Generous Customer called!", LogType.Blue);
            debugManager.SpawnGenerousCustomer();
        }

        internal static void SpawnAlexOrange()
        {
            Logger.Log("Spawn Alex Orange called!", LogType.Blue);
            debugManager.SpawnAlexOrange();
        }

        internal static void SpawnAlexGrey()
        {
            Logger.Log("Spawn Alex Grey called!", LogType.Blue);
            debugManager.SpawnAlexGrey();
        }

        internal static void SkipNPC()
        {
            Logger.Log("Skip Npc called!", LogType.Blue);
            debugManager.SkipNpc();
        }

        internal static void SkipAllNPCs()
        {
            Logger.Log("Skip All Npc called!", LogType.Blue);
            debugManager.SkipAllNpc();
        }

        internal static void RevealMap()
        {
            Logger.Log("Reveal Map called!", LogType.Blue);
            debugManager.RevealMap();
        }

        internal static void HideMap()
        {
            Logger.Log("Hide Map called!", LogType.Blue);
            debugManager.HideMap();
        }

        internal static void FillRecipes()
        {
            Logger.Log("Fill Recipes called!", LogType.Blue);
            debugManager.FillRecipeBook();
        }

        internal static void AddRandomRecipe()
        {
            Logger.Log("Add Random Recipe called!", LogType.Blue);
            debugManager.AddRandomRecipe();
        }

        internal static void ClearRecipes()
        {
            Logger.Log("Clear Recipes called!", LogType.Blue);
            debugManager.ClearRecipeBook();
        }

        internal static void ClearInventory()
        {
            Logger.Log("Clear Inventory called!", LogType.Blue);
            debugManager.ClearInventory();
        }

        internal static void GenerateSpecialQueue()
        {
            Logger.Log("Generate Special Queue called!", LogType.Blue);
            debugManager.GenerateSpecialQueue();
        }

        internal static void ToggleFPS()
        {
            Logger.Log("Toggle FPS called!", LogType.Blue);
            debugManager.Debug_ToggleFPSCounter();
        }
    }
}
