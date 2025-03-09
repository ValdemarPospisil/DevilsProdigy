using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private GameObject image;
    private Animator anim;
    [SerializeField] private bool isOnGround = true;

    // Start is called before the first frame update
    void Awake()
    {
        
        anim = GetComponent<Animator>();
        this.gameObject.SetActive(false);
    }

    public void ShowDetails (ItemObject data) {
        this.gameObject.SetActive(true);
        itemName.alpha = 0;
        itemDescription.alpha = 0;
        if(isOnGround)
        { 
            image.SetActive(false);
        }
        itemName.text = data.Name.ToString();
        itemDescription.text = data.description.ToString();
        anim.SetTrigger("Show");   
        
    }

    public void DisplayText () {
        itemName.alpha = 1;
        itemDescription.alpha = 1;
        if(isOnGround)
        { 
            image.SetActive(true);
        }
    }
    public void HideText () {
        itemName.alpha = 0;
        itemDescription.alpha = 0;
        if(isOnGround)
        { 
            image.SetActive(false);
        }
        
    }

     public void HideDetails () { 
        anim.SetTrigger("Hide");
    }


    public void ActiveFalse () {
        this.gameObject.SetActive(false);
    }
}

