using System;
using UnityEngine;

namespace Prodigy.Weapons.Components
{
    [Serializable]
    public class AttackOptionalSprite : AttackData
    {
        [field: SerializeField] public bool UseOptionalSprite { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}