using System;
using Prodigy.Weapons;
using UnityEngine;

namespace Prodigy.EventChannels
{
    [CreateAssetMenu(fileName = "newWeaponChangedChannel", menuName = "Event Channels/Weapon Changes")]
    public class WeaponChangedEventChannel : EventChannelsSO<WeaponChangedEventArgs>{ }

    public class WeaponChangedEventArgs : EventArgs
    {
        public ItemObject WeaponData;
        public CombatInputs WeaponInput;

        public WeaponChangedEventArgs(ItemObject weaponData, CombatInputs weaponInput)
        {
            WeaponData = weaponData;
            WeaponInput = weaponInput;
        }
    }
}