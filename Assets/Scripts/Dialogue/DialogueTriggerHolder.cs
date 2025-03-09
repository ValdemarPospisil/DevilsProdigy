using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

    public enum NPC
    {
        MagicVendor,
        BlackSmith,
        Mage,
        Gravedigger,
        Girl
    }
    public class DialogueTriggerHolder : MonoBehaviour, IDataPersistence
    {
        private List<int> magicVendorList = new List<int>();
        private List<int> blackSmithList = new List<int>();
        private List<int> mageList = new List<int>();
        private List<int> graveDiggerList = new List<int>();
        private List<int> girlList = new List<int>();

        
        
        public NPC npc;
        [Header("Visual Cue")]
        [SerializeField] private GameObject visualCue;
        [Header("Important Cue")]
        [SerializeField] private GameObject importantCue;

        [Header("Emote Animator")]
        [SerializeField] private Animator emoteAnimator;

        [Header("Ink JSON")]
        [SerializeField] private TextAsset[] inkJSON;
        
        [Header("Upgrade list")]
        [SerializeField] private GameObject upgradeList;
        [SerializeField] private Button button;
        private int currentDialogueID;
        private int deathCount;
        private bool playerInRange;
        private bool hasDialogue = false;

        private void Awake() 
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }

      
        private void Start() {
            hasDialogue = false;
            switch (npc)
            {
            case NPC.MagicVendor:
                if(magicVendorList.Count != 0)
                {
                    hasDialogue = true;
                }
                
            break;
            case NPC.BlackSmith:
                if(blackSmithList.Count != 0)
                {
                    hasDialogue = true;
                }
            break;
            case NPC.Mage:
                if(mageList.Count != 0)
                {
                    hasDialogue = true;
                }
                if(deathCount == 0)
                {
                    hasDialogue = true;
                }
            break;
            case NPC.Gravedigger:
                if(graveDiggerList.Count != 0)
                {
                    hasDialogue = true;
                }
            break;
            case NPC.Girl:
            if(girlList.Count != 0)
                {
                    hasDialogue = true;
                }
                if(deathCount == 0)
                {
                    hasDialogue = true;
                }
            break;
            }

            if(hasDialogue == true)
            {
                visualCue.SetActive(false);
                importantCue.SetActive(true);
            }
            else
            {
                visualCue.SetActive(false);
                importantCue.SetActive(false);
            }
            
            
        }

        private void Update() 
        {
        
        
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
            {   
                if (PlayerInputHandler.GetInstance().GetInteractPressed()) 
                {
                    StartDialogue();
                    visualCue.SetActive(false);
                }

                if (PlayerInputHandler.GetInstance().GetPauseMenuPressed() && (npc == NPC.MagicVendor || npc == NPC.BlackSmith))
                {
                    
                    UIManager.IsPause = false;
                    upgradeList.SetActive(false);
                }
        }
        
    }

    public void StartDialogue () 
    {
        switch (npc)
        {
            case NPC.MagicVendor:
                if(magicVendorList.Count != 0)
                {
                    Queue<int> magicVendorQ = new Queue<int>(magicVendorList);
                    currentDialogueID = magicVendorQ.First();
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[currentDialogueID], emoteAnimator);
                    magicVendorList.Remove(magicVendorQ.Dequeue());
                    
                    if(magicVendorList.Count != 0)
                    {
                        hasDialogue = true;
                    } else {
                        hasDialogue = false;
                    }

                }
                else
                {
                    if(deathCount >= 1)
                    {
                        UIManager.IsPause = true;
                        upgradeList.SetActive(true);
                        button.Select();
                        visualCue.SetActive(false);
                        PlayerInputHandler.GetInstance().StopMovement();
                    }
                    Debug.Log("Magic Vendor Out of dialogue");

                }
            break;
            case NPC.BlackSmith:
                if(blackSmithList.Count != 0)
                {
                    Queue<int> blackSmithQ = new Queue<int>(blackSmithList);
                    currentDialogueID = blackSmithQ.First();
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[currentDialogueID], emoteAnimator);
                    blackSmithList.Remove(blackSmithQ.Dequeue());

                    if(blackSmithList.Count != 0)
                    {
                        hasDialogue = true;
                    } else {
                        hasDialogue = false;
                    }
                }
                else
                {
                    Debug.Log("BlackSmith Out of dialogue");
                    if(deathCount >= 3)
                    {
                        UIManager.IsPause = true;
                        upgradeList.SetActive(true);
                        button.Select();
                        visualCue.SetActive(false);
                        PlayerInputHandler.GetInstance().StopMovement();
                    }
                }
            break;
            case NPC.Mage:
                if(mageList.Count != 0)
                {
                    Queue<int> mageQ = new Queue<int>(mageList);
                    currentDialogueID = mageQ.First();
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[currentDialogueID], emoteAnimator);
                    mageList.Remove(mageQ.Dequeue());

                    if(mageList.Count != 0)
                    {
                        hasDialogue = true;
                    } else {
                        hasDialogue = false;
                    }
                }
                else
                {
                    if (deathCount == 0)
                    {
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON[0], emoteAnimator);
                        hasDialogue = false;
                    } 
                    Debug.Log("Mage Out of dialogue");
                }
            break;
            case NPC.Gravedigger:
                if(graveDiggerList.Count != 0)
                {
                    Queue<int> graveDiggerQ = new Queue<int>(graveDiggerList);
                    currentDialogueID = graveDiggerQ.First();
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[currentDialogueID], emoteAnimator);
                    graveDiggerList.Remove(graveDiggerQ.Dequeue());

                    if(graveDiggerList.Count != 0)
                    {
                        hasDialogue = true;
                    } else {
                        hasDialogue = false;
                    }
                }
                else
                {
                    Debug.Log("Gravedigger Out of dialogue");
                }
            break;
            case NPC.Girl:
                if(girlList.Count != 0)
                {
                    Queue<int> girlQ = new Queue<int>(girlList);
                    currentDialogueID = girlQ.First();
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[currentDialogueID], emoteAnimator);
                    girlList.Remove(girlQ.Dequeue());

                    if(girlList.Count != 0)
                    {
                        hasDialogue = true;
                    } else {
                        hasDialogue = false;
                    }
                }
                else
                {
                    if (deathCount == 0)
                    {
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON[0], emoteAnimator);
                        hasDialogue = false;
                    } 
                    Debug.Log("Girl Out of dialogue");
                }
            break;

        }   
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            if(hasDialogue)
            {
                importantCue.SetActive(false);
                visualCue.SetActive(true);
            }
            else if (npc == NPC.MagicVendor || npc == NPC.BlackSmith)
            {
                switch (npc)
                {
                    case NPC.MagicVendor:
                        if (deathCount >= 1)
                        {
                             visualCue.SetActive(true);
                            importantCue.SetActive(false);
                        }
                    break;
                    case NPC.BlackSmith:
                        if (deathCount >= 3)
                        {
                             visualCue.SetActive(true);
                            importantCue.SetActive(false);
                        }
                    break;
                }
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            if(hasDialogue)
            {
                visualCue.SetActive(false);
                importantCue.SetActive(true);
            }
            else
            {
                importantCue.SetActive(false);
            }
        }
    }



    public void SaveData (GameData data) {
        
        data.magicVendorList = this.magicVendorList;
        data.blackSmithList = this.blackSmithList;
        data.mageList = this.mageList;
        data.graveDiggerList = this.graveDiggerList;
        data.girlList = this.girlList;
    }

    public void LoadData (GameData data) {


        this.magicVendorList = data.magicVendorList;
        this.blackSmithList = data.blackSmithList;
        this.mageList = data.mageList;
        this.graveDiggerList = data.graveDiggerList;
        this.girlList = data.girlList;
        this.deathCount = data.deathCount;
    }
    }
