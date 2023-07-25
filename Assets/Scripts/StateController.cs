using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public StartState startState = new StartState();
    public PlayState playState = new PlayState();
    public RetryState retryState = new RetryState();

    public IState currentState;
    
    void Start()
    {
        currentState = startState;
        currentState.OnEnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState) 
    {
        currentState.OnExitState(this);
        currentState = newState;
        newState.OnEnterState(this);
    }

    public void LoadMainScene()
    {
        StartCoroutine(LoadAsyncScene("MainScene"));
    }
    
    IEnumerator LoadAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
