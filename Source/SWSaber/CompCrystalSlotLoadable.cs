using CompSlotLoadable;
using RimWorld;
using Verse;

namespace SWSaber;

public class CompCrystalSlotLoadable : CompSlotLoadable.CompSlotLoadable
{
    public override void TryEmptySlot(SlotLoadable slot)
    {
        if (parent is not { } compOwner)
        {
            base.TryEmptySlot(slot);
            return;
        }

        var compLightsaberActivatableEffect = compOwner.TryGetComp<CompLightsaberActivatableEffect>();
        if (compLightsaberActivatableEffect?.IsActive() == true && !compLightsaberActivatableEffect.TryDeactivate())
        {
            Messages.Message("DeactivateLightsaberFirst", MessageTypeDefOf.RejectInput);
        }
        else
        {
            base.TryEmptySlot(slot);
        }
    }
}