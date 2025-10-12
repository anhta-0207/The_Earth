using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpanwer;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject GameUI;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameWinMenu;
    [SerializeField] private GameObject redZone;
    
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private CinemachineCamera cinemachineCamera;
  
    
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cinemachineCamera.Lens.OrthographicSize = 5f;
        redZone.SetActive(false);
    }
    
    void Update()
    {
        
    }

    public void AddEnergy()
    {
        if (bossCalled)
            return;
        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpanwer.SetActive(false);
        GameUI.SetActive(false);
        audioManager.PlayBossSound();
        cinemachineCamera.Lens.OrthographicSize = 7f;
        redZone.SetActive(true);
    }

    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultSound();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameWinMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void WinMenu()
    {
        gameWinMenu.SetActive(true);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }
}

