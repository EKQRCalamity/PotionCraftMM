using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Potions
{
    public class Loader
    {
        internal static GameObject _gObj;

        public static void Init()
        {
            _gObj = new GameObject();
            Logger.SetUpConsole();
            _gObj.AddComponent<Potions.Logger>();
            Logger.Log("Injection Successful.", LogType.Success);
            Logger.Log("Made by Vanargand#0001");
            Logger.Log("Initializing AchievementManager...", LogType.Blue);
            Mods.Achievements.Init();
            Logger.Log("Loading Components...", LogType.Blue);
            _gObj.AddComponent<Potions.Main>();
            Logger.Log("Main Component Injected!", LogType.Success);
            GameObject.DontDestroyOnLoad(_gObj);
        }

        public static void Unload()
        {
            _Unload();
        }

        private static void _Unload()
        {
            GameObject.Destroy(_gObj);
        }
    }
}
