using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //makes mouse disapppear
        Cursor.visible = false;
        //locks the mouse in the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
