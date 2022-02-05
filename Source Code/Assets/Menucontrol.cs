using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontrol : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)&&(SceneManager.GetActiveScene().name!="mainmenu"))
        {
            Pause();
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueGame()
    {
        Scenemanager sc;
        Debug.Log("continue");
        sc = GameObject.FindGameObjectWithTag("SC").GetComponent<Scenemanager>();
        sc.dontDestroy=true;

        sc.load_ = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Pause()
    {
        Debug.Log("paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Debug.Log("Continue");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        GameManager gm;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        gm.save();
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
