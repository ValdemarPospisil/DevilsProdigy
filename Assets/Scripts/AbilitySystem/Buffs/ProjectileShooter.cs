using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Prodigy
{

    [CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Projectile Shooter Data", order = 0)]
    public class ProjectileShooter : SkillObject
    {   

    [Header("Specific data")]

        public Element element;
       public GameObject projectile;
       
       public float projectileSpeed;
       public float travelDistance;
       public float damage;
       public bool isBack;
       private BuffManager buffManager;

        public override void Apply()
        {
           BuffManager.instance.ShootProjectiles(element);
        }

        
    }

   public enum Element 
   {
        Acid, 
        Dark, 
        Earth,
        Fire,
        Holy,
        Ice,
        Thunder,
        Water,
        Wind,
        Nature,
    }
}
