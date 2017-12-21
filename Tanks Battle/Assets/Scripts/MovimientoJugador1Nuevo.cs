using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador1Nuevo : MonoBehaviour {

    
    float inputZ;
    float rotation;
    //float rotationCañon;
    public float speedMovement;
    public float speedRotation;
    //public float speedRotationCañon;
	public float AnguloMaximo = 45;


    public Transform Cañon;

    void Start () {
		
	}
	
	
	void Update () {

		if ((transform.localRotation.eulerAngles.x>=(360-AnguloMaximo) || transform.localRotation.eulerAngles.x<=AnguloMaximo) &&
			(transform.localRotation.eulerAngles.z>=(360-AnguloMaximo) || transform.localRotation.eulerAngles.z<=AnguloMaximo)
			) {


			inputZ = Input.GetAxis("Jugador1") * speedMovement;
			rotation = Input.GetAxis("RotacionJugador1") * speedRotation;
			//rotationCañon = Input.GetAxis("RotacionCañonJugador1") * speedRotationCañon;

			Vector3 movement = new Vector3(0, 0, inputZ);
			Vector3 movementRotation;
			if (inputZ < 0) {
				movementRotation = new Vector3 (0, -rotation, 0);
			} else {
				movementRotation = new Vector3 (0, rotation, 0);
			}

			//Vector3 movementRotationCañon = new Vector3(0, 0, rotationCañon);
			transform.Translate(movement);
			transform.Rotate(movementRotation);
			//Cañon.transform.Rotate(movementRotationCañon);
		}else{
			if (Input.GetKey (KeyCode.R)) {
				transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
			}
		}







        
    }
}
