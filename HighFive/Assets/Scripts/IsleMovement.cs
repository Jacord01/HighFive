using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IsleMovement : MonoBehaviour {

    bool change = false;
    bool vuelta = false;
    static float vel = 25;
    bool invokeActive = false;
    bool inDetector;
    float LastPosX, LastPosY;
    GameObject Water;
    GameObject detector;

    // Use this for initialization
    void Start () {
        Water = GameObject.FindGameObjectWithTag("Water");
        detector = GameObject.FindGameObjectWithTag("Detector");
    }
	
	// Update is called once per frame
	void Update () {
		if(change)
        {
            gameObject.transform.Translate(new Vector3(0.0f, -vel*Time.deltaTime, 0.0f));

            float AngleAmount = (Mathf.Cos(Time.time * 20) * 180) / Mathf.PI * 0.5f;
            AngleAmount = Mathf.Clamp(AngleAmount, -2, 2);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, AngleAmount);

            if (invokeActive)
            {
                invokeActive = false;
                LastPosX = this.gameObject.transform.position.x;
                LastPosY = this.gameObject.transform.position.y;
                Invoke("switchPosition", 7f);
            }
        }
        if(vuelta)
        {
            if (gameObject.transform.position.y <= 8)
                gameObject.transform.Translate(new Vector3(0.0f, vel * Time.deltaTime, 0.0f));
            else vuelta = false;
        }
    }

    void switchPosition()
    { 
        float x = Random.Range(-Water.transform.localScale.x+350, Water.transform.localScale.x-350);
        float z = Random.Range(-Water.transform.localScale.z+350, Water.transform.localScale.z-350);
        this.transform.position = new Vector3(x, transform.position.y, z);
        if (inDetector) switchPosition();
        change = false;
        vuelta = true;
        detector.transform.position = new Vector3(this.gameObject.transform.position.x, 0.0f, this.gameObject.transform.position.z);
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ShipMov>() != null)
        {
            other.gameObject.GetComponent<ShipMov>().setHealth(100);
            int pirates = GameManager.instance.getPirates();
            GameManager.instance.updateTotalPirates(pirates);
            GameManager.instance.setPiratesScore(0);
            GameManager.instance.checkPlayerHP(100);

            Timer.instance.addTime(5f * pirates);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ShipMov>() != null)
        {          
            Invoke("setChange", 1f);
            invokeActive = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detector")){ inDetector = true; }
        else inDetector = false;
    }

    void setChange()
    {
        change = true;
    }
}
