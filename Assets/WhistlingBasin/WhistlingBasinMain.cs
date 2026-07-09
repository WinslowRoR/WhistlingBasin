using BepInEx;
using System.IO;
using UnityEngine;
using HG;
using RoR2.ContentManagement;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

namespace whistlingbasin
{
    #region Dependencies
    [BepInDependency("___riskofthunder.RoR2BepInExPack")]
    #endregion
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class WhistlingBasinMain : BaseUnityPlugin
    {
        public const string GUID = "com.Winslow.WhistlingBasin";
        public const string MODNAME = "WhistlingBasin";
        public const string VERSION = "1.0.0";

        public static PluginInfo pluginInfo { get; private set; }
        public static WhistlingBasinMain instance { get; private set; }
        internal static AssetBundle assetBundle { get; private set; }
        internal static string assetBundleDir => Path.Combine(Path.GetDirectoryName(pluginInfo.Location));

        private void Awake()
        {
            instance = this;
            pluginInfo = Info;
            new WhistlingBasinContent();
            On.RoR2.MusicController.StartIntroMusic += MusicController_StartIntroMusic;

        }

        private void MusicController_StartIntroMusic(On.RoR2.MusicController.orig_StartIntroMusic orig, RoR2.MusicController self)
        {
            orig(self);
            AkSoundEngine.PostEvent("WhistlingBasin_Play_Music_System", self.gameObject);
        }

        internal static void LogFatal(object data)
        {
            instance.Logger.LogFatal(data);
        }
        internal static void LogError(object data)
        {
            instance.Logger.LogError(data);
        }
        internal static void LogWarning(object data)
        {
            instance.Logger.LogWarning(data);
        }
        internal static void LogMessage(object data)
        {
            instance.Logger.LogMessage(data);
        }
        internal static void LogInfo(object data)
        {
            instance.Logger.LogInfo(data);
        }
        internal static void LogDebug(object data)
        {
            instance.Logger.LogDebug(data);
        }
    }
}
