using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public List<PineappleAI> pineapples = new List<PineappleAI>();
    public int totalDead = 0;
    public int totalEscaped = 0;
    int startingPineapples;
    bool panicMode = false;
    Timer timer;
    [SerializeField] GameObject blocker;
    [SerializeField] GameObject trigger;

    private void Start()
    {
        pineapples.AddRange(GetComponentsInChildren<PineappleAI>());
        timer = FindObjectOfType<Timer>();
        startingPineapples = pineapples.Count;
        blocker.SetActive(true);
        trigger.SetActive(false);
    }
    public void Escaped()
    {
        totalEscaped++;
    }
    public void PanicMode()
    {
        panicMode = true;
        blocker.SetActive(false);
        trigger.SetActive(true);
    }
}
