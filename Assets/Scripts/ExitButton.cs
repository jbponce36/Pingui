using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public Animator exitButtonAnim;

    public bool exitButtonPressed = false;

    public void EnableExitButton()
    {
        exitButtonAnim.SetBool("Active", true);
    }
    
    public void DisableExitButton()
    {
        exitButtonAnim.SetBool("Active", false);
    }

    public void ExitGame()
    {
        Debug.Log("EXIT");
        exitButtonPressed = true;
        Application.Quit();
    }
}
