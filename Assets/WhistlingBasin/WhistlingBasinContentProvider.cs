using R2API;
using RoR2.ContentManagement;
using UnityEngine;
using RoR2;
using System.Collections;
using System;
using Path = System.IO.Path;
using System.Linq;
using ShaderSwapper;
using System.Collections.Generic;

namespace whistlingbasin
{
    public class WhistlingBasinContent : IContentPackProvider
    {
        public string identifier => WhistlingBasinMain.GUID;

        public static ReadOnlyContentPack readOnlyContentPack => new ReadOnlyContentPack(WhistlingBasinContentPack);
        internal static ContentPack WhistlingBasinContentPack { get; } = new ContentPack();

        internal const string ScenesAssetBundleFileName = "whistlingbasinscene";
        internal const string AssetsAssetBundleFileName = "whistlingbasinassets";

        internal const string MusicSoundBankFileName = "WBasin_Music.bnk";
        internal const string InitSoundBankFileName = "WBasin_Init.bnk";
        // internal const string SoundsSoundBankFileName = "WhistlingBasinSounds.bnk";

        private static AssetBundle scenesAssetBundle;
        private static AssetBundle contentAssetBundle;

        public static SceneDef WhistlingBasinSceneDef;

        public IEnumerator LoadStaticContentAsync(LoadStaticContentAsyncArgs args)
        {
            var musicFolderFullPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(WhistlingBasinContent).Assembly.Location), "soundbanks");
            LoadSoundBanks(musicFolderFullPath);

            yield return LoadAssetBundle(
                Path.Combine(WhistlingBasinMain.assetBundleDir, ScenesAssetBundleFileName),
                args.progressReceiver,
                (assetBundle) => scenesAssetBundle = assetBundle);

            yield return LoadAssetBundle(
                Path.Combine(WhistlingBasinMain.assetBundleDir, AssetsAssetBundleFileName),
                args.progressReceiver,
                (assetBundle) => contentAssetBundle = assetBundle);

            yield return LoadAllAssetsAsync(contentAssetBundle, args.progressReceiver, (Action<SceneDef[]>)((assets) =>
            {
                WhistlingBasinSceneDef = assets.First(sceneDef => sceneDef.cachedName == "whistlingbasin");
                WhistlingBasinContentPack.sceneDefs.Add(assets);
            }));

            var upgradeStubbedShaders = contentAssetBundle.UpgradeStubbedShadersAsync();
            while (upgradeStubbedShaders.MoveNext())
            {
                yield return upgradeStubbedShaders.Current;
            }

            yield return LoadAllAssetsAsync(contentAssetBundle, args.progressReceiver, (Action<UnlockableDef[]>)((assets) =>
            {
                WhistlingBasinContentPack.unlockableDefs.Add(assets);
            }));

            R2API.StageRegistration.RegisterSceneDefToNormalProgression(WhistlingBasinSceneDef);
        }

        private IEnumerator LoadAssetBundle(string assetBundleFullPath, IProgress<float> progress, Action<AssetBundle> onAssetBundleLoaded)
        {
            var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(assetBundleFullPath);
            while (!assetBundleCreateRequest.isDone)
            {
                progress.Report(assetBundleCreateRequest.progress);
                yield return null;
            }

            onAssetBundleLoaded(assetBundleCreateRequest.assetBundle);

            yield break;
        }

        public IEnumerator GenerateContentPackAsync(GetContentPackAsyncArgs args)
        {
            ContentPack.Copy(WhistlingBasinContentPack, args.output);
            args.ReportProgress(1f);
            yield break;
        }

        public IEnumerator FinalizeAsync(FinalizeAsyncArgs args)
        {
            args.ReportProgress(1f);
            yield break;
        }

        private void AddSelf(ContentManager.AddContentPackProviderDelegate addContentPackProvider)
        {
            addContentPackProvider(this);
        }

        internal WhistlingBasinContent()
        {
            ContentManager.collectContentPackProviders += AddSelf;
        }

        private static IEnumerator LoadAllAssetsAsync<T>(AssetBundle assetBundle, IProgress<float> progress, Action<T[]> onAssetsLoaded) where T : UnityEngine.Object
        {
            var sceneDefsRequest = assetBundle.LoadAllAssetsAsync<T>();
            while (!sceneDefsRequest.isDone)
            {
                progress.Report(sceneDefsRequest.progress);
                yield return null;
            }

            onAssetsLoaded(sceneDefsRequest.allAssets.Cast<T>().ToArray());

            yield break;
        }

        internal static void LoadSoundBanks(string soundbanksFolderPath)
        {
            var akResult = AkSoundEngine.AddBasePath(soundbanksFolderPath);
            WhistlingBasinMain.LogInfo($"AddBasePath result: {akResult} | Path: {soundbanksFolderPath}");

            akResult = AkSoundEngine.LoadBank(InitSoundBankFileName, out var _);

            // akResult = AkSoundEngine.LoadBank(SoundsSoundBankFileName, out var _);
            
            akResult = AkSoundEngine.LoadBank(MusicSoundBankFileName, out var _);
            
        }

    }

}