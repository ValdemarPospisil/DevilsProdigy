using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatSleepStateData", menuName = "Data/Cat State Data/Cat Sleep State")]

public class D_CatSleepState : ScriptableObject
{
    public float minSleepTime = 4f;
    public float maxSleepTime = 10f;
}
