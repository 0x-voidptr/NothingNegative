using BepInEx;
using HarmonyLib;
using System;
using static FollowerTrait.TraitType;

namespace NothingNegative
{

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        } 
    }

    [HarmonyPatch(typeof(FollowerBrain))]
    [HarmonyPatch(MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(FollowerInfo) })]
    public class Patch_FollowerBrain
    {
        static void Postfix(FollowerBrain __instance)
        {
            Console.WriteLine($"Updating follower with {__instance._directInfoAccess.Traits.Count} traits");
            for (int i = 0; i < __instance._directInfoAccess.Traits.Count; i++)
            {
                Console.WriteLine($"Updating trait {__instance._directInfoAccess.Traits[i]}");
                __instance._directInfoAccess.Traits[i] = __instance._directInfoAccess.Traits[i] switch
                {
                    Germophobe => Coprophiliac,
                    FearOfSickPeople => LoveOfSickPeople,
                    Cynical => Gullible,
                    Libertarian => Disciplinarian,
                    Sickly => IronStomach,
                    NaturallySkeptical => NaturallyObedient,
                    AgainstSacrifice => SacrificeEnthusiast,
                    Faithless => Faithful,
                    Lazy => Industrious,
                    FearOfDeath => DesensitisedToDeath,
                    _ => __instance._directInfoAccess.Traits[i]
                };
            }
        }
    }
}
