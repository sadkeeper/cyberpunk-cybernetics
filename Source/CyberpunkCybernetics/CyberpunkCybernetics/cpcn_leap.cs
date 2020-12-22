using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using JecsTools;
using AbilityUser;

namespace CyberpunkCybernetics
{
    public class cpcn_leap : AbilityUser.Verb_UseAbility
    {
        public virtual void Effect()
        {
            if (TargetsAoE[0] is LocalTargetInfo t && t.Cell != default(IntVec3))
            {
                Pawn caster = CasterPawn;
                    FlyingObject flyingObject = (FlyingObject)GenSpawn.Spawn(ThingDef.Named("cpcn_MantisLeap"), CasterPawn.Position, CasterPawn.Map); 
                    flyingObject.Launch(CasterPawn, t.Cell, CasterPawn);
            }
        }
        public override void PostCastShot(bool inResult, out bool outResult)
        {
            if (inResult)
            {
                Effect();
                outResult = true;
            }
            outResult = inResult;
        }
    }
}
