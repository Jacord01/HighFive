using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static Timer instance;
    #region
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    public float startTime = 4;
    [HideInInspector]
    public float timeLeft;


    private void Start()
    {
        timeLeft = startTime;
    }
    public void addTime(float addition)
    {
        timeLeft += addition;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);
        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameManager.instance.setTimeEnd(Time.deltaTime);
            SceneManager.LoadScene(4);
        }
    }
}
