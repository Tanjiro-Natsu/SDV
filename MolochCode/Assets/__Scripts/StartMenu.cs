using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class StartMenu : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   TMP_Text text;
   [Header("Set in Inspector ")]
   public GameObject soundeffect;
   public GameObject confirm;
   public static int effect;

private GameObject OptionMenu;

    void Awake(){
text=GetComponent<TMP_Text>();

if(gameObject.name=="Options"){OptionMenu=GameObject.Find("OptionsMenu");
OptionMenu.SetActive(false);}

    }

    public void OnPointerEnter(PointerEventData eventData){
        text.color=Color.red;
    if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
        Destroy(Instantiate(soundeffect),1);}
    }
    public void OnPointerExit(PointerEventData eventData){
       text.color=Color.white;
    }

    public void PlayGame(){
        if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
        Destroy(Instantiate(confirm),1);}
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
      public void QuitGame(){
       if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
        Destroy(Instantiate(confirm),1);}
Application.Quit();
    }
    public void Options(){
       if(gameObject.name=="Options"){
      OptionMenu.SetActive(true);
       }
    }
    
}