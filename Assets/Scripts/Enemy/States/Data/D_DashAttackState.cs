using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDashAttackStateData", menuName = "Data/State Data/Dash Attack State")]
public class D_DashAttackState : ScriptableObject
{

    public float dashSpeed = 10f;
    public float dashTime = 0.2f;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.2f;

}