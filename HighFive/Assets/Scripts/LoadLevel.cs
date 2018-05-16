using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {
    public RawImage fadeImg;
	public void loadInfo()
    {
        fadeImg.enabled = true;
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
