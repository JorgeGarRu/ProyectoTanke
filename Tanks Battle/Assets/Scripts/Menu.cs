using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Animator animator;
    public ParticleSystem disparo;
    public AudioClip sonidoDisparo;
    public float volumen = 1f;
    public Text enter;
    
    void Start()
    {
        
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Juego");
        }
    }


    public void ParticulaDisparo()
    {
        disparo.Play();
        AudioSource.PlayClipAtPoint(sonidoDisparo,transform.position,volumen);
    }

    public void TextoMenu()
    {
        Text texto = enter.GetComponent<Text>();
        texto.enabled = true;
    }
}
