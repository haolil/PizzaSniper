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
    GameObject[] pineapplesInScene = new GameObject[0];
    public float pineappleTotalAtStart = 0;
    public float pineapplesTotalAtEnd = 0;
    public float totalKills;
    public float rankPercentage;

    void Start()
    {
        pineappleTotalAtStart = pineapplesInScene.Length;
        pineapplesTotalAtEnd = pineappleTotalAtStart;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hit++;
            pineapplesTotalAtEnd--;
            Debug.Log("kill");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            miss++;
            Debug.Log("miss");
        }

        //final
        if (Input.GetKeyDown(KeyCode.X))
        {
            CalculateAccuracy();
            CalculateKills();
            accuracyValue.text = accuracy.ToString() + "%";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CalculateRank();
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
        killValue.text = pineapplesTotalAtEnd.ToString() + "/" + pineappleTotalAtStart.ToString();
    }

    public void CalculateTime()
    {
        //timeValue.text = //timeremaining.ToSring();
    }

    public void CalculateRank()
    {
        totalKills = pineappleTotalAtStart - pineapplesTotalAtEnd;
        rankPercentage = (totalKills/ pineappleTotalAtStart) * 100;
        rankPercentage = Mathf.Clamp(rankPercentage, 0, 100);
        rankPercentage = Mathf.Round(rankPercentage);
        Debug.Log(rankPercentage);
        Debug.Log(accuracy);
        float finalTotal = (rankPercentage + accuracy) * 0.5f;

        Debug.Log("Grade Percentage = " + finalTotal); 
        finalTotal = Mathf.Clamp(finalTotal, 0, 100);
        finalTotal = Mathf.Round(finalTotal);

        

        switch (finalTotal)
        {
            case float n when n >= 100:
                Debug.Log("SSS");
                rankValue.text = "SSS";
                break;
            case float n when n >= 90:
                Debug.Log("S");
                rankValue.text = "S";
                break;
            case float n when n >= 70:
                Debug.Log("A");
                rankValue.text = "A";
                break;
            case float n when n >= 50:
                Debug.Log("B");
                rankValue.text = "B";
                break;
            case float n when n >= 20:
                Debug.Log("C");
                rankValue.text = "C";
                break;
            case float n when n >= 0:
                Debug.Log("D");
                rankValue.text = "D";
                break;
        }
    }
}