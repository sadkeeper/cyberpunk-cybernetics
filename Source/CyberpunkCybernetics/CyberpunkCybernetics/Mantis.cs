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



    public class MantisHediff : HediffWithComps
    {

        public override void PostAdd(DamageInfo? dinfo)
        {
            Log.Message("Added");
        }
        public override void PostRemoved()
        {
            Log.Message("removed");
        }
    }
}

