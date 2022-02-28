using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    private string keyToSave = "keyHighScore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighScore.text = PlayerPrefs.GetString(keyToSave, "No Highscore");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}
