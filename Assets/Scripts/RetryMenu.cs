using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryMenu : MonoBehaviour
{
    public Animator darkPanelAnim;
    public Animator retryButtonAnim;
    public GameObject retryMenuUI;

    public bool retryButtonPressed = false;

    public void RetryButtonPressed ()
    {
        retryButtonPressed = true;
    }

    public void EnableRetryMenu()
    {
        retryMenuUI.SetActive(true);
        darkPanelAnim.SetBool("Active", true);
        retryButtonAnim.SetBool("Active", true);
    }
    
    public void DisableRetryMenu()
    {
        darkPanelAnim.SetBool("Active", false);
        retryButtonAnim.SetBool("Active", false);
    }
}
