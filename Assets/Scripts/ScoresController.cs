using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoresText;
    [SerializeField] private int scores;

    public void SetScores(int addPoint)
    {
        scores+=addPoint;
        scoresText.text=scores.ToString();
    }
    public int GetScores() { return scores; }

}
