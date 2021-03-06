using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracking : MonoBehaviour
{
    public float hit = 0;
    public float miss = 0;
    public float total;
    public float accuracy = 100;
    public Text accuracyValue, killValue, timeValue, rankValue;
    public PineappleAI[] pineapplesInScene = new PineappleAI[0];
    public float pineappleTotalAtStart = 0;
    public float pineapplesTotalAtEnd = 0;
    public float totalKills;
    public float rankPercentage;
    Timer timer;
    bool canKey, rankCalulated;
    AIManager aiManager;
    Snipe snipe;
    public GameObject snipeObject, maskObject;

    void Start()
    {
        aiManager = FindObjectOfType<AIManager>();
        pineapplesInScene = FindObjectsOfType<PineappleAI>();
        pineappleTotalAtStart = pineapplesInScene.Length;
        pineapplesTotalAtEnd = pineappleTotalAtStart;
        timer = FindObjectOfType<Timer>();
        snipe = FindObjectOfType<Snipe>();
        rankCalulated = false;
    }

    void Update()
    {
        hit = snipe.hitCount;
        miss = snipe.missCount;

        if (aiManager.totalDead + aiManager.totalEscaped >= pineappleTotalAtStart)
        {
            timer.ShowResults();
            timer.timerFinished = true;
        }
    }

    public void FinalResults()
    {
        CalculateAccuracy();
        CalculateKills();
        accuracyValue.text = accuracy.ToString() + "%";
        CalculateRank();
        CalculateTime();
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
        killValue.text = hit.ToString() + "/" + pineappleTotalAtStart.ToString();
    }

    public void CalculateTime()
    {
        timeValue.text = timer.currentTime.ToString("f2");
    }

    public void CalculateRank()
    {
        if (!rankCalulated)
        {
            snipeObject.SetActive(false);
            maskObject.SetActive(false);
            pineapplesTotalAtEnd = pineapplesTotalAtEnd - hit;
            totalKills = pineappleTotalAtStart - pineapplesTotalAtEnd;
            rankPercentage = (totalKills / pineappleTotalAtStart) * 100;
            rankPercentage = Mathf.Clamp(rankPercentage, 0, 100);
            rankPercentage = Mathf.Round(rankPercentage);
            float finalTotal = (rankPercentage + accuracy) * 0.5f;
            finalTotal = Mathf.Clamp(finalTotal, 0, 100);
            finalTotal = Mathf.Round(finalTotal);
            rankCalulated = true;

            switch (finalTotal)
            {
                case float n when n >= 100:
                    rankValue.text = "SSS";
                    break;
                case float n when n >= 90:
                    rankValue.text = "S";
                    break;
                case float n when n >= 70:
                    rankValue.text = "A";
                    break;
                case float n when n >= 50:
                    rankValue.text = "B";
                    break;
                case float n when n >= 20:
                    rankValue.text = "C";
                    break;
                case float n when n >= 0:
                    rankValue.text = "D";
                    break;
            }
        }
    }
}