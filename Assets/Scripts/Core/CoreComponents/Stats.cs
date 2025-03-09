using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prodigy.CoreSystem.StatsSystem;

namespace Prodigy.CoreSystem
{
    public class Stats : CoreComponent
    {
       [field: SerializeField] public Stat Health { get; private set; }
       [field: SerializeField] public Stat Poise { get; private set; }
       [SerializeField] private float poiseRecoveryRate;
       [SerializeField] private PlayerData data;

       


         [SerializeField] private bool isPlayer;
        

       

        protected override void Awake()
        {
            base.Awake();   
            if(!isPlayer)
            {
                 Poise.Init();
                Health.Init();
            }
        }
        

        private void Update()
        {
            if (Poise.CurrentValue.Equals(Poise.MaxValue))
                return;
            
            Poise.Increase(poiseRecoveryRate * Time.deltaTime);            
        }
    }
}