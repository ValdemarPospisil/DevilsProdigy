using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newData", menuName = "Data/Item Database Data", order = 0)]
public class ItemDatabase : ScriptableObject
{
    public ItemObject[] primaryWeapons;
    public ItemObject[] secondaryWeapons;
    


}

