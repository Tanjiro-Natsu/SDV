using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class BacktoStart : MonoBehaviour
{

    
        
    void Update(){
        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene(0);
        }
    }
    
}