﻿using Verse;
using HarmonyLib;

namespace SWSaber
{
    class SaberGlow : CompGlower
    {
        //bool spawnHandled = false;

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            try
            {
                Traverse.Create(this).Field("glowOnInt").SetValue(true);
                parent.MapHeld.glowGrid.RegisterGlower(this);
            }
            catch { }
        }
        
        IntVec3 pos = IntVec3.Invalid;

        public void GlowTick(object state)
        {
            try
            {
                parent.Map.glowGrid.MarkGlowGridDirty(parent.Position);
            }
            catch { }
            {
                //We're interested in this, but not the end users.
                //Log.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }


        public override void CompTick()
        {
            try
            {
                parent.Map.glowGrid.MarkGlowGridDirty(parent.Position);
            }
            catch { }
        }

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            try
            {
                parent.Map.glowGrid.DeRegisterGlower(this);
                base.PostDestroy(mode, previousMap);
            }
            catch { }
        }
    }
}