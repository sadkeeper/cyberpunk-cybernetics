using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using JecsTools;
using AbilityUser;

namespace Cybernetics
{
    public class AnkleHediff : HediffWithComps
    {

        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostRemoved();
            var comp = pawn.TryGetComp<CompAbilityUser>();

            if (comp == null)
            {
                return;
            }

            var abilityDef = CyberneticsDefOf.cpcn_Jump;
            comp.AddPawnAbility(abilityDef);
            Log.Message("Added");
        }
        public override void PostRemoved()
        {
            base.PostRemoved();
            var comp = pawn.TryGetComp<CompAbilityUser>();

            if (comp == null)
            {
                return;
            }

            var abilityDef = CyberneticsDefOf.cpcn_Jump;
            comp.RemovePawnAbility(abilityDef);
            Log.Message("removed");
        }
    }
}