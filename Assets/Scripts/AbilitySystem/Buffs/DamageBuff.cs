using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Damage Buff Data", order = 0)]
    public class DamageBuff : SkillObject
    {   

    [Header("Specific data")]

        public float bonusWeaponDamage;
        public ItemType weaponType;

        public override void Apply()
        {
            BuffManager.instance.DamageBuff(bonusWeaponDamage, weaponType);
        }

        
    }
}
