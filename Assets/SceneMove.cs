using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneMove : MonoBehaviour
{
    bool canUseKeys;
    ScopeController scopeController;
    GunController gunController;
    public string Scene;

    private void Start()
    {
        canUseKeys = false;
        /*scopeController = FindObjectOfType<ScopeController>();
        gunController = FindObjectOfType<GunController>();*/
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (canUseKeys)
        {
            if (Input.anyKey)
            {
                Destroy(scopeController);
                Destroy(gunController);
                SceneManager.LoadScene(Scene);
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        canUseKeys = true;
    }
}
