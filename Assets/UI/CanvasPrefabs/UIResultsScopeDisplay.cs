using UnityEngine;
using UnityEngine.UI;

public class UIResultsScopeDisplay : MonoBehaviour
{
    public Image scopeUI;
    public Sprite scope1, scope2, scope3, scope4, scope5, scope6, scope7, scope8;
    ScopeController scopeController;
    Snipe snipe;

    private void Start()
    {
        scopeController = FindObjectOfType<ScopeController>();
        snipe = FindObjectOfType<Snipe>();

        switch (scopeController.currentScope)
        {
            case 0:
                scopeUI.sprite = scope1;
                snipe.GetComponent<SpriteRenderer>().sprite = scope1;
                break;
            case 1:
                scopeUI.sprite = scope2;
                snipe.GetComponent<SpriteRenderer>().sprite = scope2;
                break;
            case 2:
                scopeUI.sprite = scope3;
                snipe.GetComponent<SpriteRenderer>().sprite = scope3;
                break;
            case 3:
                scopeUI.sprite = scope4;
                snipe.GetComponent<SpriteRenderer>().sprite = scope4;
                break;
            case 4:
                scopeUI.sprite = scope5;
                snipe.GetComponent<SpriteRenderer>().sprite = scope5;
                break;
            case 5:
                scopeUI.sprite = scope6;
                snipe.GetComponent<SpriteRenderer>().sprite = scope6;
                break;
            case 6:
                scopeUI.sprite = scope7;
                snipe.GetComponent<SpriteRenderer>().sprite = scope7;
                break;
            case 7:
                scopeUI.sprite = scope8;
                snipe.GetComponent<SpriteRenderer>().sprite = scope8;
                break;
        }
    }
}