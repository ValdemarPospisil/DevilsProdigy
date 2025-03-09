using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Damage Run State")]
public class D_DamageRunState : ScriptableObject
{
    public float chargeSpeed = 6f;

    public float chargeTime = 5f;

    public float attackRadius = 0.5f;
    public float attackDamage = 10f;

    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

    public LayerMask whatIsPlayer;
  
}
 