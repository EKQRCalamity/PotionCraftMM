using PotionCraft.ManagersSystem.Debug;
using PotionCraft.ObjectBased.Mortar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potions.Mods
{
    internal class DebugWindow
    {
        internal static void AudioTest()
        {
            Logger.Log($"DebugWindow_AudioTest called!");
            General.debugManager.DebugWindow_AudioTest();
        }

        internal static void Bellows()
        {
            Logger.Log($"DebugWindow_Bellows called!");
            General.debugManager.DebugWindow_Bellows();
        }

        internal static void Cursor()
        {
            Logger.Log($"DebugWindow_Bellows called!");
            General.debugManager.DebugWindow_Cursor();
        }

        internal static void CursorInput()
        {
            Logger.Log($"DebugWindow_CursorInput called!");
            General.debugManager.DebugWindow_CursorInput();
        }

        internal static void Input()
        {
            Logger.Log($"DebugWindow_Input called!");
            General.debugManager.DebugWindow_Input();
        }

        internal static void Mortar()
        {
            Logger.Log($"DebugWindow_Mortar called!");
            General.debugManager.DebugWindow_Mortar();
        }

        internal static void NPC()
        {
            Logger.Log($"DebugWindow_NPC called!");
            General.debugManager.DebugWindow_NPC();
        }

        internal static void ObjectInfo()
        {
            Logger.Log($"DebugWindow_ObjectInfo called!");
            General.debugManager.DebugWindow_ObjectInfo();
        }

        internal static void PestleGrind()
        {
            Logger.Log($"DebugWindow_PestleGrind called!");
            General.debugManager.DebugWindow_PestleGrind();
        }

        internal static void PotionStatus()
        {
            Logger.Log($"DebugWindow_PotionStatus called!");
            General.debugManager.DebugWindow_PotionStatus();
        }

        internal static void Print()
        {
            Logger.Log($"DebugWindow_Print called!");
            General.debugManager.DebugWindow_Print();
        }

        internal static void RecipeMap()
        {
            Logger.Log($"DebugWindow_RecipeMap called!");
            General.debugManager.DebugWindow_RecipeMap();
        }

        internal static void RecipeMarks()
        {
            Logger.Log($"DebugWindow_RecipeMarks called!");
            General.debugManager.DebugWindow_RecipeMarks();
        }

        internal static void Rooms()
        {
            Logger.Log($"DebugWindow_Rooms called!");
            General.debugManager.DebugWindow_Rooms();
        }

        internal static void SaveLoad()
        {
            Logger.Log($"DebugWindow_SaveLoad called!");
            General.debugManager.DebugWindow_SaveLoad();
        }

        internal static void SlotConditions()
        {
            Logger.Log($"DebugWindow_SlotConditions called!");
            General.debugManager.DebugWindow_SlotConditions();
        }

        internal static void Trade()
        {
            Logger.Log($"DebugWindow_Trade called!");
            General.debugManager.DebugWindow_Trade();
        }
    }
}
