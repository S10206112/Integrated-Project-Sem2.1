using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NOT USING THIS SCRIPT
public class Congratulations : MonoBehaviour
{
    public GameObject PenguinBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find ("PenguinBoss") == null) 
        {
             Debug.Log ("Congratulations");
             
        } 
        
    }
}
