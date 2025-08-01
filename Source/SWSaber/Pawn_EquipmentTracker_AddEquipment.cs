using HarmonyLib;
using RimWorld;
using Verse;

namespace SWSaber;

[HarmonyPatch(typeof(Pawn_EquipmentTracker), nameof(Pawn_EquipmentTracker.AddEquipment))]
public static class Pawn_EquipmentTracker_AddEquipment

{
    public static void Postfix(ThingWithComps newEq, Pawn ___pawn)
    {
        var lightsaberEffect = newEq.TryGetComp<CompLightsaberActivatableEffect>();
        if (lightsaberEffect == null)
        {
            return;
        }

        if (___pawn?.Faction == null)
        {
            return;
        }

        if (___pawn.Faction == Faction.OfPlayerSilentFail)
        {
            return;
        }

        var crystalSlot = newEq.GetComp<CompCrystalSlotLoadable>();
        if (crystalSlot == null)
        {
            return;
        }

        Utility.CrystalSlotter(crystalSlot, lightsaberEffect);
    }
}