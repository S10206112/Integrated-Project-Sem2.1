using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOT USING THIS SCRIPT
public class ChangeMovement : MonoBehaviour
{
    public Flyingcontrol Flyingcontrol;
    public Walkingcontrol Walkingcontrol;
    // Use this for initialization
    void Start()
    {
        Flyingcontrol = GetComponent<Flyingcontrol>();
        Walkingcontrol = GetComponent<Walkingcontrol>();
    }

    void Update()
    {
        if (Input.GetButtonDown("F"))
        {
            Flyingcontrol.enabled = true;
            Walkingcontrol.enabled = false;
            Debug.Log("Flying Mode");
        }
        else
        {
            if (Input.GetButtonDown("G"))
            {
                Flyingcontrol.enabled = false;
                Walkingcontrol.enabled = true;
                Debug.Log("Walking Mode");
            }
        }
    }
}