using System;
using System.Collections.Generic;
using System.Linq;
using Prodigy.Weapons.Components;
using UnityEngine;

namespace Prodigy.Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private ItemObject data;
        [SerializeField] private ItemDatabase itemDatabase;
        [SerializeField] private bool isPrimary;

        private List<WeaponComponent> componentAlreadyOnWeapon = new List<WeaponComponent>();

        private List<WeaponComponent> componentsAddedToWeapon = new List<WeaponComponent>();

        private List<Type> componentDependencies = new List<Type>();

        private Animator anim;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            if(isPrimary)
            {
                GenerateWeapon(itemDatabase.primaryWeapons[ShowEquippedWeapons.instance.currentPrimaryWeaponID]);
            }
            else
            {
                GenerateWeapon(itemDatabase.secondaryWeapons[ShowEquippedWeapons.instance.currentSecondaryWeaponID]);
            }
        }


        public void GenerateWeapon(ItemObject data)
        {
            if(isPrimary)
            {
                ShowEquippedWeapons.instance.currentPrimaryWeaponID = data.itemID;
            }
            else
            {
                ShowEquippedWeapons.instance.currentSecondaryWeaponID = data.itemID;
            }

            ShowEquippedWeapons.instance.ChangeSprites();
            
            
            weapon.SetData(data);
            
            componentAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();

            componentAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();

            componentDependencies = data.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                if(componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent =
                    componentAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }
                
                weaponComponent.Init();
                
                
                
                componentsAddedToWeapon.Add(weaponComponent);
            }

            var componentsToRemove = componentAlreadyOnWeapon.Except(componentsAddedToWeapon);
            
            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }


            anim.runtimeAnimatorController = data.AnimatorController;
            weapon.AddWeaponBuffs();
        }
    }
}