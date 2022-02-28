using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1);
    private Vector3 startspeed;

    public string keyToCheck = "Player";

    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector3 _startPosition;
    private bool _canMove = false;


    private void Awake()
    {
        _startPosition = transform.position;
        startspeed = speed;
    }

    void Update()
    {
        if (!_canMove) return;

        transform.Translate(speed * Time.deltaTime * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            OnPlayerColission();
        else
            speed.y *= -1;
    }

    private void OnPlayerColission()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;


        rand = Random.Range(randSpeedY.x, randSpeedY.y);

        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startspeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
