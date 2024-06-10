using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CamFollowDray : MonoBehaviour
{
    static public bool TRANSITIONING=false;
    [Header("Set in Inspector")]
    public InRoomDray datryInRm;
    public float transTime=0.5f;
    public GameObject soundeffect;

    private Vector3 p0,p1;

private InRoom inRm;
private float transStart;
void Awake(){
    inRm=GetComponent<InRoom>();
}

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex>2){
            transform.position=new Vector3(transform.position.x+1.5f,transform.position.y,-10);

        }
    }

    // Update is called once per frame
    void Update()
    {
     if(TRANSITIONING){
        float u=(Time.time-transStart)/transTime;
        if(u>=1){
            u=1;
            TRANSITIONING=false;
        }
     transform.position=(1-u)*p0+u*p1;   
     }else {
        if(datryInRm.roomNum!=inRm.roomNum){
            TransitionTo(datryInRm.roomNum);
        }

     }   
    }

    void TransitionTo(Vector2 rm){
        p0=transform.position;
        inRm.roomNum=rm;
        p1=transform.position+(Vector3.back*10);
        transform.position=p0;
        transStart=Time.time;
        TRANSITIONING=true;
         if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
        Destroy(Instantiate(soundeffect),0.5f);}


    }
}
