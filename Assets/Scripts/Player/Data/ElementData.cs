using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newElementsData", menuName ="Data/Player Data/Element Data")]
public class ElementData : ScriptableObject
{
    [Header("Damage")]
    public float acidDamage;
    public float darkDamage;
    public float earthDamage;
    public float fireDamage;
    public float holyDamage;
    public float iceDamage;
    public float thunderDamage;
    public float waterDamage;
    public float windDamage;
    public float woodDamage;
    [Header("Bonus Damage")]
    public float bonusAcidDamage;
    public float bonusDarkDamage;
    public float bonusEarthDamage;
    public float bonusFireDamage;
    public float bonusHolyDamage;
    public float bonusIceDamage;
    public float bonusThunderDamage;
    public float bonusWaterDamage;
    public float bonusWindDamage;
    public float bonusWoodDamage;

    [Header("Weapon Type Bonus Damage")]
    public float swordDamage;
    public float polearmDamage;
    public float heavyDamage;
    public float longRangeDamage;
    
    public float bonusSwordDamage;
    public float bonusPolearmDamage;
    public float bonusHeavyDamage;
    public float bonusLongRangeDamage;

    [Header("Element projectiles")]
    public float acidProjectileSpeed = 12.5f;
    public float darkProjectileSpeed = 14.8f;
    public float earthProjectileSpeed = 10.1f;
    public float fireProjectileSpeed = 15.3f;
    public float holyProjectileSpeed = 13.7f;
    public float iceProjectileSpeed = 11.4f;
    public float thunderProjectileSpeed = 16.2f;
    public float waterProjectileSpeed = 9.8f;
    public float windProjectileSpeed = 17.6f;
    public float natureProjectileSpeed = 8.3f;

    public float acidTravelDistance = 15.2f;
    public float darkTravelDistance = 13.9f;
    public float earthTravelDistance = 12.6f;
    public float fireTravelDistance = 12.6f;
    public float holyTravelDistance = 14.3f;
    public float iceTravelDistance = 15.9f;
    public float thunderTravelDistance = 13.1f;
    public float waterTravelDistance = 17.4f;
    public float windTravelDistance = 18.4f;
    public float natureTravelDistance = 18.8f;

    public float acidProjectileDamage = 12f;
    public float darkProjectileDamage = 14f;
    public float earthProjectileDamage = 16f;
    public float fireProjectileDamage = 18f;
    public float holyProjectileDamage = 16f;
    public float iceProjectileDamage = 12f;
    public float thunderProjectileDamage = 18f;
    public float waterProjectileDamage = 14f;
    public float windProjectileDamage = 14f;
    public float natureProjectileDamage = 10f;
}