using ModSettings;

namespace RepairablesMod

{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Rifle Cleaning Kit")]

        [Name("Repair Time")]
        [Description("Adjust the amount of time spent repairing Rifle Cleaning Kit. - Default 30 Minutes [Requires scene reload.]")]
        [Slider(5, 45, 9)]
        public int RifleKitTime = 30; // Repair Time in Hands

        [Name("Condition Gained")]
        [Description("Adjust the amount of condition gained after repairing Rifle Cleaning Kit. - Default 25% [Requires scene reload.]")]
        [Slider(10, 50, 9)]
        public int RifleKitCondition = 25;// Condition Gained while repairing in hands

        [Name("Can Be Recovered")]
        [Description("Determines if Rifle Cleaning Kit can be recovered at the Milling Machine. Default - true [Requires scene reload.]")]
        public bool RifleRepairKitRecover = true; //Enables Rifle Kit Recovery

        [Name("Milling Machine - Recovery Time")]
        [Description("Adjust the amount of time spent recovering Rifle Cleaning Kit at the Milling Machine. - Default 60 Minutes [Requires scene reload.]")]
        [Slider(30, 90, 13)]
        public int RifleKitRecoveryTime = 60; // Sets Recovery time

        [Name("Milling Machine - Repair Time")]
        [Description("Adjust the amount of time spent repairing Rifle Cleanng Kit at the milling machine. - Default 25 Minutes [Requires scene reload.]")]
        [Slider(10, 50, 9)]
        public int RifleKitMillTime = 25; // Sets Repair time at the milling machine

        [Section("Sewing Kit")]

        [Name("Repair Time")]
        [Description("Determines the amount of time spent repairing Sewing Kit. Default - 5 Minutes [Requires scene reload.]")]
        [Slider(5, 30, 6)]
        public int SewingKitRepairTime = 5;

        [Name("Condition Gained")]
        [Description("Determines the amount condition gained after repairing Sewing Kit. Default - 25% [Requires scene reload.]")]
        [Slider(10, 50, 9)]
        public int SewingKitRepairAmount = 25;

        [Section("Whetstone")]


        [Name("Repair Time")]
        [Description("Determines the amount of time spent repairing Sewing Kit. Default - 30 Minutes [Requries scene reload.]")]
        [Slider(5, 45, 9)]
        public int WhetstonetRepairTime = 30;

        [Name("Condition Gained")]
        [Description("Determines the amount condition gained after repairing Sewing Kit. Default - 25% [Requires scene reload.]")]
        [Slider(10, 50, 9)]
        public int WhetstoneRepairAmount = 25;


        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. [Requires scene reload.]")]
        public bool ResetSettings = false;

        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
            RefreshGUI();
        }
        internal static void OnLoad()
        {
        }
        public static void ApplyReset()
        {
            if (instance.ResetSettings == true)
            {
                instance.RifleKitCondition = 25;
                instance.RifleKitTime = 30;
                instance.RifleRepairKitRecover = true;
                instance.RifleKitRecoveryTime = 60;
                instance.RifleKitMillTime = 25;
                instance.SewingKitRepairTime= 5;
                instance.SewingKitRepairAmount = 25;
                instance.WhetstoneRepairAmount= 25;
                instance.WhetstonetRepairTime = 30;
            }
        }
    }
}