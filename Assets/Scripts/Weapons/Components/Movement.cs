using Prodigy.Weapons.Components;
using UnityEngine;

namespace Prodigy.Weapons.Components
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {
        private CoreSystem.Movement coreMovement;

        private CoreSystem.Movement CoreMovement =>
            coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);
        
        private void HandleStartMovement()
        {
            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);

            switch (weapon.Data.type)
               {
                    case ItemType.Swords:
                    SoundManager.instance.Play("Sword");
                    break;
                    case ItemType.Polearms:
                    SoundManager.instance.Play("Polearm");
                    break;
                    case ItemType.HeavyWeaponry:
                    SoundManager.instance.Play("Heavy");
                    break;
               }
        }

        private void HandleStopMovement()
        {
            CoreMovement.SetVelocityX(0.0f);
            switch (weapon.Data.type)
               {
                    case ItemType.LongRangeWeapons:
                    SoundManager.instance.Play("BowDraw");
                    break;
               }
        }

         protected override void Start()
        {
            base.Start();

            EventHandler.OnStartMovement += HandleStartMovement;
            EventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            EventHandler.OnStartMovement -= HandleStartMovement;
            EventHandler.OnStopMovement -= HandleStopMovement;
        }
    }
}