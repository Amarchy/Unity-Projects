using UnityEngine;
using System.Collections;

public class ProjectilScript : MonoBehaviour {

    public AudioClip SoundDead;
    private Vector3 spawnPoint; // Coordo du point de spawn

	void Start () {
        spawnPoint = GameObject.Find ("SpawnPoint").GetComponent<Transform> ().position; //Affecte la position du spawnPoint, Unity trouve l'objet spawnPoint grâce à "Find"
	}
	
	
	void OnTriggerEnter (Collider other) { // Quand entre en collision
	
        if(other.gameObject.tag =="Player") // si touche le Player
        {
            GetComponent<AudioSource> ().PlayOneShot (SoundDead);
            other.transform.position = spawnPoint; // tansforme la position du player en spawnPoint
        }
	}

    
}
