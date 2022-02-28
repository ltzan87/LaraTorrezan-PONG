using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public StateMachine stateMachine;

    [Header("Menus")]
    public GameObject UIMainMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        UIMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}