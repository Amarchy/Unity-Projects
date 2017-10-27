using UnityEngine;
using System.Collections;

public class PlateformFallScript : MonoBehaviour {

    //Déclarations des Variables

    public float SecToFall = 2; //Temporisation avant la Chute 
    private Rigidbody rb; //Composant rigidbody
    private Material plateformColor; // Composant color
    private Vector3 PositionDepart; //Stocke la position de départ;

    void Start ()
	{
        //Assignation des variables
        rb= GetComponent<Rigidbody>();
        PositionDepart =transform.position;
        plateformColor = GetComponent<Renderer> ().material;
    }

	void OnTriggerEnter (Collider Other) {  //méthode pour detecter l'entrée dans le trigger
		
        //Le Player entre dans le Trigger
		if(Other.gameObject.tag=="Player") 
		{
            plateformColor.color = Color.red; //Change la couleur en rouge
			StartCoroutine(FallDown()); //Execute la courtine (prend en compte le timer de chute) FallDown
		}

        //SpwanZone entre dans le Trigger
        if (Other.gameObject.tag=="ZoneSpawn")
		{
            plateformColor.color = Color.white; //Change la couleur en blanc (couleur de départ)
			rb.isKinematic=true; //Changement du IsKinematic à true pour que la plateforme ne soit plus affectée par la gravité
			transform.position=PositionDepart;//Changement de la position pour respawn de la plateforme
		}
	}

	IEnumerator FallDown() // Nom de la couroutine
	{
	    yield return new WaitForSeconds(SecToFall); //Pause en secondes
	    rb.isKinematic=false; //Changement du IsKinematic
    }
       
}
