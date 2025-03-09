using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatItchStateData", menuName = "Data/Cat State Data/Cat Itch State")]

public class D_CatItchState : ScriptableObject
{
    public float minItchTime = 1f;
    public float maxItchTime = 2f;
}
