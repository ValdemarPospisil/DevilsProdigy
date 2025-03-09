using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Movement Buff Data", order = 0)]
    public class MovementBuff : SkillObject
    {   

    [Header("Specific data")]
       public float bonusMovementVelocity;

        public override void Apply()
        {
            BuffManager.instance.MovementBuff(bonusMovementVelocity);
        }

        
    }
}
