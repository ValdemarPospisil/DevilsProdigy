using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Jump Buff Data", order = 0)]
    public class JumpBuff : SkillObject
    {   

    [Header("Specific data")]
       public float bonusJumpVelocity;

        public override void Apply( )
        {
            BuffManager.instance.JumpBuff(bonusJumpVelocity);
        }

        
    }
}
