using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine.AddressableAssets;

namespace RepairablesMod
{
    internal static class RepairablesUtilities
    {
        public static Il2CppReferenceArray<GearItem> RequiredItemList(GearItem gear_1, GearItem gear_2)
        {
            GearItem[] list = [gear_1, gear_2];
            return list;
        }
        public static Il2CppReferenceArray<GearItem> RequiredSingleItemList(GearItem gear)
        {
            GearItem[] list = [gear];
            return list;
        }
        public static Il2CppReferenceArray<ToolsItem> Tools()
        {
            ToolsItem[] list = [Addressables.LoadAssetAsync<GameObject>("GEAR_SimpleTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem, Addressables.LoadAssetAsync<GameObject>("GEAR_HighQualityTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem];
            return list;
        }
    }
}


