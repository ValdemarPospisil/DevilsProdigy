using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prodigy.CoreSystem.StatsSystem
{
    [Serializable]
    public class Stat
    {
        public event Action OnCurrentValueZero;
        
        [field: SerializeField] public float MaxValue { private set; get;}

        public float CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = Mathf.Clamp(value, 0f, MaxValue);

                if (currentValue <= 0f)
                {
                    OnCurrentValueZero?.Invoke();
                }
            }
        }
       
        
        private float currentValue;

        public void Init() => CurrentValue = MaxValue;
        public void InitPlayer () {
            CurrentValue = CurrentValue;
        }
        public void IncreaseMaxValue (float amount) {

            MaxValue += amount;
            
        }
        public void DecreaseMaxValue (float amount) {
            MaxValue -= amount;
        }

        public void Increase(float amount) 
        {
            
            CurrentValue += amount;
           

        }

        public void Decrease(float amount)
        {   
           
            CurrentValue -= amount;
        }

        
    }
}