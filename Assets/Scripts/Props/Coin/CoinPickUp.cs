using System.Collections;
using System.Collections.Generic;
using Prodigy;
using UnityEngine;

    public class CoinPickUp : MonoBehaviour
    {

        public enum pickUpObject{COIN, GEM};
        public pickUpObject currentObject;
        [SerializeField] private int coinValue;

        private Rigidbody2D itemRb;
        private BoxCollider2D box;
        private CircleCollider2D circle;
        public float dropForce = 5;
         public float waitTime = 0.5f; 
        private GameObject player;
        private Vector2 dropAngle;
        private bool picked = false;
        private float waitTimeToDestroy = 5;


        void Start() {
            itemRb = GetComponent<Rigidbody2D>();
            box = GetComponent<BoxCollider2D>();
            circle = GetComponent<CircleCollider2D>();

            player = GameObject.FindWithTag("Player");

            dropAngle = new Vector2(Random.Range(-1, 2), 1);
            
            
            
            itemRb.AddForce(dropAngle * dropForce, ForceMode2D.Impulse);   
            box.enabled = false;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), circle);
            Destroy(gameObject, waitTimeToDestroy);
        }

        void Update() {
            if(waitTime <= 0)
            {
                box.enabled = true;
            }
            else
            {
                waitTime -= Time.deltaTime;

            }    
        }

       

    void OnTriggerEnter2D(Collider2D collision) {
            
            if(collision.transform.tag == "Player" && !picked)
            {
                picked = true;
                StartCoroutine(CurrencyCounter.instance.AddCurrency(coinValue));
                Destroy(gameObject);
                SoundManager.instance.Play("Coin");
            }
        }
        
    }
