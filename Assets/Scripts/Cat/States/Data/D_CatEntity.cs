using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatEntityData", menuName = "Data/Cat Entity Data/Cat Base Data")]

public class D_CatEntity : ScriptableObject
{

   public float maxHealth = 30f;

   public float DamageHopSpeed = 3f;
   public float ledgeCheckDistance = 0.4f;
   public float wallCheckDistance = 0.2f;
   public float groundCheckRadius = 0.3f;

   public float stunResistance = 3f;
   public float stunRecoveryTime = 1f;

   public float minAgroDistance = 2f;
   public float maxAgroDistance = 4f;

   public float closeRangeActionDistance = 1.2f;

   public GameObject hitParticle;
   

   public LayerMask whatIsGround;
   public LayerMask whatIsPlayer;
}
