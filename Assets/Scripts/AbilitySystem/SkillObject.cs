using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public enum SkillType 
{
  Common,
  Uncommon,
  Rare,
  Epic,
  Legendary
   
}

[CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Skill Data", order = 0)]
public abstract class SkillObject : ScriptableObject
{


    public SkillType type;
   
    
    public Sprite uiDisplay;
    public string nameOfSkill;
    [TextArea(15, 20)]
    public string description;


    public abstract void Apply();

}



