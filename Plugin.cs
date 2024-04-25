using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LethalCompanyPlushieScript;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("linkoid-DissonanceLagFix-1.0.0", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("mattymatty-AsyncLoggers-1.6.2", BepInDependency.DependencyFlags.SoftDependency)]
public class PlushieItemBehaviourPlugin : BaseUnityPlugin
{
    private const string ModGuid = $"LCM_PlushieItemBehaviour|{ModVersion}";
    private const string ModName = "Lethal Company Plushie Item Behaviour Script";
    private const string ModVersion = "1.0.0";
        
    private readonly Harmony _harmony = new(ModGuid);
        
    // ReSharper disable once InconsistentNaming
    private static readonly ManualLogSource _mls = BepInEx.Logging.Logger.CreateLogSource(ModGuid);

    private static PlushieItemBehaviourPlugin _instance;
        
    private void Awake()
    {
        if (_instance == null) _instance = this;
        
        _harmony.PatchAll();
        _mls.LogInfo($"Plugin {ModName} is loaded!");
    }
}