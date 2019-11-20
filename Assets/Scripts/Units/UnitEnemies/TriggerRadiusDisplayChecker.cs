using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRadiusDisplayChecker : MonoBehaviour
{
	// battle controls
	public BattleState battleController;
	public GameObject mainCamera;
	
	// mesh renderers
	public Renderer triggerRadiusOne;
	public Renderer triggerRadiusTwo;
	public Renderer triggerRadiusThree;
	public Renderer triggerRadiusFour;
	public Renderer triggerRadiusFive;
	
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
				triggerRadiusOne.enabled = true;
			}
			
			if(triggerRadiusTwo != null) {
				triggerRadiusTwo.enabled = true;
			}
			
			if(triggerRadiusThree != null) {
				triggerRadiusThree.enabled = true;
			}
			
			if(triggerRadiusFour != null) {
				triggerRadiusFour.enabled = true;
			}
			
			if(triggerRadiusFive != null) {
				triggerRadiusFive.enabled = true;
			}
			
			Destroy(gameObject);
		}
	}
}
