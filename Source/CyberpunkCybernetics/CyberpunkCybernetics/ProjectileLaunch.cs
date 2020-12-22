using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using AbilityUser;
using JecsTools;

namespace Cybernetics
{
    public class ProjectileLaunch : AbilityUser.CompAbilityUser
    {


        private bool gaveAbilities = false;

        private bool firstTick = false;

        private bool PLS
        {
            get
            {
                if (Pawn?.health?.hediffSet == null) return false;
                if (Pawn.health.hediffSet.HasHediff(HediffDef.Named("cpcn_PLSdef"))) return true;
                return false;
            }
        }

        public override bool TryTransformPawn() => PLS;

        public override void CompTick()
        {
            if (Pawn?.Spawned != true) return;
            if (Find.TickManager.TicksGame > 200)
            {
                if (PLS)
                {
                    if (!firstTick)
                    {
                        PostInitializeTick();
                    }
                    base.CompTick();
                }
            }

        }

        private void PostInitializeTick()
        {
            if (Pawn?.Spawned != true) return;
            if (Pawn?.story == null) return;
            firstTick = true;
            this.Initialize();
            if (!gaveAbilities)
            {
                gaveAbilities = true;
                this.AddPawnAbility(CyberneticsDefOf.cpcn_PLS);
            }
        }
        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref this.gaveAbilities, "gaveAbilities", false);
        }



    }
}