using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryState : IState
{
    RetryMenu retryMenu;
    
    public void OnEnterState(StateController stateController)
    {
        retryMenu = GameObject.FindWithTag("Retry Menu").GetComponent<RetryMenu>();
        retryMenu.EnableRetryMenu();
    }
    
    public void UpdateState(StateController stateController)
    {
        if (retryMenu.retryButtonPressed || Input.GetKeyDown(KeyCode.Space))
        {
            retryMenu.DisableRetryMenu();
            
            stateController.LoadMainScene();

            Camera.main.GetComponent<CameraMovement>().enabled = false;

            PlayerStats.ResetStats();
            
            stateController.ChangeState(stateController.startState);
        }
    }

    public void OnExitState(StateController stateController)
    {

    }
}
