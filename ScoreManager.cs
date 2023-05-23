using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int points;

    public void AddScore(int newPoint)
    {
        points += newPoint;
    }

    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }
}
