
using UnityEngine;

namespace Prodigy.CoreSystem
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject[] deathParticles;
        [SerializeField] private int XPAmount;
        [SerializeField] private bool isBoss;
        [SerializeField] private bool isPlayer;
         [SerializeField] private bool isCat;
        [SerializeField] private GameObject portal;
        public GameObject[] coins;
        private int rand;

        private int randomAmountOfCoins;
        [SerializeField] private int minAmountOfCoins;
        [SerializeField] private int maxAmountOfCoins;
        [SerializeField] private GameObject chest;
        private Vector3 offset;
        private SoundManager soundManager;
        private Player player;
        

        private ParticleManager ParticleManager =>
            particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
    
        private ParticleManager particleManager;

        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private Stats stats;


        private void Start() {
            soundManager = FindObjectOfType<SoundManager>();
            player = core.transform.parent.gameObject.GetComponent<Player>();
        }

    
        public void Die()
        {
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
                soundManager.Play("EnemyDead");
            }

            if(isPlayer == false && isCat == false)
            {
                XpManager.instance.AddXP(XPAmount);
                DropCoins();
            }
            
            if(isBoss)
            {
                portal.SetActive(true);
                soundManager.Play("BossDeath");
            }
        
            core.transform.parent.gameObject.SetActive(false);
        }

        public void PlayerDie () {

            
                foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }
                soundManager.Play("Die");
                PlayerManager.instance.PlayerDeath();
                core.transform.parent.gameObject.SetActive(false);

        }

        private void DropCoins () {
            randomAmountOfCoins = Random.Range(minAmountOfCoins, maxAmountOfCoins);
            rand = Random.Range(0, coins.Length);

            for(int i = 0; i < randomAmountOfCoins; i++) {
                rand = Random.Range(0, coins.Length);
                Instantiate(coins[rand], transform.position, Quaternion.identity);
            }

            if(isBoss)
            {
                offset = new Vector3(0, -1.2f, 0);
                Instantiate(chest, transform.position + offset, Quaternion.identity);
            }
        }

        private void OnEnable()
        {
            Stats.Health.OnCurrentValueZero += Die;
        }

        private void OnDisable()
        {
            Stats.Health.OnCurrentValueZero -= Die;
        }
    }
}