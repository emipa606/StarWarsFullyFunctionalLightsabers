using RimWorld;
using Verse;

namespace SWSaber;

public class SaberGlow : ThingComp
{
    public bool Active;
    private CompGlower glower;
    private Map glowerMap;

    private IntVec3 glowerPosition;
    private CompProperties_Glower Props => (CompProperties_Glower)props;
    private Pawn Wearer => (parent.ParentHolder as Pawn_EquipmentTracker)?.pawn;

    public override void Notify_Unequipped(Pawn pawn)
    {
        removeGlower();
        base.Notify_Unequipped(pawn);
    }

    public override void PostDeSpawn(Map map, DestroyMode mode = DestroyMode.Vanish)
    {
        removeGlower();
        base.PostDeSpawn(map, mode);
    }

    public override void PostDestroy(DestroyMode mode, Map previousMap)
    {
        removeGlower();
        base.PostDestroy(mode, previousMap);
    }

    public override void CompTickInterval(int delta)
    {
        if (!Active || glower != null && glowerMap != null &&
            (Wearer is not { Spawned: true } || !PawnRenderUtility.CarryWeaponOpenly(Wearer)))
        {
            removeGlower();
            return;
        }

        if (Wearer is not { Spawned: true } || !PawnRenderUtility.CarryWeaponOpenly(Wearer))
        {
            return;
        }

        if (glower == null)
        {
            addGlower();
        }
        else if (Wearer.Map != glowerMap || Wearer.Position != glowerPosition)
        {
            updateGlower();
        }
    }

    private void updateGlower()
    {
        if (glower == null)
        {
            return;
        }

        //Log.Message($"Updating glower on {Wearer?.LabelCap ?? "NULL"}");
        glowerMap.glowGrid.DeRegisterGlower(glower);
        glowerMap.mapDrawer.MapMeshDirty(glowerPosition, MapMeshFlagDefOf.Things);
        glowerPosition = Wearer.Position;
        glowerMap.glowGrid.RegisterGlower(glower);
        glowerMap.mapDrawer.MapMeshDirty(glowerPosition, MapMeshFlagDefOf.Things);
    }

    private void addGlower()
    {
        if (glower != null)
        {
            removeGlower();
        }

        glower = new CompGlower
        {
            parent = Wearer
        };
        glower.Initialize(Props);
        glowerPosition = Wearer.Position;
        glowerMap = Wearer.Map;
        glowerMap.glowGrid.RegisterGlower(glower);
        glowerMap.mapDrawer.MapMeshDirty(glowerPosition, MapMeshFlagDefOf.Things);
    }

    private void removeGlower()
    {
        if (glower == null)
        {
            return;
        }

        glowerMap.glowGrid.DeRegisterGlower(glower);
        glowerMap.mapDrawer.MapMeshDirty(glowerPosition, MapMeshFlagDefOf.Things);
        glower = null;
        glowerMap = null;
    }
}