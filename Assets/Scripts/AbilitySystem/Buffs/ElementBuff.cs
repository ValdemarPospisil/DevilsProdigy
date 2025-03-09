using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Element Buff Data", order = 0)]
    public class ElementBuff : SkillObject
    {   

    [Header("Specific data")]

        public Element element;
        public float bonusElementDamage;

        public override void Apply()
        {
            BuffManager.instance.ElementBuff(bonusElementDamage, element);
        }

        
    }
}
