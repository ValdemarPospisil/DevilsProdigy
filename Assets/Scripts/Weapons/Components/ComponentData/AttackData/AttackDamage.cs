using System;
using UnityEngine;

namespace Prodigy.Weapons.Components
{
    [Serializable]
    public class AttackDamage : AttackData
    {
        [field: SerializeField] public float AmountMin { get; private set; }
        [field: SerializeField] public float AmountMax { get; private set; }
    }
}
