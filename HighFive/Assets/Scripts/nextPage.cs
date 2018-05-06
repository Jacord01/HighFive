using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class nextPage : MonoBehaviour {

    public GameObject info1, info2, nextButt,continueButt;

	public void changePage()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        info1.SetActive(false);
        info2.SetActive(true);
        nextButt.SetActive(false);
        continueButt.SetActive(true);
    }
    public void changeScene()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        SceneManager.LoadScene(2);
    }
}
