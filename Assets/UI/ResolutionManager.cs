using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
