using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class D_Entity : ScriptableObject
{


   public float ledgeCheckDistance = 0.4f;
   public float wallCheckDistance = 0.2f;
   public float groundCheckRadius = 0.3f;

   public float stunRecoveryTime = 1f;

   public float minAgroDistance = 2f;
   public float maxAgroDistance = 4f;
   public float dashAgroDistance = 4f;

   public float closeRangeActionDistance = 1.2f;

   

   public LayerMask whatIsGround;
   public LayerMask whatIsPlayer;
}
