using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Heal Over Time Data", order = 0)]
    public class HealOverTime : SkillObject
    {   

    [Header("Specific data")]
       public float healAmount;
       public int regenDuration;

        public override void Apply()
        {
            BuffManager.instance.HealOverTime(healAmount, regenDuration);
        }

        
    }
}
