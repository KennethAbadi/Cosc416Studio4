using UnityEngine;
using TMPro;  // Import TextMeshPro


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;
    private bool isSettingsMenuActive;


    public bool IsSettingsMenuActive => isSettingsMenuActive;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        // The game starts with the settings menu disabled
        DisableSettingsMenu();
        if (GameManager.Instance.IsSettingsMenuActive) return;
    }

    public void AddScore(int amount)
    {
        score += amount;
        coinCounter.UpdateScore(score);

    }
    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}