using PotionCraft.ManagersSystem;
using PotionCraft.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Potions
{
    public class Main : MonoBehaviour
    {
        internal static bool __isOn = false;
        internal static bool _isOn = true;
        internal static bool _Unlocks = false;
        
        internal static bool DebugWindows = false;
        internal static bool NPCManager = false;
        internal static bool PlayerManager = false;
        internal static bool PotionManager = false;
        internal static bool TradeManager = false;

        internal static int addInt = 0;
        internal static int selectedEffect = 0;

        internal static List<string> effects = MakeEffects();

        internal static List<string> MakeEffects()
        {
            List<string> list = new List<string>();
            foreach (PotionEffect effect in Mods.Potions.allEffects)
            {
                list.Add(effect.name);
            }
            return list;
        }

        static GUIStyle _NonSelectableWindowStyle;
        static GUIStyle NonSelectableWindowStyle
        {
            get
            {
                if (_NonSelectableWindowStyle == null)
                {
                    GUIStyle s = new GUIStyle(GUI.skin.window);
                    s.onNormal.background = null;
                    _NonSelectableWindowStyle = s;
                }
                return _NonSelectableWindowStyle;
            }
        }

        public void Start()
        {
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                Loader.Unload();
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                __isOn = !__isOn;
                if (__isOn)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                _isOn = !_isOn;
            }
        }

        Rect windowRect = new Rect(Screen.width / 1.3F, 20, 300, 530);
        Rect debugRect = new Rect(Screen.width / 1.3F, 530, 250, 300);
        Rect npcRect = new Rect(Screen.width / 1.7F, 20, 250, 200);
        Rect playerRect = new Rect(Screen.width / 1.7F, 325, 200, 180);
        Rect potionRect = new Rect(Screen.width / 1.7F, 510, 200, 360);

        void OnGUI()
        {
            // Register the window. Here we instruct the layout system to
            // make the window 100 pixels wide no matter what.


            GUI.skin.window.fontSize = 29;
            GUI.skin.window.border.Remove(windowRect);
            GUI.skin.window.normal.textColor = Color.white;
            GUI.skin.window.contentOffset.Set(0, 25);
            GUI.skin.window.padding.left = GUI.skin.box.padding.left;
            GUI.skin.window.padding.right = GUI.skin.box.padding.right;
            GUI.skin.window.padding.top = GUI.skin.box.padding.top;
            GUI.skin.window.padding.bottom = GUI.skin.box.padding.bottom;
            GUI.skin.window.stretchWidth = false;
            GUI.skin.button.fontSize = 14;
            GUI.skin.button.normal.textColor = Color.white;
            GUI.skin.button.normal.background = GUI.skin.box.normal.background;
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.toggle.fontSize = 16;
            GUI.backgroundColor = new Color(239, 149, 157, 0.5F);
            windowRect = GUILayout.Window(0, windowRect, MainMenu, "Potions Menu v1.0", NonSelectableWindowStyle, GUILayout.Width(300));
            if (DebugWindows)
            {
                debugRect = GUILayout.Window(1, debugRect, MainMenu, "Debug Windows", NonSelectableWindowStyle, GUILayout.Width(250));
            }
            if (NPCManager)
            {
                npcRect = GUILayout.Window(2, npcRect, MainMenu, "NPC Manager", NonSelectableWindowStyle, GUILayout.Width(250));
            }
            if (PlayerManager)
            {
                playerRect = GUILayout.Window(3, playerRect, MainMenu, "Player Manager", NonSelectableWindowStyle, GUILayout.Width(200));
            }
            if (PotionManager)
            {
                potionRect = GUILayout.Window(4, potionRect, MainMenu, "Potion Manager", NonSelectableWindowStyle, GUILayout.Width(200));
            }
        }

        // Make the contents of the window
        void MainMenu(int windowID)
        {
            if (_isOn)
            {
                GUI.color = new Color(255, 255, 255);
                GUIStyle labelStyle = new GUIStyle();
                labelStyle.fontSize = 22;
                labelStyle.normal.textColor = new Color(239, 149, 157);
                labelStyle.alignment = TextAnchor.MiddleCenter;
                GUIStyle labelStyle2 = new GUIStyle();
                labelStyle2.fontSize = 14;
                labelStyle2.normal.textColor = Color.white;
                labelStyle2.alignment = TextAnchor.MiddleCenter;
                GUIStyle warningButton = new GUIStyle(GUI.skin.button);
                warningButton.normal.textColor = Color.red;
                switch (windowID)
                {
                    case 0:
                        // This button is too large to fit the window
                        // Normally, the window would have been expanded to fit the button, but due to
                        // the GUILayout.Width call above the window will only ever be 100 pixels wide
                        GUILayout.Space(30);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Reveal Map", GUILayout.Width(150)))
                        {
                            Mods.General.RevealMap();
                        }
                        if (GUILayout.Button("Hide Map", GUILayout.Width(150)))
                        {
                            Mods.General.HideMap();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.Label("Unlocks & Achievements", labelStyle, GUILayout.Width(300));
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Unlock All", GUILayout.Width(150)))
                        {

                            Mods.Achievements.UnlockAll();
                        }
                        if (GUILayout.Button("Reset All", GUILayout.Width(150)))
                        {
                            Mods.Achievements.ResetAll();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Unlock Legendary", GUILayout.Width(150)))
                        {
                            Mods.General.UnlockLegendary();
                        }
                        if (GUILayout.Button("Fill Recipies", GUILayout.Width(150)))
                        {
                            Mods.General.FillRecipes();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Clear Inventory", GUILayout.Width(150)))
                        {
                            Mods.General.ClearInventory();
                        }
                        if (GUILayout.Button("Clear Recipies", GUILayout.Width(150)))
                        {
                            Mods.General.ClearRecipes();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Add Random Recipe", GUILayout.Width(300)))
                        {
                            Mods.General.AddRandomRecipe();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.Label("Extra", labelStyle, GUILayout.Width(300));
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Player Manager", GUILayout.Width(300)))
                        {
                            PlayerManager = !PlayerManager;
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Potion Manager", GUILayout.Width(300)))
                        {
                            PotionManager = !PotionManager;
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Debug Windows", GUILayout.Width(150)))
                        {
                            DebugWindows = !DebugWindows;
                        }
                        if (GUILayout.Button("NPC Manager", GUILayout.Width(150)))
                        {
                            NPCManager = !NPCManager;
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Toggle FPS", warningButton, GUILayout.Width(150)))
                        {
                            Mods.General.ToggleFPS();
                        }
                        if (GUILayout.Button("Gen Spec Q", warningButton, GUILayout.Width(150)))
                        {
                            Mods.General.GenerateSpecialQueue();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        if (GUILayout.Button("Unlock Potion Base", GUILayout.Width(150)))
                        {
                            Mods.General.UnlockPotionBase();
                        }
                        if (GUILayout.Button("Start Next Day", GUILayout.Width(150)))
                        {
                            Mods.General.StartNextDay();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        GUILayout.Label("Press F7 to un/hide this menu. F11 > unload.", labelStyle2, GUILayout.Width(300));
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        GUILayout.Label("Press F8 to un/lock your mouse.", labelStyle2, GUILayout.Width(300));
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(300));
                        GUILayout.Label("Red buttons might cause a crash!", warningButton, GUILayout.Width(300));
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        break;
                    case 1:
                        GUILayout.Space(30);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Audio Test", GUILayout.Width(125), GUILayout.Height(25)))
                        {
                            Mods.DebugWindow.AudioTest();
                        }
                        if (GUILayout.Button("Bellows", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Bellows();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Cursor", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Cursor();
                        }
                        if (GUILayout.Button("Cursor Input", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.CursorInput();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Input", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Input();
                        }
                        if (GUILayout.Button("Mortar", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Mortar();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("NPC", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.NPC();
                        }
                        if (GUILayout.Button("Object Info", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.ObjectInfo();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Pestle Grind", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.PestleGrind();
                        }
                        if (GUILayout.Button("Potion Status", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.PotionStatus();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Print", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Print();
                        }
                        if (GUILayout.Button("Recipe Map", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.RecipeMap();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Recipe Marks", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.RecipeMarks();
                        }
                        if (GUILayout.Button("Rooms", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.Rooms();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Save Load", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.SaveLoad();
                        }
                        if (GUILayout.Button("Slot Conditions", GUILayout.Width(125)))
                        {
                            Mods.DebugWindow.SlotConditions();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        break;
                    case 2:
                        GUILayout.Space(30);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Skip NPC", GUILayout.Width(125), GUILayout.Height(25)))
                        {
                            Mods.General.SkipNPC();
                        }
                        if (GUILayout.Button("Skip All NPCs", GUILayout.Width(125)))
                        {
                            Mods.General.SkipAllNPCs();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Alex Grey", warningButton, GUILayout.Width(125)))
                        {
                            Mods.General.SpawnAlexGrey();
                        }
                        if (GUILayout.Button("Alex Orange", warningButton, GUILayout.Width(125)))
                        {
                            Mods.General.SpawnAlexOrange();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Generous Cutomer", warningButton, GUILayout.Width(125)))
                        {
                            Mods.General.SpawnGenerousCustomer();
                        }
                        if (GUILayout.Button("Rich Trader", warningButton, GUILayout.Width(125)))
                        {
                            Mods.General.SpawnRichTrader();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(250));
                        if (GUILayout.Button("Yoda", warningButton, GUILayout.Width(250)))
                        {
                            Mods.General.SpawnYoda();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        break;
                    case 3:
                        GUILayout.Space(30);
                        GUILayout.BeginHorizontal(GUILayout.Width(200));
                        addInt = (int)GUILayout.HorizontalSlider(addInt, -10000, 10000, GUILayout.Width(200));
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(200));
                        GUILayout.Label($"{addInt}", labelStyle2 , GUILayout.Width(200));
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(200));
                        if (GUILayout.Button("Add Gold", GUILayout.Width(100)))
                        {
                            Mods.Reputation.AddGold(addInt);
                        }
                        if (GUILayout.Button("Add Exp", GUILayout.Width(100)))
                        {
                            Mods.Reputation.AddEXP(addInt);
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(200));
                        if (GUILayout.Button("Add Karma", GUILayout.Width(100)))
                        {
                            Mods.Reputation.AddKarma(addInt);
                        }
                        if (GUILayout.Button("Add Pop", GUILayout.Width(100)))
                        {
                            Mods.Reputation.AddPop(addInt);
                        }
                        GUILayout.EndHorizontal();
                        break;
                    case 4:
                        GUILayout.Space(30);
                        selectedEffect = GUILayout.SelectionGrid(selectedEffect, effects.ToArray(), 3, GUILayout.Width(360));
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(360));
                        if (GUILayout.Button("Log Name", GUILayout.Width(180))) {
                            Logger.Log(effects[selectedEffect], LogType.Blue);
                            Managers.Game.BroadcastMessage($"{effects[selectedEffect]} selected!", SendMessageOptions.DontRequireReceiver);
                        }
                        if (GUILayout.Button("Add to Potion", warningButton, GUILayout.Width(180)))
                        {
                            Mods.Potions.AddPotionEffect(effects[selectedEffect]);
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(360));
                        if (GUILayout.Button("Add Random Potions", GUILayout.Width(180)))
                        {
                            Mods.Potions.AddRandomEffects();
                        }
                        if (GUILayout.Button("Add All Potions", GUILayout.Width(180)))
                        {
                            Mods.Potions.AddAllPotions();
                        }
                        GUILayout.EndHorizontal();
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal(GUILayout.Width(360));
                        if (GUILayout.Button("Add All Effects", warningButton, GUILayout.Width(360)))
                        {
                            Mods.Potions.AddAllEffects();
                        }
                        GUILayout.EndHorizontal();
                        break;
                }   
            }
            GUI.DragWindow();
        }
    }
}
