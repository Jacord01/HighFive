using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]           //Este comando permite sacar al editor el vector de objetos de la clase Sound
public class Sound {

    public string name;         //El nombre del archivo de sonido
    public AudioClip clip;      //El contenedor del archivo de sonido

    [Range(0f, 1f)]                     //Este comando saca al editor el parametro siguiente con selector acotado
    public float volume = 0.7f;         //El volumen al que se reproduce el sonido
    [Range(0f, 1.5f)]
    public float pitch = 1.0f;          //La altura a la que se reproduce el sonido
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;   //Factor de aleatorización del volumen del sonido
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;    //Factor de aleatorización de la altura del sonido

    public bool loop = false;

    private AudioSource source;                 //La fuente emisora; se encarga de reproducir el contenido de AudioClip

    //Metodo mutador de la fuente
    public void setSource(AudioSource _source)
    {
        source = _source;                       //Asignamos la fuente deseada
        source.clip = clip;                     //Asignamos el clip declarado previamente
        source.loop = loop;
    }

    //Metodo para reproducir un sonido
    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));     //El volumen varía levemente a cada reproduccion
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));         //La altura varía levemente a cada reproduccion
        source.Play();                                                                          //Reproducimos el sonido gracias a un metodo de la fuente
    }

    //Metodo para parar la reproduccion de un sonido
    public void Stop()
    {
        source.Stop();      //Paramos el sonido gracias a un metodo de la fuente
    }

}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;    //Instancia unica del AudioManager

    [SerializeField]                        //Esta comando saca al editor el vector de sonidos
    Sound[] sounds;                         //Vector que almacena todos los sonidos

    void Awake()
    {
        
        if (instance != null)               //Si existe una instancia del AudioManager
        {
            if(instance != this)            //Si esa instancia no es la que nosotros hemos creado
            {
                Destroy(this.gameObject);   //Destruimos el GO que contenía dicha instancia
            }
        }
        else
        {
            instance = this;                //Inicializamos la instancia del AudioManager
            DontDestroyOnLoad(this);        //Evitamos que se destruya el AudioManager entre escenas
        }
           
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)                                     //Recorremos el vector de sonidos
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);   //Instanciamos un GO para cada uno de los sonidos
            _go.transform.SetParent(this.transform);                                //Lo emparentamos con el AudioManager por ordenar el editor
            sounds[i].setSource(_go.AddComponent<AudioSource>());                   //Añadimos una fuente de emision al sonido
        }
        playSound("Music");
    }

    //Metodo para reproducir un sonido especifico
    public void playSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)     //Buscamos en el vector de sonidos        
            if (sounds[i].name == _name)            //Si el nombre de alguno de los sonidos almacenados coincide
            {
                sounds[i].Play();                   //Lo reproducimos y paramos la busqueda
                return;
            }
        Debug.LogWarning("AudioManager no encontro el sonido " + _name);
    }

    public void stopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)     //Buscamos en el vector de sonidos        
            if (sounds[i].name == _name)            //Si el nombre de alguno de los sonidos almacenados coincide
            {
                sounds[i].Stop();                   //Lo detenemos y paramos la busqueda
                return;
            }
        Debug.LogWarning("AudioManager no encontro el sonido " + _name);
    }

}