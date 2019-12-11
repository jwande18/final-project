using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGroupCounter : MonoBehaviour
{
	public GameObject enemyGroupOne;
	public GameObject enemyGroupTwo;
	public GameObject enemyGroupThree;
	public GameObject enemyGroupFour;
	public GameObject enemyGroupFive;
	
	public int enemyGroupCount;
	
    // Start is called before the first frame update
    void Start() {
		enemyGroupCount = 0;
		
        if(enemyGroupOne != null) {
			++enemyGroupCount;
		}
		
		if(enemyGroupTwo != null) {
			++enemyGroupCount;
		}
		
		if(enemyGroupThree != null) {
			++enemyGroupCount;
		}
		
		if(enemyGroupFour != null) {
			++enemyGroupCount;
		}
		
		if(enemyGroupFive != null) {
			++enemyGroupCount;
		}
    }

    // Update is called once per frame
    void Update() {
        if(enemyGroupCount <= 0) {
			// move to next scene
			if(SceneManager.GetActiveScene().name == "Desert") {
				Application.Quit();
			}
			else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
    }
}
