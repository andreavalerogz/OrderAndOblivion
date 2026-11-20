using UnityEngine;

public class S_HUDManager : MonoBehaviour
{
    // HUD MANAGER SIGLEtON
    public static S_HUDManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) // destroy if we already have one
        {
            Destroy(gameObject);
            return;
        }

        instance = this; // instance and dont destroy just in case
        DontDestroyOnLoad(gameObject);
    }
}
