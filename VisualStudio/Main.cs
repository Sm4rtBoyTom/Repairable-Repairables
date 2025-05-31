using RepairablesMod;
using Il2Cpp;
using Il2CppNewtonsoft.Json.Utilities;
using Il2CppNodeCanvas.Tasks.Actions;
using Il2CppRewired.ComponentControls.Data;
using Il2CppRewired.Utils;
using Il2CppTLD.BigCarry;
using Il2CppTLD.Gear;
using System.Runtime.InteropServices;

namespace RepairablesMod

{	public class Repairables : MelonMod
	{
        public override void OnInitializeMelon()
        {
           Settings.instance.AddToModSettings("Repairable Repairables");
        }
        public static bool Sceneloaded;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (AmmoToolsUtils.IsScenePlayable(sceneName))
            {
                Sceneloaded = true;

                ChangeItemProperties();
            }
        }
        private static void ChangeItemProperties()
        {
            ToolsItem Tool_1;
            ToolsItem Tool_2;
            ToolsItem Tool_3;
            ToolsItem[] toolslist_1;
            ToolsItem[] toolslist_2;
            GearItem[] gearslist;
            GearItem[] restorelist;
            int[] repair_amount = [0];
            int[] restore_amount = [0];

            // Adds Tool For Repairing
            Tool_1 = GearItem.LoadGearItemPrefab("GEAR_SimpleTools").m_ToolsItem;
            Tool_2 = GearItem.LoadGearItemPrefab("GEAR_HighQualityTools").m_ToolsItem;
            Tool_3 = GearItem.LoadGearItemPrefab("GEAR_HookAndLine").m_ToolsItem;
            toolslist_1 = [Tool_1, Tool_2];
            toolslist_2 = [Tool_3];

            GameObject cleaningkit = GearItem.LoadGearItemPrefab("GEAR_RifleCleaningKit").gameObject;
            if(Settings.instance.RifleKitRepairHands == true)  // Repairable Rifle Cleaning Kit

            {
                gearslist = [GearItem.LoadGearItemPrefab("GEAR_Cloth"), GearItem.LoadGearItemPrefab("GEAR_ScrapMetal")];
                repair_amount = [1, 1];

                var repairable = cleaningkit.AddComponent<Repairable>();
                repairable.m_RequiresToolToRepair = true;
                repairable.m_RepairToolChoices = toolslist_1;
                repairable.m_RequiredGear = gearslist;
                repairable.m_RequiredGearUnits = repair_amount;
                repairable.m_DurationMinutes = Settings.instance.RifleKitTime;
                repairable.m_ConditionIncrease = Settings.instance.RifleKitCondition;
                repairable.m_RepairAudio = "Play_RepairingMetal";
            }
            else if (Settings.instance.RifleKitRepairHands == false)
            {
                GameManager.DestroyImmediate(cleaningkit.GetComponent<Repairable>());
            }
            if (Settings.instance.RifleRepairKitMill == true)  // Millable Rifle Cleaning Kit
            {
                gearslist = [GearItem.LoadGearItemPrefab("GEAR_ScrapMetal")];
                restorelist = [GearItem.LoadGearItemPrefab("GEAR_Leather")];
                repair_amount = [1];
                restore_amount = [2];

                var millable = cleaningkit.AddComponent<Millable>();
                millable.m_CanRestoreFromWornOut = Settings.instance.RifleRepairKitRecover;
                millable.m_RestoreRequiredGear = restorelist;
                millable.m_RestoreRequiredGearUnits = restore_amount;
                millable.m_RecoveryDurationMinutes = Settings.instance.RifleKitRecoveryTime;
                millable.m_RepairRequiredGear = gearslist;
                millable.m_RepairRequiredGearUnits = repair_amount;
                millable.m_RepairDurationMinutes = Settings.instance.RifleKitMillTime;
            }
            else if (Settings.instance.RifleRepairKitMill == false) // Repairable Sewing Kit
            {
                GameManager.DestroyImmediate(cleaningkit.GetComponent<Millable>());
            }
            GameObject sewingkit = GearItem.LoadGearItemPrefab("GEAR_SewingKit").gameObject;

            if (Settings.instance.SewingKitRepairHands == true) 
            {
                gearslist = [GearItem.LoadGearItemPrefab("GEAR_Cloth"), GearItem.LoadGearItemPrefab("GEAR_Line")];
                repair_amount = [1, 2];
                var repairable = sewingkit.AddComponent<Repairable>();
                repairable.m_RequiresToolToRepair = false;
                repairable.m_RequiredGear = gearslist;
                repairable.m_RequiredGearUnits = repair_amount;
                repairable.m_DurationMinutes = Settings.instance.SewingKitRepairTime;
                repairable.m_ConditionIncrease = Settings.instance.SewingKitRepairAmount;
                repairable.m_RepairAudio = "Play_RepairingCloth";
            }
            GameObject whetstone = GearItem.LoadGearItemPrefab("GEAR_SharpeningStone").gameObject;

            if (Settings.instance.WhetstoneRepairHands == true)
            {
                gearslist = [GearItem.LoadGearItemPrefab("GEAR_Stone")];
                repair_amount = [1];

                var repairable = whetstone.AddComponent<Repairable>();
                repairable.m_RequiresToolToRepair = false;
                repairable.m_RequiredGear = gearslist;
                repairable.m_RequiredGearUnits = repair_amount;
                repairable.m_DurationMinutes = 30;
                repairable.m_ConditionIncrease = 25;
                repairable.m_RepairAudio = "Play_Sharpening";
            }
        }
    }

}


