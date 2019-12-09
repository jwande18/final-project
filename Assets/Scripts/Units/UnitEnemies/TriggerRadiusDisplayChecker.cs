using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRadiusDisplayChecker : MonoBehaviour
{
	// battle controls
	public BattleState battleController;
	public GameObject mainCamera;
	
	// units
	public GameObject enemyOne;
	public GameObject enemyTwo;
	public GameObject enemyThree;
	public GameObject enemyFour;
	public GameObject enemyFive;
	
	// unit stat renderers
	public Renderer unitStatOne;
	public Renderer unitStatTwo;
	public Renderer unitStatThree;
	public Renderer unitStatFour;
	public Renderer unitStatFive;
	
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "UnitPlayerOne" || collision.tag == "UnitPlayerTwo" || collision.tag == "UnitPlayerThree") {
			// set the battle state
			battleController.isBattling = true;
			battleController.deselectUnits();
			battleController.cameraFocus = transform.position;
			battleController.cameraAnchor = collision.transform.position;
			battleController.enableBattleHUD();
			// enable mesh renderers
			if(enemyOne != null) {
				enemyOne.GetComponent<UnitInit>().selected = true;
				unitStatOne.enabled = true;
				
				battleController.enemyOne = enemyOne;
				battleController.enemyCount += 1;
			}
			
			if(enemyTwo != null) {
				enemyTwo.GetComponent<UnitInit>().selected = true;
				unitStatTwo.enabled = true;
				
				battleController.enemyTwo = enemyTwo;
				battleController.enemyCount += 1;
			}
			
			if(enemyThree != null) {
				enemyThree.GetComponent<UnitInit>().selected = true;
				unitStatThree.enabled = true;
				
				battleController.enemyThree = enemyThree;
				battleController.enemyCount += 1;
			}
			
			if(enemyFour != null) {
				enemyFour.GetComponent<UnitInit>().selected = true;
				unitStatFour.enabled = true;
				
				battleController.enemyFour = enemyFour;
				battleController.enemyCount += 1;
			}
			
			if(enemyFive != null) {
				enemyFive.GetComponent<UnitInit>().selected = true;
				unitStatFive.enabled = true;
				
				battleController.enemyFive = enemyFive;
				battleController.enemyCount += 1;
			}
			
			Destroy(gameObject);
		}
	}
}
