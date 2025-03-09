using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Invincibility Shield Data", order = 0)]
    public class InvincibilityShield : SkillObject
    {   

    [Header("Specific data")]
       public float shieldOnDuration;
        public float shieldOffDuration;
        public int numberOfFlashes;

        public override void Apply()
        {
            BuffManager.instance.InvincibilityShield(shieldOnDuration, shieldOffDuration, numberOfFlashes);
        }

        
    }
}
