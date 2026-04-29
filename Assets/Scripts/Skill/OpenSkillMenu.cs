using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkillMenu : MonoBehaviour
{
    public CanvasGroup skillGroup;
    private bool skillMenuOpen = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("OpenSkillMenu"))
        {
            if(skillMenuOpen)
            {
                Time.timeScale = 1;
                skillGroup.alpha = 0;
                skillGroup.blocksRaycasts = false;
                skillMenuOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                skillGroup.alpha = 1;
                skillGroup.blocksRaycasts = true;
                skillMenuOpen = true;
            }
        }
    }
}
