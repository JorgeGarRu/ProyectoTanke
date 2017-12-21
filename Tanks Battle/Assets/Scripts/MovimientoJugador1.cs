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

    //OVERLAP
    Collider[] Suelo;
    public bool enSuelo;
    public Transform rueda;
    public float radioRueda;
    public LayerMask suelo;

    //ANIMATOR
    public Animator animator;
    public float AnguloMaximo = 45;

    void Start()
    {
        
    }


    void Update()
    {

        //if((transform.localRotation.eulerAngles.x >= (360 - AnguloMaximo) || transform.localRotation.eulerAngles.x <= AnguloMaximo) &&
        //    (transform.localRotation.eulerAngles.z >= (360 - AnguloMaximo) || transform.localRotation.eulerAngles.z <= AnguloMaximo))
        //{

            inputZ = Input.GetAxis("Jugador1") * speedMovement;
            rotation = Input.GetAxis("RotacionJugador1") * speedRotation;
            rotationCañon = Input.GetAxis("Mouse X") * speedRotationCañon;

            Vector3 movement = new Vector3(0, 0, inputZ);
            Vector3 movementRotation = new Vector3(0, rotation, 0);
            Vector3 movementRotationCañon = new Vector3(0, 0, rotationCañon);
            transform.Translate(movement);
            transform.Rotate(movementRotation);
            Cañon.transform.Rotate(movementRotationCañon);


        //}
        //else
        //{
        //    if (Input.GetKey(KeyCode.R))
        //    {
        //        transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
        //    }
        //}


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

        //EN SUELO??
        Suelo = Physics.OverlapSphere(rueda.position, radioRueda, suelo);
        if (Suelo.Length == 0)
        {
            enSuelo = false;
        }
        else
        {
            enSuelo = true;
        }

        if (!enSuelo)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
            }
        }


        //BURLA
        //if (Input.GetKey(KeyCode.E))
        //{
        //    animator.SetBool("Burla", true);
        //} else
        //{
        //    animator.SetBool("Burla", false);
        //}


    }
}
    

