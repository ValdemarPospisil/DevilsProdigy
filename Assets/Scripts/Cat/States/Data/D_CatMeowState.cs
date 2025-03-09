using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatMeowStateData", menuName = "Data/Cat State Data/Cat Meow State")]

public class D_CatMeowState : ScriptableObject
{
    public float minMeowTime = 1f;
    public float maxMeowTime = 3f;
}
