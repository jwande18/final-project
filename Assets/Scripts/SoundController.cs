using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
	public AudioClip forestMusic;
	public AudioClip winterMusic;
	public AudioClip desertMusic;
	Scene currentScene;
	
    // Start is called before the first frame update
    void Start() {
		currentScene = SceneManager.GetActiveScene();
		
        if(currentScene.name == "Forest") {
			GetComponent<AudioSource>().clip = forestMusic;
		}
		else if(currentScene.name == "Winter") {
			GetComponent<AudioSource>().clip = winterMusic;
		}
		else if(currentScene.name == "Desert") {
			GetComponent<AudioSource>().clip = desertMusic;
		}
		
		GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
