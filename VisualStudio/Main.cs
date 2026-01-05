using UnityEngine.AddressableAssets;

namespace RepairablesMod
{
    public class Repairables : MelonMod
    {
        public static ToolsItem simpletools;
        public static ToolsItem qualitytools;
        public static ToolsItem HookandLine;
        public static GearItem scrapmetal;
        public static GearItem leather;
        public static GearItem line;
        public static GearItem cloth;
        public static GearItem stone;
        private static bool initialized = false;


        public override void OnInitializeMelon()
        {
            Settings.instance.AddToModSettings("Repairable Repairables");
            Settings.OnLoad();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!initialized)
            {
                LoadItems();
                initialized = true;
            }
        }
        static void LoadItems()
        {
            simpletools = Addressables.LoadAssetAsync<GameObject>("GEAR_SimpleTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem;
            qualitytools = Addressables.LoadAssetAsync<GameObject>("GEAR_HighQualityTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem;
            scrapmetal = Addressables.LoadAssetAsync<GameObject>("GEAR_ScrapMetal").WaitForCompletion().GetComponent<GearItem>();
            leather = Addressables.LoadAssetAsync<GameObject>("GEAR_Leather").WaitForCompletion().GetComponent<GearItem>();
            line = Addressables.LoadAssetAsync<GameObject>("GEAR_Line").WaitForCompletion().GetComponent<GearItem>();
            cloth = Addressables.LoadAssetAsync<GameObject>("GEAR_Cloth").WaitForCompletion().GetComponent<GearItem>();
            stone = Addressables.LoadAssetAsync<GameObject>("GEAR_Stone").WaitForCompletion().GetComponent<GearItem>();
        }
    }
}