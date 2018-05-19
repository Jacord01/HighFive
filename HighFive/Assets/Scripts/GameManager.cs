using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    #region
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            timeStart = Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public GameObject water;
    public GameObject rocks;

    public NavMeshSurface surface;
    public bool cargaIslas = true;

    public GameObject hand = null;

    private int piratesScore = 0;
    public int TNTnumber = 0;
    public int bulletsNumber = 10;
    private int totalPirates = 0;

    public Image loadIMG;

    public TextMeshProUGUI pirateScoreText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI TNTText;
    public TextMeshProUGUI BulletsText;

    private float timeStart;
    private float endTime;

    public Image healthImage;

    [SerializeField]
    public GameObject[] islands;
    public GameObject[] ships;

    public void updateTotalPirates(int i)
    {
        totalPirates += i;
        updateTextPro(pirateScoreText, 0);
    }

    public void setTimeEnd(float time)
    {
        endTime = time;
    }

    public int GetFinalScore()
    {
        int totalTime = (int)(endTime - timeStart) * 2;
        int people = totalPirates * 10;

        return totalTime + people;
    }

    private void Update()
    {


        updateTextPro(TimerText, Timer.instance.timeLeft);
    }

    void eliminaMarineros()
    {
        moveToTargetBig[] aux = GameObject.FindObjectsOfType<moveToTargetBig>();

        foreach(moveToTargetBig T in aux)
        {
            Destroy(T.gameObject);
        }
    }
    // Use this for initialization
    void Start () {

        loadIMG.enabled = false;

        float posX, posZ;
        random(out posX, out posZ);

        Vector3 v = new Vector3(posX, 0, posZ);
        rocks.transform.position = v;
        Instantiate(rocks);

        initializeHUD();
        hand.transform.position = new Vector3(0, 8, 0);
        Instantiate(hand);

       int numIslands = Random.Range(200,300);
       
        for (int i = 0; i < numIslands; i++)
        {
            random(out posX, out posZ);


            int p = Random.Range(0, 100);

            if (p < 65)
            {
                if (Random.Range(0, 2) == 0)
                    p = 0;
                else
                    p = 1;
            }
            else if (p < 85)
            {
                if (Random.Range(0, 2) == 0)
                    p = 4;
                else p = 5;
            }

            else { if (Random.Range(0, 2) == 0) p = 2; else p = 3; }

            float y;
            if (p == 2 || p == 3)
                y = 2.35f;
            else if (p == 4 || p == 5)
                y = 2.5f;
            else y = 0;

           v = new Vector3(posX, y, posZ);
            islands[p].transform.position = v;
            Instantiate(islands[p]);
        }

        //Ships
        for (int i = 0; i < 300; i++)
        {
            random(out posX, out posZ);

            int p = Random.Range(0, 101);

            if (p < 50)
                p = 0;
            else if (p < 75)
                p = 1;
            else p = 2;

            v = new Vector3(posX, 0, posZ);

            ships[p].transform.position = v;
            Instantiate(ships[p]);

        }
        loadIMG.enabled = true;
        if (cargaIslas)
         surface.BuildNavMesh();
        loadIMG.enabled = false;

    }

    void random(out float x, out float z)
    {
        z = Random.Range(10, water.transform.localScale.z - 500);
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
            z *= -1;
        x = Random.Range(10, water.transform.localScale.x  - 500);
        int rnd2 = Random.Range(0, 2);
        if (rnd2 == 0)
            x *= -1;
    }

    public void addPiratesToScore(int quantity)
    {
        piratesScore += quantity;
        updateTextPro(pirateScoreText, piratesScore);
    }
    public void updateTextPro(TextMeshProUGUI text, float n)
    {
        text.SetText(((int)n).ToString());
    }
    private void initializeHUD()
    {
        pirateScoreText.SetText(piratesScore.ToString());
        TimerText.SetText(Timer.instance.timeLeft.ToString());
        TNTText.SetText(TNTnumber.ToString());
        BulletsText.SetText(bulletsNumber.ToString());
        healthImage.color = new Color32(0, 233, 30, 255);
    }
    public void checkPlayerHP(float hp)
    {
        Color32 c;
        if (hp < 25)
        {
            c = new Color32(255, 0, 0, 255);
            if(hp<= 0)
            {
                setTimeEnd(Time.deltaTime);
                SceneManager.LoadScene(4);
            }
        }
        else if (hp < 50)
        {
            c = new Color32(255, 122, 0, 255);
        }
        else if (hp < 75)
        {
            c = new Color32(229, 255, 66, 255);
        }
        else c = new Color32(0, 233, 30, 255);

        healthImage.color = c;
    }

    public void setPiratesScore(int a)
    {
        piratesScore = a;
        if (a == 0)
            eliminaMarineros();

        updateTextPro(pirateScoreText, piratesScore);
    }

    public int getPirates()
    {
        return piratesScore;
    }

    public void createShip()
    {
        float posX, posZ;

        random(out posX, out posZ);

        int p = Random.Range(0, 101);

        if (p < 60)
            p = 0;
        else if (p < 75)
            p = 1;
        else p = 2;

        Vector3 v = new Vector3(posX, 0, posZ);

        ships[p].transform.position = v;
        Instantiate(ships[p]);
    }
}
