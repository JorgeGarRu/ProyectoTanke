using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muerte : MonoBehaviour {

    public Image barraVida;
	
	void Start () {
		
	}
	
	
	void Update () {
        
    }

    public void quitarVida()
    {
        barraVida.fillAmount = barraVida.fillAmount - 0.33f;
    }
    
}
