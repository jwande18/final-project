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
	
	// mesh renderers
	public Renderer triggerRadiusOne;
	public Renderer triggerRadiusTwo;
	public Renderer triggerRadiusThree;
	public Renderer triggerRadiusFour;
	public Renderer triggerRadiusFive;
	
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
		if(collision.tag == "UnitPlayer") {
			// set the battle state
			battleController.isBattling = true;
			battleController.deselectUnits();
			battleController.cameraFocus = transform.position;
			battleController.cameraAnchor = collision.transform.position;
			
			// enable mesh renderers
			if(triggerRadiusOne != null) {
				enemyOne.GetComponent<UnitInit>().selected = true;
				triggerRadiusOne.enabled = true;
				unitStatOne.enabled = true;
				
				battleController.enemyOne = enemyOne;
				battleController.enemyCount += 1;
			}
			
			if(triggerRadiusTwo != null) {
				enemyTwo.GetComponent<UnitInit>().selected = true;
				triggerRadiusTwo.enabled = true;
				unitStatTwo.enabled = true;
				
				battleController.enemyTwo = enemyTwo;
				battleController.enemyCount += 1;
			}
			
			if(triggerRadiusThree != null) {
				enemyThree.GetComponent<UnitInit>().selected = true;
				triggerRadiusThree.enabled = true;
				unitStatThree.enabled = true;
				
				battleController.enemyThree = enemyThree;
				battleController.enemyCount += 1;
			}
			
			if(triggerRadiusFour != null) {
				enemyFour.GetComponent<UnitInit>().selected = true;
				triggerRadiusFour.enabled = true;
				unitStatFour.enabled = true;
				
				battleController.enemyFour = enemyFour;
				battleController.enemyCount += 1;
			}
			
			if(triggerRadiusFive != null) {
				enemyFive.GetComponent<UnitInit>().selected = true;
				triggerRadiusFive.enabled = true;
				unitStatFive.enabled = true;
				
				battleController.enemyFive = enemyFive;
				battleController.enemyCount += 1;
			}
			
			Destroy(gameObject);
		}
	}
}
