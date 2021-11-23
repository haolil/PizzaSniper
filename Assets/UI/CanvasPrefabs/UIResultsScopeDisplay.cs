using UnityEngine;
using UnityEngine.UI;

public class UIResultsScopeDisplay : MonoBehaviour
{
    public Image scopeUI;
    public Sprite scope1, scope2, scope3, scope4, scope5, scope6, scope7, scope8;
    ScopeController scopeController;
    public Image scopeChange;

    private void Start()
    {
        scopeController = FindObjectOfType<ScopeController>();

        switch (scopeController.currentScope)
        {
            case 0:
                //scaled
                scopeUI.sprite = scope1;
                scopeChange.sprite = scope1;
                scopeChange.transform.localScale = new Vector3(0.51f, 0.51f, 1);
                break;
            case 1:
                //green
                scopeUI.sprite = scope2;
                scopeChange.sprite = scope2;
                scopeChange.transform.localScale = new Vector3(0.51f, 0.51f, 1);
                break;
            case 2:
                //red
                scopeUI.sprite = scope3;
                scopeChange.sprite = scope3;
                scopeChange.transform.localScale = new Vector3(0.51f, 0.52f, 1);
                break;
            case 3:
                scopeUI.sprite = scope4;
                scopeChange.sprite = scope4;
                break;
            case 4:
                scopeUI.sprite = scope5;
                scopeChange.sprite = scope5;
                scopeChange.transform.localPosition = new Vector3(0, 58, 0);
                scopeChange.transform.localScale = new Vector3(0.65f, 0.55f, 1);
                break;
            case 5:
                scopeUI.sprite = scope6;
                scopeChange.sprite = scope6;
                scopeChange.transform.localScale = new Vector3(0.56f, 0.56f, 1);
                break;
            case 6:
                scopeUI.sprite = scope7;
                scopeChange.sprite = scope7;
                scopeChange.transform.localScale = new Vector3(0.56f, 0.56f, 1);
                break;
            case 7:
                scopeUI.sprite = scope8;
                scopeChange.sprite = scope8;
                //scopeChange.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                break;
        }
    }
}