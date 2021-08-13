using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public Animator QuestLog;
    public Animator Options;
    // Start is called before the first frame update
    void Start()
    {
        QuestLog.SetBool("SeeQuest", false);
        Options.SetBool("OptionsShow", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            SeeQuest();
        }

        if (Input.GetKeyDown("e"))
        {
            CloseQuest();
        }

        if (Input.GetKeyDown("o"))
        {
            SeeOptions();
        }

        if (Input.GetKeyDown("p"))
        {
            CloseOptions();
        }
    }

    public void SeeQuest()
    {
        QuestLog.SetBool("SeeQuest", true);
    }
    public void CloseQuest()
    {
        QuestLog.SetBool("SeeQuest", false);
    }
    public void SeeOptions()
    {
        Options.SetBool("OptionsShow", true);
    }
    public void CloseOptions()
    {
        Options.SetBool("OptionsShow", false);
    }
}
