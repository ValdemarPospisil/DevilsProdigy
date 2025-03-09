using UnityEngine;
using UnityEngine.Serialization;

namespace Prodigy.CoreSystem
{
    public class KnockBackReciever : CoreComponent, IKnockBackable
    {
        [SerializeField] private float maxKnockBackTime = 0.2f;

        private bool isKnockBackActive;
        private float knockBackStartTime;
        private Player player;

        private CoreComp<Movement> movement;
        private CoreComp<CollisionSenses> collisionSenses;

        public override void LogicUpdate()
        {
            CheckKnockBack();
        }

        public void KnockBack(Vector2 angle, float strength, int direction)
        {
            if(player.playerData.isInvulnerable == false)
		{
                movement.Comp?.SetVelocity(strength, angle, direction);
                movement.Comp.CanSetVelocity = false;
                isKnockBackActive = true;
                knockBackStartTime = Time.time;
                
                
        }     
        }

        private void CheckKnockBack()
        {
            if (isKnockBackActive
                && ((movement.Comp?.CurrentVelocity.y <= 0.01f && collisionSenses.Comp.Ground)
                    || Time.time >= knockBackStartTime + maxKnockBackTime)
               )
            {
                isKnockBackActive = false;
                movement.Comp.CanSetVelocity = true;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            movement = new CoreComp<Movement>(core);
            collisionSenses = new CoreComp<CollisionSenses>(core);
        }
    }
}