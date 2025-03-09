using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    public Text healthText;
    public Slider healthSlider;

    private float currentHealth;

  //  private GameManager GM;

    private void Start()
    {
        currentHealth = maxHealth;
    //    GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthSlider.value = 1;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = CalculateHealthPercentage();

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
    //    GM.Respawn();
        Destroy(gameObject);
    }


      float CalculateHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
