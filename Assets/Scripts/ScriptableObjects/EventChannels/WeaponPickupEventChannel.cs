using System;
using Prodigy.Weapons;
using UnityEngine;

namespace Prodigy.EventChannels
{
    [CreateAssetMenu(fileName = "newWeaponPickupChannel", menuName = "Event Channels/Weapon Pickup")]
    public class WeaponPickupEventChannel : EventChannelsSO<WeaponPickupEventArgs>
    {
    }

    public class WeaponPickupEventArgs : EventArgs
    {
        public ItemObject NewWeaponData;
        public ItemObject PrimaryWeaponData;
        public ItemObject SecondaryWeaponData;

        public WeaponPickupEventArgs(ItemObject newWeaponData, ItemObject primaryWeaponData, ItemObject secondaryWeaponData)
        {
            NewWeaponData = newWeaponData;
            PrimaryWeaponData = primaryWeaponData;
            SecondaryWeaponData = secondaryWeaponData;
        }
    }
}