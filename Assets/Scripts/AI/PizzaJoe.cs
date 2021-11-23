using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaJoe : MonoBehaviour
{
    [SerializeField] WindowBreak windowBreak;

    public void BreakWindow()
    {
        windowBreak.CheckValue();
    }
}
