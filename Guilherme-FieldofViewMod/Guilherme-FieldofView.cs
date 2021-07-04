using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;

namespace FieldofViewMod
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class FieldofViewMod : BaseUnityPlugin
    {
        public const string PluginGUID = "com.source-guilherme.fieldofviewmod";
        public const string PluginName = "FieldofViewMod";
        public const string PluginVersion = "0.0.1";
        private ConfigEntry<float> FloatConfig;

        private void Awake()
        {
            FloatConfig = Config.Bind<float>("Field of View Mod", "Field of View Values", 65f, new ConfigDescription("This will change the Field of View in the game.", new AcceptableValueRange<float>(0f, 180f)));
            On.GameCamera.UpdateCamera += ChangeFOV;
            Jotunn.Logger.LogInfo("Field of View has loaded!");
        }

        private void ChangeFOV(On.GameCamera.orig_UpdateCamera orig, GameCamera self, float dt)
        {
            self.m_fov = FloatConfig.Value;
            orig(self, dt);
        }
    }
}