using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public AudioClip SoundShoot;
    public GameObject prefabProjectil;
    private GameObject projectil; // influence l'obj bullet
    public float shootRate = 2f; //cadence de tire
    private float nextShoot; 
    public int speed = 1000; //vitesse du tire

   	void Update () {

        if(Time.time > nextShoot) //Permet de recup le tps en sec depuis le début du jeu, au demarrage nextShoot est = a 0
        {
            nextShoot = Time.time + shootRate; // A chq shoot, nextShoot qui est + petit que Time.time. redef en Time.time + shooRate de 2 sec
            projectil = Instantiate (prefabProjectil, transform.position, Quaternion.identity) as GameObject; //Créer un clone d'un obj, projectil = instancie le proj
            GetComponent<AudioSource>().PlayOneShot(SoundShoot);
            projectil.GetComponent<Rigidbody> ().AddForce (transform.TransformDirection(Vector3.right) * speed); // Force de l'objet, le transform.TransformDirection prend en compte l'orientation du canon en fonction du vecteur X
            Destroy (projectil, 2f); // Détruit le boulet pour éviter de surcharger le jeu
        }
        
	
	}
}
