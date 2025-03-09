using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Dash Buff Data", order = 0)]
    public class DashBuff : SkillObject
    {   

    [Header("Specific data")]
       public float bonusDashVelocity;
       public float minusDashCooldown;

        public override void Apply()
        {
            BuffManager.instance.DashBuff(bonusDashVelocity, minusDashCooldown);
        }

        
    }
}
