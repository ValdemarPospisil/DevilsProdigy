using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCatLickStateData", menuName = "Data/Cat State Data/Cat Lick State")]

public class D_CatLickState : ScriptableObject
{
    public float minlickTime = 2f;
    public float maxlickTime = 6f;
}
