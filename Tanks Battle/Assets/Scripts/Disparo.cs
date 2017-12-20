using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour {

    public Transform spawnBala;
    public GameObject bala;
    public float fuerzaDisparo;
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


    void Start () {
       
	}
	
	
	void Update () {


        float inputFire = Input.GetAxis("Fire1");
        if (inputFire!=0 && (nextFire<Time.time))
        {
            nextFire = Time.time + rateFire;
            
            if(Cañon.transform.rotation.z >= -90f || Cañon.transform.rotation.z <= 90f)
            {
                //animator.SetBool("RetrocesoInverso", false);
                animator.SetBool("Retroceso", true);
            } else
            {
                //animator.SetBool("Retroceso", false);
                animator.SetBool("RetrocesoInverso", true);
            }

         
           

            
            particula.Play();
            AudioSource.PlayClipAtPoint(sonidoDisparo, transform.position,volumen);

            Ray ray = new Ray(spawnBala.position, -spawnBala.transform.up);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Vector3 pointHit = hit.point;
                 cloneExplosion = GameObject.Instantiate(explosion, pointHit, Quaternion.identity);
                StartCoroutine(DestroyParticle());

                if(hit.collider.gameObject.tag == "Jugador1")
                {
                    contador--;

                    if (contador == 0)
                    {
                        Animator ani = hit.collider.gameObject.GetComponentInChildren<Animator>();
                        ani.SetBool("Muriendo", true);
                       
                    }

                    Image imagen = Canvas.FindObjectOfType<Image>();
                    imagen.fillAmount -= 0.33f;
                    
                }
            }

        }
        else
        {
            animator.SetBool("Retroceso", false);
        }
	}

    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(cloneExplosion.gameObject);
    }

}
