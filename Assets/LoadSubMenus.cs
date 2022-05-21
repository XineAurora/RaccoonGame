using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSubMenus : MonoBehaviour
{
    [SerializeField]
    private Canvas deathMenu;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        LoadScenes();
    }

    private void LoadScenes()
    {
        Time.timeScale = 1;
    }

    public void DeathMenu()
    {
        deathMenu.gameObject.SetActive(true);
    }

    public void Restart()
    {
        //SceneManager.UnloadScene("grass");
        SceneManager.LoadScene("grass", LoadSceneMode.Single);
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene("menu");
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
    
    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

    private void SaveProgress()
    {
        //не работает пока что...
        PlayerPrefs.SetInt(SavingKeys.Coins, player.GetComponent<Bounty>().Coins);
    }
}
