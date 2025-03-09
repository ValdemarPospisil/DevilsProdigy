using System;
using Prodigy.ProjectileSystem.Components;
using UnityEngine;

namespace Prodigy.ProjectileSystem
{
    /*
     * This MonoBehaviour is simply used to print the damage amount received in the ProjectileTestScene
     */
    public class TestDamageable : MonoBehaviour, IDamageable
    {
        public void Damage(float amount)
        {
            print($"{gameObject.name} Damaged: {amount}");
        }
    }
}