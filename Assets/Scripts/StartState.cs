using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : IState
{
    public ExitButton exitButton;

    public void OnEnterState(StateController stateController)
    {
        exitButton = GameObject.FindWithTag("Exit Button").GetComponent<ExitButton>();
        exitButton.EnableExitButton();
    }

    public void UpdateState(StateController stateController)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitButton.ExitGame();
        }
        
        //Only allow player to start the game if there aren't any falling objects and the player didn't exit the game
        if ((Input.GetKeyDown(KeyCode.Space) || 
             Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.DownArrow) || 
             Input.GetKeyDown(KeyCode.LeftArrow) || 
             Input.GetKeyDown(KeyCode.RightArrow)) && 
             !GameObject.FindWithTag("Level Generator").GetComponent<LevelGenerator>().fallingObjects && 
             !exitButton.exitButtonPressed)
        {
            //Enable camera movement and change to play state
            Camera.main.GetComponent<CameraMovement>().enabled = true;
            stateController.ChangeState(stateController.playState);
        }
    }

    public void OnExitState(StateController stateController)
    {
        exitButton.DisableExitButton();
    }
}
