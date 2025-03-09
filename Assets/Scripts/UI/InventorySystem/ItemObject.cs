using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Prodigy.Weapons.Components;


    
public enum WeaponMaterial 
{
    Wooden,
    CelestialBronze,
    Iron,
    Mithril,
    Aquamarine,
    Blazestone,
    Serpentine,
    NimbusSteel,
    BlackIce,
    Gold,
    Chrysoberyl,
    Moonstone,
    Onyx
}

public enum ItemType
{
    Swords,
    Polearms,
    HeavyWeaponry,
    LongRangeWeapons
}

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
public class ItemObject : ScriptableObject
{


    public WeaponMaterial mat;
    public ItemType type;
    public int itemID;
     public string Name;
    public Sprite uiDisplay;
    [TextArea(5, 10)]
    public string description;
   

    [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }

    [field: SerializeField] public int NumberOfAttacks { get; private set; }

    [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }
    

 
   
   public T GetData<T>()
        {
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependencies()
        {
            return ComponentData.Select(component => component.ComponentDependency).ToList();
        }

        public void AddData(ComponentData data)
        {
            if(ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null) 
                return;
            
            ComponentData.Add(data);
        }

    
}

    




