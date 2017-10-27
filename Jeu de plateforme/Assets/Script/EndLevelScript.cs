using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour {


    public string LevelToLoad;
    public AudioClip SoundWin;

	
	void OnTriggerEnter (Collider Col) {

        if (Col.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNextLevel()); //Execute la courtine (prend en compte le timer de chute) FallDown
        }

    }

    IEnumerator LoadNextLevel() // Nom de la couroutine
    {

        GetComponent<AudioSource>().PlayOneShot(SoundWin);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(LevelToLoad);
    }

}
