using UnityEngine;

namespace Prodigy.Weapons.Components
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;
        private float finalDamage = 0;
        
        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IDamageable damageable))
                {
                    finalDamage = 0;
                   finalDamage = Random.Range(currentAttackData.AmountMin, currentAttackData.AmountMax);
             

                
                    damageable.Damage(Mathf.RoundToInt(finalDamage + weapon.bonusDamage));
                    
                }
            }
        }


        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            
            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }
    }
}