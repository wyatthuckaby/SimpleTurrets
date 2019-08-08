using System;
using System.Collections.Generic;
using Verse;

namespace SimpleTasing
{
    public class ThingDef_SimpleTaser_HediffBullet : ThingDef
    {
        public float AddHediffChance;

        public List<HediffDef> HediffsToAdd;
    }
}
