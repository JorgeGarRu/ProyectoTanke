using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarJugadores : MonoBehaviour {

    public GameObject jugador;
    GameObject[] jugadores = new GameObject[4];
    public Transform spawnJugador1;
    public Transform spawnJugador2;

    public int NumeroJugadores;
	
	void Start () {

        for (int i = 0; i < NumeroJugadores; i++)
        {
            jugadores[i] = jugador;
        }
        foreach (GameObject jugador in jugadores)
        {
            if (jugador != null)
            {

                if (jugadores[0]==jugador)
                {
                    GameObject.Instantiate(jugador, spawnJugador1.position, spawnJugador1.rotation);
                } else
                {
                    GameObject.Instantiate(jugador, spawnJugador2.position, spawnJugador2.rotation);
                }
                
            }
            
           
        }

    }
	
	
	void Update () {
       
    }
}
