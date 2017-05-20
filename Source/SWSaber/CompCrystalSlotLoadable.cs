﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompSlotLoadable;
using Verse;

namespace SWSaber
{
    public class CompCrystalSlotLoadable : CompSlotLoadable.CompSlotLoadable
    {
        public override void TryEmptySlot(SlotLoadable slot)
        {
            //Log.Message("1");
            if (parent is ThingWithComps compOwner)
            {
                //Log.Message("2"); 

                CompLightsaberActivatableEffect compLightsaberActivatableEffect = compOwner.TryGetComp<CompLightsaberActivatableEffect>();
                if (compLightsaberActivatableEffect != null)
                {
                    //Log.Message("3");

                    if (compLightsaberActivatableEffect.IsActive())
                    {
                        //Log.Message("4");

                        if (!compLightsaberActivatableEffect.TryDeactivate())
                        {
                            //Log.Message("5");

                            Messages.Message("DeactivateLightsaberFirst", MessageSound.RejectInput);
                            return;
                        }
                    }
                }
            }

            base.TryEmptySlot(slot);
        }
    }
}
