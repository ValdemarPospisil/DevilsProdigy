using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOld : MonoBehaviour
{

    private float speed;
    private float travelDistance;
    private float xStartPos;
    private float damage;
    [SerializeField]private bool hasImpact;
    [SerializeField]private bool isDown;
    private bool damageDealt;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGravityOn;
    private bool hasHitGround;


    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform[] damagePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (isDown)
        {
            rb.gravityScale = gravity;
        }
        else
        {
            rb.gravityScale = 0.0f;
            rb.linearVelocity = transform.right * speed;
        }


        isGravityOn = false;

        xStartPos = transform.position.x;
    }

    private void Update()
    {
        if (!hasHitGround)
        {

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            for(int i = 0; i < damagePosition.Length; i++) {
                
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition[i].position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition[i].position, damageRadius, whatIsGround);
            

            if (damageHit)
            {
                //damageHit.transform.SendMessage("Damage", attackDetails);
                Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition[i].position, damageRadius, whatIsPlayer);

                    foreach (Collider2D collider in detectedObjects) {
		        
                    IDamageable damageable = collider.GetComponent<IDamageable>();
                    
                        if (damageable != null && !damageDealt) {
				                damageable.Damage(damage);
                                damageDealt = true;
			            }

                    }
                rb.linearVelocity = Vector2.zero;

                if(hasImpact)
                {
                    anim.SetTrigger("Impact");
                }
                else
                {
                    Destroy(gameObject);   
                }
            }

            if (groundHit)
            {
                hasHitGround = true;
                rb.gravityScale = 0f;
                rb.linearVelocity = Vector2.zero;

               
                    anim.SetTrigger("Impact");
               
                
            }


            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }
        }        
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        this.damage = damage;
    }

    private IEnumerator DestroyAfterSeconds()
    {  
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }

   
    private void OnDrawGizmos()
    {
        for(int i = 0; i < damagePosition.Length; i++) {
            
            Gizmos.DrawWireSphere(damagePosition[i].position, damageRadius);
        }
    }
}