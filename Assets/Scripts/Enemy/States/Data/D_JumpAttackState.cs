using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "newJumpAttackStateData", menuName = "Data/State Data/JumpAttack State")]

public class D_JumpAttackState : ScriptableObject
{
    public float JumpAttackSpeed = 10f;
    public float JumpAttackTime = 0.2f;
    public float JumpAttackCooldown = 2f;

    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
     public LayerMask whatIsPlayer;
    public Vector2 JumpAttackAngle;


    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

}
