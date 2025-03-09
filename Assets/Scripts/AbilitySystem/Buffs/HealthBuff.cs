using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Health Buff Data", order = 0)]
    public class HealthBuff : SkillObject
    {   

    [Header("Specific data")]
       public float bonusHealth;

        public override void Apply()
        {
            BuffManager.instance.HealthBuff(bonusHealth);
        }

        
    }
}
