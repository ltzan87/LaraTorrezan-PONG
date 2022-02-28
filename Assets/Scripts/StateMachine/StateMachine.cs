using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }


    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currenteState;
    public float timeToStartGame = 1f;

    public static StateMachine Instance;


    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States state)
    {
        if (_currenteState != null) _currenteState.OnStateExit();

        _currenteState = dictionaryState[state];

        if (_currenteState != null) _currenteState.OnStateEnter();
    }


    private void Update()
    {
        if (_currenteState != null) _currenteState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState(States.PLAYING);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchState(States.RESET_POSITION);
        }
    }


    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
