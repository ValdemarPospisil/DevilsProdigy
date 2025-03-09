using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Extra Life Data", order = 0)]
    public class ExtraLife : SkillObject
    {   

    [Header("Specific data")]
       public int bonusAmountOfLifes;

        public override void Apply()
        {
            BuffManager.instance.ExtraLife(bonusAmountOfLifes);
            
        }

        
    }
}
