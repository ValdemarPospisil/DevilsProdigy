using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Heal Data", order = 0)]
    public class Heal : SkillObject
    {   

    [Header("Specific data")]
       public float healAmount;

        public override void Apply()
        {
            BuffManager.instance.Heal(healAmount);
        }

        
    }
}
