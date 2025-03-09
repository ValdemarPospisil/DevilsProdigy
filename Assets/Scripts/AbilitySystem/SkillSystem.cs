using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prodigy
{
    public class SkillSystem : MonoBehaviour
    {

        private Skill skill;
        [SerializeField] private GameObject[] skillsLeft;
        [SerializeField] private GameObject skillsMiddle;
        [SerializeField] private GameObject[] skillsRight;
        private Vector3 pos;
        private Vector3 pos1;
        private Vector3 pos2;
        public static SkillSystem instance;

         [SerializeField]
        private PlayerData playerData;
        private int rand;
        private int rand1;


        private void Awake() {
            if(instance == null)
                instance = this;
                else
                Destroy(gameObject);
        }


        public void LevelUp()
        {
            Time.timeScale = 0;
            UIManager.IsPause = true;
            StartCoroutine(DisableButtons());

            
        }

        private IEnumerator DisableButtons()
        {
            rand = Random.Range(0, skillsLeft.Length);
            rand1 = Random.Range(0, skillsRight.Length);

            pos = new Vector3(0, 0, 0);
            pos1 = new Vector3(500, 0, 0);
            pos2 = new Vector3(-500, 0, 0);
            GameObject newSkills = Instantiate(skillsLeft[rand], pos2, transform.rotation) as GameObject;
            GameObject newSkills1 = Instantiate(skillsMiddle, pos, transform.rotation) as GameObject;
            GameObject newSkills2 = Instantiate(skillsRight[rand1], pos1, transform.rotation) as GameObject;
            newSkills.transform.SetParent(this.gameObject.transform, false);
            newSkills1.transform.SetParent(this.gameObject.transform, false);
            newSkills2.transform.SetParent(this.gameObject.transform, false);
            newSkills.GetComponentInChildren<Button>().interactable = false;
            newSkills1.GetComponentInChildren<Button>().interactable = false;
            newSkills2.GetComponentInChildren<Button>().interactable = false;
            yield return new WaitForSecondsRealtime(0.4f);
            newSkills.GetComponentInChildren<Button>().interactable = true;
            newSkills1.GetComponentInChildren<Button>().interactable = true;
            newSkills2.GetComponentInChildren<Button>().interactable = true;
            newSkills1.GetComponentInChildren<Button>().Select();
        }
  

        public void OnSkillPicked(SkillObject data)
        {
            

            foreach(var skill in GetComponentsInChildren<Skill>()) {
             skill.DestroyThis();
         }
            Time.timeScale = 1;            
            UIManager.IsPause = false;
        }

    }
}
