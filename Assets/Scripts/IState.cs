using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnterState(StateController stateController);
    void UpdateState(StateController stateController);
    void OnExitState(StateController stateController);
}