using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sert pour utiliser "SceneManager.LoadScene(1)"

public class MenuScript : MonoBehaviour {

    public AudioClip SoundPlay;

    public void Quitter () {
        
        Application.Quit (); //Quitte l'appli, pr le bouton quitter

	}

    public void Jouer ()
    {

        StartCoroutine(WaitMusique());
        
    }

    IEnumerator WaitMusique() // Nom de la couroutine
    {

        GetComponent<AudioSource>().PlayOneShot(SoundPlay);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
