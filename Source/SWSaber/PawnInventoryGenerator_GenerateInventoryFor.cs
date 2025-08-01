using HarmonyLib;
using RimWorld;
using Verse;

namespace SWSaber;

[HarmonyPatch(typeof(PawnInventoryGenerator), nameof(PawnInventoryGenerator.GenerateInventoryFor))]
public static class PawnInventoryGenerator_GenerateInventoryFor
{
    public static void Postfix(Pawn p)
    {
        if (!Utility.AreFactionsLoaded())
        {
            return;
        }

        if (p.kindDef?.defName is "PJ_ImpCommander" or "PJ_RebCouncilman" or "PJ_ScumBoss")
        {
            Utility.GenerateCrystalFor(p);
        }
    }
}