using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatSitStateData", menuName = "Data/Cat State Data/Cat Sit State")]

public class D_CatSitState : ScriptableObject
{
    public float minSitTime = 2f;
    public float maxSitTime = 6f;
}
