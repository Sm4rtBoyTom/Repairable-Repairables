using ModSettings;

namespace RepairablesMod

{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Rifle Cleaning Kit")]

        [Name("Hand Repairs")]
        [Description("Determines if Rifle Cleaning Kit can be repaired in hands. Default - false [Requies scene reload.]")]
        public bool RifleKitRepairHands = false; // Enables Hand Repairs

        [Name("Repair Time")]
        [Description("Adjust the amount of time spent repairing Rifle Cleaning Kit. - Default 30 Minutes [Requies scene reload.]")]
        [Slider(5, 45, 9)]
        public int RifleKitTime = 30; // Repair Time in Hands

        [Name("Repair Amount")]
        [Description("Adjust the amount of condition gained after repairing Rifle Cleaning Kit. - Default 25% [Requies scene reload.]")]
        [Slider(10, 50, 9)]
        public int RifleKitCondition = 25;// Condition Gained while repairing in hands

        [Name("Milling Machine")]
        [Description("Determines if Rifle Cleaning Kit can be repaired at the Milling Machine. Default - true [Requies scene reload.]")]
        public bool RifleRepairKitMill = true; // Enables Repairing at the milling Machine

        [Name("Can Be Recovered")]
        [Description("Determines if Rifle Cleaning Kit can be recovered at the Milling Machine. Default - true [Requies scene reload.]")]
        public bool RifleRepairKitRecover = true; //Enables Rifle Kit Recovery

        [Name("Recovery Time")]
        [Description("Adjust the amount of time spent recovering Rifle Cleaning Kit at the Milling Machine. - Default 60 Minutes [Requies scene reload.]")]
        [Slider(30, 90, 13)]
        public int RifleKitRecoveryTime = 60; // Sets Recovery time

        [Name("Repair Time")]
        [Description("Adjust the amount of time spent repairing Rifle Cleanng Kit at the milling machine. - Default 25 Minutes [Requies scene reload.]")]
        [Slider(10, 50, 9)]
        public int RifleKitMillTime = 25; // Sets Repair time at the milling machine

        [Section("Sewing Kit")]

        [Name("Hand Repairs")]
        [Description("Determines if Sewing Kit can be repair in hands. Default - true [Requies scene reload.]")]
        public bool SewingKitRepairHands = true;

        [Name("Repair Time")]
        [Description("Determines the amount of time spent repairing Sewing Kit. Default - 5 Minutes [Requies scene reload.]")]
        [Slider(5, 30, 6)]
        public int SewingKitRepairTime = 5;

        [Name("Repair Amount")]
        [Description("Determines the amount condition gained after repairing Sewing Kit. Default - 25% [Requies scene reload.]")]
        [Slider(10, 50, 9)]
        public int SewingKitRepairAmount = 25;

        [Section("Whetstone")]

        [Name("Hand Repairs")]
        [Description("Determines if Whetstone can be repair in hands. Default - true [Requies scene reload.]")]
        public bool WhetstoneRepairHands = true;

        [Name("Repair Time")]
        [Description("Determines the amount of time spent repairing Sewing Kit. Default - 30 Minutes [Requies scene reload.]")]
        [Slider(5, 45, 9)]
        public int WhetstonetRepairTime = 30;

        [Name("Repair Amount")]
        [Description("Determines the amount condition gained after repairing Sewing Kit. Default - 25% [Requies scene reload.]")]
        [Slider(10, 50, 9)]
        public int WhetstoneRepairAmount = 25;

        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. [Requies scene reload.]")]
        public bool ResetSettings = false;

        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue) => RefreshFields();

        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
            RefreshGUI();
        }
        internal static void OnLoad()
        {
            instance.RefreshFields();
        }
        internal void RefreshFields()
        {
            if (instance.RifleKitRepairHands == true) 
            {
                SetFieldVisible(nameof(instance.RifleKitTime), true);
                SetFieldVisible(nameof(instance.RifleKitCondition), true);
            }
            else
            {
                SetFieldVisible(nameof(instance.RifleKitTime), false);
                SetFieldVisible(nameof(instance.RifleKitCondition), false);
            }
            if (instance.RifleRepairKitMill == true)
            {
                SetFieldVisible(nameof(instance.RifleRepairKitRecover), true);
                SetFieldVisible(nameof(instance.RifleKitRecoveryTime), true);
                SetFieldVisible(nameof(instance.RifleKitMillTime), true);
            }
            else
            {
                SetFieldVisible(nameof(instance.RifleRepairKitRecover), false);
                SetFieldVisible(nameof(instance.RifleKitRecoveryTime), false);
                SetFieldVisible(nameof(instance.RifleKitMillTime), false);
            }
            if (instance.RifleRepairKitRecover == true)
            {
                SetFieldVisible(nameof(instance.RifleKitRecoveryTime), true);
            }
            else
            {
                SetFieldVisible(nameof(instance.RifleKitRecoveryTime), false);
            }
            if (instance.SewingKitRepairHands == true)
            {
                SetFieldVisible(nameof(instance.SewingKitRepairAmount), true);
                SetFieldVisible(nameof(instance.SewingKitRepairTime), true);
            }
            else
            {
                SetFieldVisible(nameof(instance.SewingKitRepairAmount), false);
                SetFieldVisible(nameof(instance.SewingKitRepairTime), false);
            }
            if (instance.WhetstoneRepairHands == true)
            {
                SetFieldVisible(nameof(instance.WhetstoneRepairAmount), true);
                SetFieldVisible(nameof(instance.WhetstonetRepairTime), true);
            }
            else
            {
                SetFieldVisible(nameof(instance.WhetstoneRepairAmount), false);
                SetFieldVisible(nameof(instance.WhetstonetRepairTime), false);
            }
        }
        public static void ApplyReset()
        {
            if (instance.ResetSettings == true)
            {
                instance.RifleKitRepairHands = false;
                instance.RifleRepairKitMill = true;
                instance.RifleKitCondition = 25;
                instance.RifleKitTime = 30;
                instance.RifleRepairKitRecover = true;
                instance.RifleKitRecoveryTime = 60;
                instance.RifleKitMillTime = 25;
                instance.SewingKitRepairHands= true;
                instance.SewingKitRepairTime= 5;
                instance.SewingKitRepairAmount = 25;
                instance.WhetstoneRepairHands= true;
                instance.WhetstoneRepairAmount= 25;
                instance.WhetstonetRepairTime = 30;
            }
        }
    }
}