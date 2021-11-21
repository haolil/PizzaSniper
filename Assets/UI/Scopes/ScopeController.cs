using UnityEngine;

public class ScopeController : MonoBehaviour
{
    public int currentScope;
    public string SelectedScope = "SelectedScope";
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ScopeOne()
    {
        currentScope = 0;
        PlayerPrefs.SetInt(SelectedScope, 0);
    }

    public void ScopeTwo()
    {
        currentScope = 1;
        PlayerPrefs.SetInt(SelectedScope, 1);
    }

    public void ScopeThree()
    {
        currentScope = 2;
        PlayerPrefs.SetInt(SelectedScope, 2);
    }

    public void ScopeFour()
    {
        currentScope = 3;
        PlayerPrefs.SetInt(SelectedScope, 3);
    }

    public void ScopeFive()
    {
        currentScope = 4;
        PlayerPrefs.SetInt(SelectedScope, 4);
    }

    public void ScopeSix()
    {
        currentScope = 5;
        PlayerPrefs.SetInt(SelectedScope, 5);
    }
    public void ScopeSeven()
    {
        currentScope = 6;
        PlayerPrefs.SetInt(SelectedScope, 6);
    }
    public void ScopeEight()
    {
        currentScope = 7;
        PlayerPrefs.SetInt(SelectedScope, 7);
    }
}