using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Prodigy
{
    public class XpManager : MonoBehaviour
    {
        public TextMeshProUGUI currentXPText, targetXPText, levelText;
        [SerializeField]
        private int currentXP, targetXP, level;
        public static XpManager instance;
        [SerializeField]private SkillSystem skillSystem;

        public Slider slider;
        public Image fill;

        private void Awake() {
            if(instance == null)
                instance =this;
                else
                Destroy(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            currentXPText.text = currentXP.ToString();
            targetXPText.text = targetXP.ToString();
            levelText.text = level.ToString();
            slider.maxValue = targetXP;
		    slider.value = currentXP;

        }


        public void AddXP(int xp)
        {
            currentXP += xp;
            SoundManager.instance.Play("Xp");
            slider.value = currentXP;
        
            //Level Up
            while(currentXP >= targetXP)
            {
                skillSystem.LevelUp();
                SoundManager.instance.Play("LevelUp");
                currentXP = currentXP - targetXP;
                slider.value = currentXP;
                level++;
                targetXP += targetXP / 10;

                levelText.text = level.ToString();
                targetXPText.text = targetXP.ToString();
                slider.maxValue = targetXP;
		        slider.value = currentXP;
            }
            
            
            currentXPText.text = currentXP.ToString();
        }
    }
}
