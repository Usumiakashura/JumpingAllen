using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculate : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text recordText = null;
    private int score;

    private void Start()
    {
        if (PlayerPrefs.GetString("Recodr").Length > 0)
            recordText.text = PlayerPrefs.GetString("Recodr");
        else recordText.text = "Record: 0";
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void CalculateRecord()
    {
        if (System.Convert.ToInt32(recordText.text.ToString().
            Substring(7, recordText.text.Length - 7)) < score)
        {
            PlayerPrefs.SetString("Recodr", $"Recodr: {score}");
            recordText.text = PlayerPrefs.GetString("Recodr");
        }
    }

}
