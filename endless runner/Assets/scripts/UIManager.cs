using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public void pause()
    {
        Time.timeScale = 0;
    }

    public void play()
    {
        Time.timeScale = 1;
    }

    public void changeScene(int a)
    {
        SceneManager.LoadScene(a);
    }
    public void quit()
    {
        Application.Quit();
    }
}
