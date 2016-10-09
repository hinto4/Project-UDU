using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject OptionsPanel;

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);
    }
}
