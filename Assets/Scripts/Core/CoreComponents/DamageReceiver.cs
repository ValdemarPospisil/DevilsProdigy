using UnityEngine;
using TMPro;

namespace Prodigy.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
        [SerializeField] private GameObject damageParticles;

          private Stats stats;
          private Player player;
        private ParticleManager particleManager;
        [SerializeField]private bool isPlayer = false;
        [SerializeField]private bool isCat = false;

        [SerializeField] private GameObject floatingText;

 

        public void Damage(float amount) {

            if(isPlayer && !player.playerData.isInvulnerable)
            {
                player.playerData.DecreaseHealth(amount);
                particleManager.StartParticlesWithRandomRotation(damageParticles);
                StartCoroutine(BuffManager.instance.Invunerability());
                SoundManager.instance.Play("GetHit");
                player.CheckIfDead();
            }
            else if(isPlayer == false)
            {
                stats.Health.Decrease(amount);
                particleManager.StartParticlesWithRandomRotation(damageParticles);
                ShowDamage(amount.ToString());
                if(isCat)
                {
                    SoundManager.instance.Play("CatHit");
                }
                else
                {
                    SoundManager.instance.Play("Flesh");
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            stats = core.GetCoreComponent<Stats>();
            particleManager = core.GetCoreComponent<ParticleManager>();
        }


        public void ShowDamage (string text) {
            
                GameObject prefab = Instantiate(floatingText, transform.position, Quaternion.identity);
                prefab.GetComponentInChildren<TextMeshPro>().text = text;
            
        }
    }
}