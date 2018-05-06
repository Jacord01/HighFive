using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public TMPro.TMP_InputField inputBar;

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadRanking()
    {
        string s = inputBar.text;
        Debug.Log(s);
        int finalScore = GameManager.instance.GetFinalScore();
        if (finalScore >= PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", finalScore);
            PlayerPrefs.SetString("High Name", s);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
