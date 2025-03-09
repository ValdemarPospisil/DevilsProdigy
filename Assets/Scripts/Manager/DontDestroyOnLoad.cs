using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prodigy
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
         public static DontDestroyOnLoad instance { get; private set; }
        private void Awake() {
            if (instance != null) 
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
            DontDestroyOnLoad(this.gameObject);


        
    }
}
}