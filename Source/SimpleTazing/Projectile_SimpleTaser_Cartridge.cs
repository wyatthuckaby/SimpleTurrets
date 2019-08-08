using System;
using RimWorld;
using Verse;

namespace SimpleTasing
{
    public class Projectile_SimpleTaser_Cartridge : Bullet
    {
        public ThingDef_SimpleTaser_HediffBullet Def
        {
            get
            {
                return this.def as ThingDef_SimpleTaser_HediffBullet;
            }
        }

        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);
            Pawn pawn;
            if (this.Def != null && hitThing != null && (pawn = (hitThing as Pawn)) != null)
            {
                if (!pawn.RaceProps.IsFlesh)
                {
                    return;
                }
                foreach (HediffDef def in this.Def.HediffsToAdd)
                {
                    if (Rand.Value <= this.Def.AddHediffChance)
                    {
                        Hediff hediff;
                        if (pawn == null)
                        {
                            hediff = null;
                        }
                        else
                        {
                            Pawn_HealthTracker health = pawn.health;
                            if (health == null)
                            {
                                hediff = null;
                            }
                            else
                            {
                                HediffSet hediffSet = health.hediffSet;
                                hediff = hediffSet?.GetFirstHediffOfDef(def, false);
                            }
                        }
                        Hediff hediff2 = hediff;
                        float num = Rand.Range(0.25f, 0.4285f) / (float)Math.Pow((double)pawn.RaceProps.baseBodySize, 1.5);
                        if (hediff2 != null)
                        {
                            hediff2.Severity += num;
                        }
                        else
                        {
                            Hediff hediff3 = HediffMaker.MakeHediff(def, pawn, null);
                            hediff3.Severity = num;
                            pawn.health.AddHediff(hediff3, null, null, null);
                        }
                    }
                }
            }
        }
    }
}
