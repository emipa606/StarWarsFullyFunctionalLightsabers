using System.Reflection;
using HarmonyLib;
using Verse;

namespace SWSaber;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("rimworld.jecrell.starwars.lightsaber").PatchAll(Assembly.GetExecutingAssembly());
    }
}