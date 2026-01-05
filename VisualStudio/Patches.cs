using Unity.VisualScripting;

namespace RepairablesMod;

[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
internal static class CleaningKitPatch
{
    public static void Postfix(ref GearItem __instance)
    {
        int[] gear_counts = [];
        int[] recovery_counts = [];

        if (__instance.name.Contains("GEAR_RifleCleaningKit"))
        {
            gear_counts = [1, 1];

            Repairable repair = __instance.gameObject.AddComponent<Repairable>();
            __instance.m_Repairable = repair;
            if (repair != null)
            {
                repair.m_RequiresToolToRepair = true;
                repair.m_RepairToolChoices = RepairablesUtilities.Tools();
                repair.m_RequiredGear = RepairablesUtilities.RequiredItemList(Repairables.cloth, Repairables.scrapmetal);
                repair.m_RequiredGearUnits = gear_counts;
                repair.m_DurationMinutes = Settings.instance.RifleKitTime;
                repair.m_ConditionIncrease = Settings.instance.RifleKitCondition;
                repair.m_RepairAudio = "Play_RepairingMetal";
            }

            recovery_counts = [1, 1];
            gear_counts = [1];

            Millable mill = __instance.gameObject.AddComponent<Millable>();
            __instance.m_Millable = mill;
            if (mill != null)
            {
                mill.m_CanRestoreFromWornOut = Settings.instance.RifleRepairKitRecover;
                mill.m_RestoreRequiredGear = RepairablesUtilities.RequiredItemList(Repairables.leather, Repairables.scrapmetal);
                mill.m_RestoreRequiredGearUnits = recovery_counts;
                mill.m_RecoveryDurationMinutes = Settings.instance.RifleKitRecoveryTime;
                mill.m_RepairDurationMinutes = Settings.instance.RifleKitMillTime;
                mill.m_RepairRequiredGear = RepairablesUtilities.RequiredSingleItemList(Repairables.scrapmetal);
                mill.m_RepairRequiredGearUnits = gear_counts;
                mill.m_Skill = SkillType.Rifle;
            }
        }
    }
}
[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
internal static class SewingKitPatch
{
    public static void Postfix(ref GearItem __instance)
    {
        int[] gear_counts = [];

        if (__instance.name.Contains("GEAR_SewingKit"))
        {
            gear_counts = [1, 1];

            Repairable repair = __instance.gameObject.AddComponent<Repairable>();
            __instance.m_Repairable = repair;
            if (repair != null)
            {
                repair.m_RequiresToolToRepair = false;
                repair.m_RepairToolChoices = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<ToolsItem>(0);
                repair.m_RequiredGear = RepairablesUtilities.RequiredItemList(Repairables.cloth, Repairables.line);
                repair.m_RequiredGearUnits = gear_counts;
                repair.m_NeverFail = true;
                repair.m_DurationMinutes = Settings.instance.SewingKitRepairTime;
                repair.m_ConditionIncrease = Settings.instance.SewingKitRepairAmount;
                repair.m_RepairAudio = "Play_RepairingCloth";
            }
        }
    }
}
[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
internal static class WhetstonePatch
{
    public static void Postfix(ref GearItem __instance)
    {
        int[] gear_amount = [];

        if (__instance.name.Contains("GEAR_SharpeningStone"))
        {
            gear_amount = [1];

            Repairable repair = __instance.gameObject.AddComponent<Repairable>();
            __instance.m_Repairable = repair;
            if (repair != null)
            {
                repair.m_RequiresToolToRepair = false;
                repair.m_RepairToolChoices = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<ToolsItem>(0);
                repair.m_RequiredGear = RepairablesUtilities.RequiredSingleItemList(Repairables.stone);
                repair.m_RequiredGearUnits = gear_amount;
                repair.m_DurationMinutes = Settings.instance.WhetstonetRepairTime;
                repair.m_ConditionIncrease = Settings.instance.WhetstoneRepairAmount;
                repair.m_RepairAudio = "Play_Sharpening";
            }
        }
    }
}
