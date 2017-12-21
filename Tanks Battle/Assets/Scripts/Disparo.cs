using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour {

    public Transform spawnBala;
    //public GameObject bala;
    //public float fuerzaDisparo;
    Vector3 direccionDisparo;
    public Animator animator;
    public float nextFire;
    public float rateFire;

    public Transform Cañon;

    //audio
    public AudioClip sonidoDisparo;
    public float volumen = 1f;

    public ParticleSystem particula;
    public ParticleSystem explosion;
    ParticleSystem cloneExplosion;

    //Vidas
    int contador = 3;

    //CANVAS
    public Canvas canva;

    public float velocidadRebote;


    void Start () {
       
	}
	
	
	void Update () {


        float inputFire = Input.GetAxis("Fire1");
        if (inputFire!=0 && (nextFire<Time.time)) //si disparo y el ratio de disparo es posible...
        {
            nextFire = Time.time + rateFire; 
            
            //RETROCESOS

            if(Cañon.transform.rotation.z >= -90f || Cañon.transform.rotation.z <= 90f)
            {
                //animator.SetBool("RetrocesoInverso", false);
                animator.SetBool("Retroceso", true);
            } else
            {
                //animator.SetBool("Retroceso", false);
                animator.SetBool("RetrocesoInverso", true);
            }

         
           

            
            particula.Play(); //particula de disparo
            AudioSource.PlayClipAtPoint(sonidoDisparo, transform.position,volumen); //sonido de disparo


            //RAYCAST
            Ray ray = new Ray(spawnBala.position, -spawnBala.transform.up);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Vector3 pointHit = hit.point; //punto donde choca el raycast
                 cloneExplosion = GameObject.Instantiate(explosion, pointHit, Quaternion.identity); //Efecto de explosion donde choca el raycast
                StartCoroutine(DestroyParticle()); //Corutina para destruir el objeto explosion

               
                if(hit.collider.gameObject.tag == "Player")//si donde choca el raycast tiene la etiqueta "Player"...
                {
                    contador--; //contador de vida

                    if (contador == 0) //cuando el contador llegue a 0...
                    {
                        Animator ani = hit.collider.gameObject.GetComponentInChildren<Animator>(); //accedemos al animator del objeto donde choque el raycast
                        ani.SetBool("Muriendo", true); //activamos la animacion de morir
                       
                    }


                    Muerte muerte = hit.collider.gameObject.GetComponent<Muerte>(); //accedemos al script "Muerte" del objeto donde choque el raycast
                    muerte.quitarVida(); //llamamos al metodo de quitarle vida
                    
                    
                }

                if (hit.collider.gameObject.tag == "Farolas")//si donde choca el raycast tiene la etiqueta "Farolas"...
                {
                    Vector3 direccion = pointHit - Cañon.transform.position; //sacamos la direccion de disparo
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>(); //accedemos al rigidbody de las farolas
                    rb.AddForce(direccion * velocidadRebote); // y le aplicamos una fuerza
                }
            }

        } 
        else //si no disparamos...
        {
            animator.SetBool("Retroceso", false); 
        }
	}

   


    IEnumerator DestroyParticle() //corutina para destruir las explosiones.
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(cloneExplosion.gameObject);
    }

}
