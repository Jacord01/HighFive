using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public void loadInfo()
    {
        SceneManager.LoadScene(1);
    }
    public void loadRanking()
    {
        SceneManager.LoadScene(5);

    }
    public void loadControls()
    {
        SceneManager.LoadScene(3);

    }
    public void loadCredits()
    {
        SceneManager.LoadScene(6);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
