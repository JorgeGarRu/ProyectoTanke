using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

    public Transform spawnBala;
    public GameObject bala;
    public float fuerzaDisparo;
    Vector3 direccionDisparo;
    public Animator animator;
    public float nextFire;
    public float rateFire;

    //audio
    public AudioClip sonidoDisparo;

    public ParticleSystem particula;
    public ParticleSystem explosion;
    ParticleSystem cloneExplosion;

    //Vidas
    int contador = 3;


    void Start () {
       
	}
	
	
	void Update () {

        

        if (Input.GetKeyDown(KeyCode.Space) && nextFire<Time.time)
        {
            nextFire = Time.time + rateFire;
            //GameObject cloneBala = GameObject.Instantiate(bala, spawnBala.position, spawnBala.rotation);
            //Rigidbody rb = cloneBala.GetComponent<Rigidbody>();
            
            //rb.velocity = -spawnBala.transform.up * fuerzaDisparo;
            animator.SetBool("Retroceso", true);
            particula.Play();
            AudioSource.PlayClipAtPoint(sonidoDisparo, transform.position);

            Ray ray = new Ray(spawnBala.position, -spawnBala.transform.up);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Vector3 pointHit = hit.point;
                 cloneExplosion = GameObject.Instantiate(explosion, pointHit, Quaternion.identity);
                StartCoroutine(DestroyParticle());

                if(hit.collider.gameObject.tag == "Jugador2")
                {
                    contador--;

                    if (contador == 0)
                    {
                        Animator ani = hit.collider.gameObject.GetComponentInChildren<Animator>();
                        ani.SetBool("Muriendo", true);
                    }
                    
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
