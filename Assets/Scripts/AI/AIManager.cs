using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public List<PineappleAI> pineapples = new List<PineappleAI>();
    public int TotalDead = 0;

    private void Start()
    {
        pineapples.AddRange(GetComponentsInChildren<PineappleAI>());
    }
}
