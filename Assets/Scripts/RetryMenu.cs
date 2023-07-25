using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryMenu : MonoBehaviour
{
    public Animator darkPanelAnim;
    public Animator retryButtonAnim;

    public bool retryButtonPressed = false;

    public void RetryButtonPressed ()
    {
        retryButtonPressed = true;
    }

    public void EnableRetryMenu()
    {
        darkPanelAnim.SetBool("Active", true);
        retryButtonAnim.SetBool("Active", true);
    }
    
    public void DisableRetryMenu()
    {
        darkPanelAnim.SetBool("Active", false);
        retryButtonAnim.SetBool("Active", false);
    }

}
