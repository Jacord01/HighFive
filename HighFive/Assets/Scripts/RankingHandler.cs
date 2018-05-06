using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class RankingHandler : MonoBehaviour {

    public TextMeshProUGUI rankingName, score;

	public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        rankingName.text = PlayerPrefs.GetString("High Name").ToUpper();
        score.text = PlayerPrefs.GetInt("High Score").ToString();

    }
}
