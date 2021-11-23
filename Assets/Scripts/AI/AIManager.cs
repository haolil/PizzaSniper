using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public List<PineappleAI> pineapples = new List<PineappleAI>();
    public int totalDead = 0;
    public int totalEscaped = 0;
    [SerializeField] GameObject blocker;
    [SerializeField] GameObject trigger;

    private void Start()
    {
        pineapples.AddRange(GetComponentsInChildren<PineappleAI>());
        blocker.SetActive(true);
        trigger.SetActive(false);
    }
    public void Escaped()
    {
        totalEscaped++;
    }
    public void PanicMode()
    {
        blocker.SetActive(false);
        trigger.SetActive(true);
    }
}
