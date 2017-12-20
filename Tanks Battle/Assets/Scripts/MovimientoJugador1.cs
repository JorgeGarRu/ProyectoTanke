﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador1 : MonoBehaviour {

    
    public float inputZ;
    public float rotation;
    public float rotationCañon;
    public float speedMovement;
    public float speedRotation;
    public float speedRotationCañon;

    public Transform Cañon;

    void Start () {
		
	}
	
	
	void Update () {
        inputZ = Input.GetAxis("Jugador1") * speedMovement;
        rotation = Input.GetAxis("RotacionJugador1") * speedRotation;
        rotationCañon = Input.GetAxis("RotacionCañonJugador1") * speedRotationCañon;

        Vector3 movement = new Vector3(0, 0, inputZ);
        Vector3 movementRotation = new Vector3(0, rotation, 0);
        Vector3 movementRotationCañon = new Vector3(0, 0, rotationCañon);
        transform.Translate(movement);
        transform.Rotate(movementRotation);
        Cañon.transform.Rotate(movementRotationCañon);
    }
}
