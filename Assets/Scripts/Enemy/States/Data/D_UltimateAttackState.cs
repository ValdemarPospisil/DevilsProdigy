using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ultimate Attack State")]
public class D_UltimateAttackState : ScriptableObject
{
    public GameObject[] projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 0f;
    public float projectileTravelDistance;
    
}
