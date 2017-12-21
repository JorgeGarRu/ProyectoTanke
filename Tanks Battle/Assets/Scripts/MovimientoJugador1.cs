using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador1 : MonoBehaviour
{


    public float inputZ;
    public float rotation;
    public float rotationCañon;
    public float speedMovement;
    public float speedRotation;
    public float speedRotationCañon;

    //Audio
    public AudioSource sonidoMovimiento;
    public float volumen;

    public Transform Cañon;

    //ANIMATOR
    public Animator animator;


    void Start()
    {
        
    }


    void Update()
    {
        inputZ = Input.GetAxis("Jugador1") * speedMovement;
        rotation = Input.GetAxis("RotacionJugador1") * speedRotation;
        rotationCañon = Input.GetAxis("Mouse X") * speedRotationCañon;

        Vector3 movement = new Vector3(0, 0, inputZ);
        Vector3 movementRotation = new Vector3(0, rotation, 0);
        Vector3 movementRotationCañon = new Vector3(0, 0, rotationCañon);
        transform.Translate(movement);
        transform.Rotate(movementRotation);
        Cañon.transform.Rotate(movementRotationCañon);

        //ANDAR 

        if (inputZ != 0)
        {
            animator.SetFloat("Andar", 1f);

        }
        else
        {
            animator.SetFloat("Andar", 0f);
        }

        //SONIDO MOVIMIENTO

        if (sonidoMovimiento)
        {
            if (inputZ != 0 || rotation != 0)
            {

                sonidoMovimiento.Play();

            }
            else
            {
                sonidoMovimiento.Stop();
            }
        }

        //BURLA
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Burla", true);
        } else
        {
            animator.SetBool("Burla", false);
        }
        
      
    }
}
    

