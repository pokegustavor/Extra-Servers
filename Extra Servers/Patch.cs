using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static DebugUIBuilder;

namespace Extra_Servers
{
    public class Patch
    {
        static ModdedMenu menu = new ModdedMenu();
        [HarmonyPatch(typeof(PLRegionSelect),"Start")]
        class Start 
        {
            static void Postfix(PLRegionSelect __instance) 
            {
                menu.region = __instance;
            }
        }
        [HarmonyPatch(typeof(PLRegionSelect), "OnEnter")]
        class OnEnter
        {
            static void Postfix(PLRegionSelect __instance)
            {
                menu.CreateButtons();
            }
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> Instructions)
            {
                List<CodeInstruction> instructionsList = Instructions.ToList();
                instructionsList[15].operand = 225f;
                instructionsList[18].operand = 1250f;
                instructionsList[30].operand = 225f;
                instructionsList[50].operand = 225f;
                return instructionsList.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(PLRegionSelect), "GetRegionCode")]
        class GetRegionCode
        {
            static void Postfix(string inRegion, ref CloudRegionCode __result)
            {
                switch (inRegion) 
                {
                    case "sa":
                        __result = CloudRegionCode.sa;
                        break;
                    case "kr":
                        __result = CloudRegionCode.kr;
                        break;
                    case "usw":
                        __result = CloudRegionCode.usw;
                        break;
                    case "cae":
                        __result = CloudRegionCode.cae;
                        break;
                    case "@in":
                        __result = CloudRegionCode.@in;
                        break;
                    case "ru":
                        __result = CloudRegionCode.ru;
                        break;
                    case "rue":
                        __result = CloudRegionCode.rue;
                        break;
                }
            }
        }
        [HarmonyPatch(typeof(PLRegionSelect), "Draw")]
        class Draw
        {
            static void Postfix(PLRegionSelect __instance)
            {
                if (menu.saRegion.Button != null)
                {
                    menu.saRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.saRegion.Label != null)
                {
                    menu.saRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.saRegion.Label.text = "South America" + __instance.GetRegionPing("sa");
                }
                if (menu.krRegion.Button != null)
                {
                    menu.krRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.krRegion.Label != null)
                {
                    menu.krRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.krRegion.Label.text = "Korea" + __instance.GetRegionPing("kr");
                }
                if (menu.uswRegion.Button != null)
                {
                    menu.uswRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.uswRegion.Label != null)
                {
                    menu.uswRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.uswRegion.Label.text = "United States West" + __instance.GetRegionPing("usw");
                }
                if (menu.caeRegion.Button != null)
                {
                    menu.caeRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.caeRegion.Label != null)
                {
                    menu.caeRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.caeRegion.Label.text = "Canada" + __instance.GetRegionPing("cae");
                }
                if (menu.@inRegion.Button != null)
                {
                    menu.@inRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.@inRegion.Label != null)
                {
                    menu.@inRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.@inRegion.Label.text = "India" + __instance.GetRegionPing("@in");
                }
                if (menu.ruRegion.Button != null)
                {
                    menu.ruRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.ruRegion.Label != null)
                {
                    menu.ruRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.ruRegion.Label.text = "Russia" + __instance.GetRegionPing("ru");
                }
                if (menu.rueRegion.Button != null)
                {
                    menu.rueRegion.Button.colors = PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock;
                }
                if (menu.rueRegion.Label != null)
                {
                    menu.rueRegion.Label.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                    menu.rueRegion.Label.text = "Russia East" + __instance.GetRegionPing("rue");
                }
                switch (PLRegionSelect.GetRegionCode(PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("PhotonRegion")))
                {
                    case CloudRegionCode.sa:
                        if (menu.saRegion.Button != null)
                        {
                            menu.saRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.saRegion.Label != null)
                        {
                            menu.saRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.kr:
                        if (menu.krRegion.Button != null)
                        {
                            menu.krRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.krRegion.Label != null)
                        {
                            menu.krRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.usw:
                        if (menu.uswRegion.Button != null)
                        {
                            menu.uswRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.uswRegion.Label != null)
                        {
                            menu.uswRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.cae:
                        if (menu.caeRegion.Button != null)
                        {
                            menu.caeRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.caeRegion.Label != null)
                        {
                            menu.caeRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.@in:
                        if (menu.@inRegion.Button != null)
                        {
                            menu.@inRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.@inRegion.Label != null)
                        {
                            menu.@inRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.ru:
                        if (menu.ruRegion.Button != null)
                        {
                            menu.ruRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.ruRegion.Label != null)
                        {
                            menu.ruRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                    case CloudRegionCode.rue:
                        if (menu.rueRegion.Button != null)
                        {
                            menu.rueRegion.Button.colors = __instance.CurrentRegionColors;
                        }
                        if (menu.rueRegion.Label != null)
                        {
                            menu.rueRegion.Label.color = Color.white;
                            return;
                        }
                        break;
                }
            }
        }
        [HarmonyPatch(typeof(PLUIPlayMenu), "Update")]
        class PlayMenu 
        {
            static void Postfix(PLUIPlayMenu __instance) 
            {
                RoomInfo[] roomList = PhotonNetwork.GetRoomList();
                string stringValue = PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("PhotonRegion");
                string str = " ";
                switch (stringValue) 
                {
                    case "sa":
                        str = "South America";
                        break;
                    case "kr":
                        str = "Korea";
                        break;
                    case "usw":
                        str = "United States West";
                        break;
                    case "cae":
                        str = "Canada";
                        break;
                    case "@in":
                        str = "India";
                        break;
                    case "ru":
                        str = "Russia";
                        break;
                    case "rue":
                        str = "Russia East";
                        break;
                }
                if(str != " ") 
                {
                    __instance.MenuTopText.text = PLLocalize.Localize("Found ", false) + roomList.Length.ToString() + PLLocalize.Localize(" crews - ", false) + str;
                }
            }
        }

    }

    public class ModdedMenu 
    {
        public DBM_Button saRegion;
        public DBM_Button krRegion;
        public DBM_Button uswRegion;
        public DBM_Button caeRegion;
        public DBM_Button @inRegion;
        public DBM_Button ruRegion;
        public DBM_Button rueRegion;
        public PLRegionSelect region;
        public void CreateButtons() 
        {
            float num = 90f;
            float width = 450f;
            float num2 = num * 2f;
            saRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(0f, num2 - num * 5f, width, num), Color.white, "South America", new ButtonClick(ClickSA), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            krRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2, width, num), Color.white, "Korea", new ButtonClick(ClickKR), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            uswRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2 - num , width, num), Color.white, "United States West", new ButtonClick(ClickUSW), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            caeRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2 - num * 1f, width, num), Color.white, "Canada", new ButtonClick(ClickCAE), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            @inRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2 - num * 2f, width, num), Color.white, "India", new ButtonClick(ClickIN), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            ruRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2 - num * 3f, width, num), Color.white, "Russia", new ButtonClick(ClickRU), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);
            rueRegion = (PLUIDynamicBasicMenu.Instance.AddCommand(new DBM_Button(new Rect(455f, num2 - num * 4f, width, num), Color.white, "Russia East", new ButtonClick(ClickRUE), PLUIDynamicBasicMenu.Instance.DefaultButtonColorBlock)) as DBM_Button);

        }
        public void ClickSA() 
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("sa");
        }
        public void ClickKR()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("kr");
        }
        public void ClickUSW()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("usw");
        }
        public void ClickCAE()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("cae");
        }
        public void ClickIN()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("@in");
        }
        public void ClickRU()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("ru");
        }
        public void ClickRUE()
        {
            PLNetworkManager.Instance.MainMenu.CloseActiveMenu();
            region.SelectRegion("rue");
        }
    }
}
