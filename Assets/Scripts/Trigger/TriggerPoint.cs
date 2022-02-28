using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public string tagToCheck = "Ball";

    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == tagToCheck)
        {
            UnityEngine.Debug.Log("Bati na bola");

            CountPoint();
        }
    }
   
    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}