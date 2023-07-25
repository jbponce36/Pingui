using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IState
{
    PlayerController playerController;
    
    public void OnEnterState(StateController stateController)
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    
    public void UpdateState(StateController stateController)
    {
        if (playerController.PlayerIsDead())
        {   
            stateController.ChangeState(stateController.retryState);
        }
    }

    public void OnExitState(StateController stateController)
    {

    }
}
