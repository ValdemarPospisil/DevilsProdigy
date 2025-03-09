using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Extra Jump Data", order = 0)]
    public class ExtraJump : SkillObject
    {   

    [Header("Specific data")]
       public int bonusAmountOfJumps;

        public override void Apply()
        {
            BuffManager.instance.ExtraJump(bonusAmountOfJumps);
        }

        
    }
}
