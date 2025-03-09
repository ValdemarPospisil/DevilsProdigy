using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Prodigy
{
    public class Skill : MonoBehaviour
    {

        [SerializeField] private SkillObject[] data;
        private int rand;

        [SerializeField]private Image graphics;
        [SerializeField]private TextMeshProUGUI nameofSkill;
        [SerializeField]private TextMeshProUGUI desriptionOfSkill;
        private GameObject player;
        private Image image;

        private void Awake() {
            rand = Random.Range(0, data.Length);

    //        graphics = GetComponentInChildren<SpriteRenderer>();
             graphics.sprite = data[rand].uiDisplay;
            nameofSkill.text = data[rand].nameOfSkill;
            desriptionOfSkill.text = data[rand].description;
            image = GetComponent<Image>();
            


            if (data[rand].type == SkillType.Common)
            {
                nameofSkill.color = new Color32(255,255,255,220);
            }
            else if(data[rand].type == SkillType.Uncommon)
            {
                nameofSkill.color = new Color32(30,255,0,220);
            }
            else if(data[rand].type == SkillType.Rare)
            {
                nameofSkill.color = new Color32(0,112,221,220);
            }
            else if(data[rand].type == SkillType.Epic)
            {
                nameofSkill.color = new Color32(163,53,238,220);
            }
            else if(data[rand].type == SkillType.Legendary)
            {
                nameofSkill.color = new Color32(255,128,0,220);
            }

           
           
        }

        private void Init()
        {
            
        }


        public void SetContext(object obj)
    {
        switch (obj)
        {
            case null:
                gameObject.SetActive(false);
                break;
            case SkillObject so:
                data[rand] = so;
                Init();
                break;
        }
    }

        public void SkillPicked () {
            SkillSystem.instance.OnSkillPicked(data[rand]);
            data[rand].Apply();
        }

        public void DestroyThis () {
            Destroy(this.gameObject);
        }




    }
}
