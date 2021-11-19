using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracking : MonoBehaviour
{
    public float hit = 0;
    public float miss = 0;
    public float total;
    public float accuracy = 100;
    public Text accuracyValue, killValue, timeValue, rankValue;
    GameObject[] pineapplesTotalAtStart = new GameObject[0];
    GameObject[] pineapplesTotalAtEnd = new GameObject[0];

    void Start()
    {
        //pineapplesTotalAtStart = //get total enemies based on AI set up array
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hit++;
            //kill
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            miss++;
            //miss
        }

        //final
        if (Input.GetKeyDown(KeyCode.X))
        {
            CalculateAccuracy();
            CalculateKills();
            accuracyValue.text = accuracy.ToString() + "%";
        }
    }

    public float CalculateAccuracy()
    {
        total = hit + miss;
        accuracy = (hit / total) * 100;
        accuracy = Mathf.Clamp(accuracy, 0, 100);
        accuracy = Mathf.Round(accuracy);
        return accuracy;
    }

    public void CalculateKills()
    {
        //pineapplesTotalAtEnd = //get total enemies based on AI set up array at the end of timer
        killValue.text = pineapplesTotalAtEnd.Length.ToString() + "/" + pineapplesTotalAtStart.Length.ToString();
    }

    public void CalculateTime()
    {
        //timeValue.text = //timeremaining.ToSring();
    }

    public void CalculateRank()
    {
        int unknownValue = 1;
        switch (unknownValue)
        {
            case 0: rankValue.text = "D";
                break;
        }
    }
}