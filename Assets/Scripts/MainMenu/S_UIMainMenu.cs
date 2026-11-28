using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UIMainMenu : MonoBehaviour
{
    // [SerializeField] private GameObject B_NewGame;
    // [SerializeField] private GameObject B_Options;
    // [SerializeField] private GameObject B_Exit;

    public void onNewGameClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
