using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum eType{key,health,power_up_dragon,weapon,power_up_night}
    public static float COLLIDER_DELAY=0.5f;

    [Header("Set in Inspector")]
    public eType  itemType;

    void Awake(){
        GetComponent<Collider>().enabled=false;
        Invoke("Activate",COLLIDER_DELAY);
    }

    void Activate(){
        GetComponent<Collider>().enabled=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
