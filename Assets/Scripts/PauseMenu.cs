using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject pauseMainMenuUI;
    [SerializeField] public GameObject settingsMenuUI;

    public void Start() {
        pauseMenuUI.SetActive(false);
        pauseMainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Pause()
    {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        pauseMainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
