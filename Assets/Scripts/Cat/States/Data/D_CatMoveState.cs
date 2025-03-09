using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatMoveStateData", menuName = "Data/Cat State Data/Cat Move State")]
public class D_CatMoveState : ScriptableObject
{
    public float movementSpeed = 3f;

     public float minMoveTime = 2f;
    public float maxMoveTime = 6f;
    
}
