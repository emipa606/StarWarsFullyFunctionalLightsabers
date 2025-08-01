using CompSlotLoadable;
using RimWorld;
using Verse;

namespace SWSaber;

public class CompLightsaberActivatableEffect : CompActivatableEffect.CompActivatableEffect
{
    private SaberGlow Glower;

    public override Graphic PostGraphicEffects(Graphic graphic)
    {
        if (graphic == null || graphic.Shader == null ||
            parent.AllComps.FirstOrDefault(x => x is CompSlotLoadable.CompSlotLoadable) is
                not CompSlotLoadable.CompSlotLoadable comp ||
            comp.Slots.FirstOrDefault(x =>
                ((SlotLoadableDef)x.def).doesChangeColor) is not { } colorSlot ||
            colorSlot.SlotOccupant?.TryGetComp<CompSlottedBonus>() is not { } slotBonus)
        {
            return base.PostGraphicEffects(graphic);
        }

        var result = graphic.GetColoredVersion(graphic.Shader, slotBonus.Props.color, slotBonus.Props.color);
        return result ?? base.PostGraphicEffects(graphic);
    }

    public override bool CanActivate()
    {
        if (!parent.SpawnedOrAnyParentSpawned)
        {
            return false;
        }

        var comp = parent.AllComps.FirstOrDefault(x => x is CompSlotLoadable.CompSlotLoadable);
        if (comp != null)
        {
            var compSlotLoadable = comp as CompSlotLoadable.CompSlotLoadable;
            var colorSlot =
                compSlotLoadable?.Slots.FirstOrDefault(x => ((SlotLoadableDef)x.def).doesChangeColor);
            if (colorSlot?.SlotOccupant != null)
            {
                return true;
            }
        }

        Messages.Message("KyberCrystalRequired".Translate(), MessageTypeDefOf.RejectInput);

        return false;
    }

    public override void Activate()
    {
        base.Activate();
        makeGlower();
    }

    private void makeGlower()
    {
        if (!LoadedModManager.GetMod<SWSaberMod>().GetSettings<SWSaberSettings>().LightsabersGlowEffect)
        {
            return;
        }

        Glower = parent.GetComp<SaberGlow>();
        Glower.props = new CompProperties_Glower
        {
            compClass = typeof(SaberGlow),
            glowRadius = 5f,
            glowColor = ColorIntUtility.AsColorInt(
                parent.TryGetComp<CompSlotLoadable.CompSlotLoadable>()?.Slots
                    .FirstOrDefault(x => ((SlotLoadableDef)x.def).doesChangeColor)?.SlotOccupant
                    ?.TryGetComp<CompSlottedBonus>()?.Props.color ?? ColorLibrary.Violet),
            overlightRadius = 5f
        };
        Glower.Active = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        try
        {
            Glower.Active = false;
        }
        catch
        {
            // ignored
        }
    }
}