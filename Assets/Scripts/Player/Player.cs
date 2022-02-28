using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10;

    public int maxPoints = 3;

    [Header("Key Setup")]
    public KeyCode keycodeUp = KeyCode.W;
    public KeyCode keycodeDown = KeyCode.S;

    public Rigidbody2D rb2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    public Image uiPlayer;

    public string playerName;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    private void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }


    void Update()
    {
        if (Input.GetKey(keycodeUp))
            rb2D.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
        else if (Input.GetKey(keycodeDown))
            rb2D.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
    }


    public void AddPoint()
    {
        currentPoints++;

        UpdateUI();
        CheackMaxPoints();

        Debug.Log(currentPoints);
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void CheackMaxPoints()
    {
        if (currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
        }
    }

}
