using System;
using Prodigy.CoreSystem;
using UnityEngine;
using Prodigy.Utilities;

namespace Prodigy.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public event Action<bool> OnCurrentInputChange;
        public event Action OnEnter;
        public event Action OnExit;
        public event Action OnUseInput;
        public float bonusDamage { get; private set;}

        public Transform longRangeAttackPosition;
        
        [SerializeField] private float attackCounterResetCooldown;

        public ItemObject Data { get; private set; }
        public ElementData elementData;
        
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value; 
        }

        public bool CurrentInput
        {
            get => currentInput;
            set
            {
                if (currentInput != value)
                {
                    currentInput = value;
                    OnCurrentInputChange?.Invoke(currentInput);
                }
            }
        }

         public float AttackStartTime { get; private set; }

        
        private Animator anim;
        public GameObject BaseGameObject { get; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }
        
        public AnimationEventHandler EventHandler { get; private set; }
        
        public Core Core { get; private set; }

        private int currentAttackCounter;

        private TimeNotifier attackCounterResetTimeNotifier;

        private bool currentInput;
        
        public void Enter()
        {            
            

            AttackStartTime = Time.time;
            
            attackCounterResetTimeNotifier.Disable();
            
            anim.SetBool("active", true);
            anim.SetInteger("counter", currentAttackCounter);
            
            OnEnter?.Invoke();
        }

        public void AddWeaponBuffs () {
            bonusDamage = 0;
            switch (Data.mat)
                {
                    
                    case WeaponMaterial.Wooden:
                        bonusDamage += elementData.woodDamage;
                    break;
                    case WeaponMaterial.CelestialBronze:
                        bonusDamage += elementData.holyDamage;
                    break;
                    case WeaponMaterial.Iron:
                        bonusDamage += elementData.earthDamage;
                    break;
                    case WeaponMaterial.Mithril:
                        bonusDamage += elementData.windDamage;
                    break;
                    case WeaponMaterial.Blazestone:
                        bonusDamage += elementData.fireDamage;
                    break;
                    case WeaponMaterial.Aquamarine:
                        bonusDamage += elementData.waterDamage;
                    break;
                    case WeaponMaterial.Serpentine:
                        bonusDamage += elementData.acidDamage;
                    break;
                    case WeaponMaterial.NimbusSteel:
                        bonusDamage += (elementData.windDamage + elementData.thunderDamage);
                    break;
                    case WeaponMaterial.BlackIce:
                        bonusDamage += (elementData.iceDamage + elementData.darkDamage);
                    break;
                    case WeaponMaterial.Gold:
                        bonusDamage += (elementData.fireDamage + elementData.holyDamage);
                    break;
                    case WeaponMaterial.Chrysoberyl:
                        bonusDamage += (elementData.holyDamage + elementData.earthDamage + elementData.woodDamage);
                    break;
                    case WeaponMaterial.Moonstone:
                        bonusDamage += (elementData.windDamage + elementData.iceDamage + elementData.waterDamage);
                    break;
                    case WeaponMaterial.Onyx:
                        bonusDamage += (elementData.darkDamage + elementData.fireDamage + elementData.thunderDamage + elementData.earthDamage);
                    break;
                }

               switch (Data.type)
               {
                    case ItemType.Swords:
                        bonusDamage += elementData.swordDamage;
                    break;
                    case ItemType.Polearms:
                        bonusDamage += elementData.polearmDamage;
                    break;
                    case ItemType.HeavyWeaponry:
                        bonusDamage += elementData.heavyDamage;
                    break;
               }
        }

        public void SetCore(Core core)
        {
            Core = core;
        }

        public void SetData(ItemObject data)
        {
            Data = data;
        }

        private void Exit()
        {
            anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimeNotifier.Init(attackCounterResetCooldown);
            
            OnExit?.Invoke();
        }

        private void Awake()
        {
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
            
            anim = BaseGameObject.GetComponent<Animator>();

            EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimeNotifier = new TimeNotifier();

            
        }

        private void Update()
        {
            attackCounterResetTimeNotifier.Tick();
        }

        private void ResetAttackCounter()
        {
            CurrentAttackCounter = 0;
        }

        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
            EventHandler.OnUseInput += HandleUseInput;
            attackCounterResetTimeNotifier.OnNotify += ResetAttackCounter;
            
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;
            EventHandler.OnUseInput -= HandleUseInput;
            attackCounterResetTimeNotifier.OnNotify -= ResetAttackCounter;
        }

         /// <summary>
        /// Invokes event to pass along information from the AnimationEventHandler to a non-weapon class.
        /// </summary>
        private void HandleUseInput() => OnUseInput?.Invoke();
    }


    
}