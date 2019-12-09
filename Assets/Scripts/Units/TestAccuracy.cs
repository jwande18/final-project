using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAccuracy : MonoBehaviour
{
	UnitInit unitTurn;
	
	void OnTriggerStay(Collider collision) {		
		if(Input.GetKeyDown(KeyCode.Q)) {			
			if(unitTurn.turn && unitTurn.moved && !unitTurn.attacked) {
				if(collision.gameObject.tag == "UnitEnemySlime") {
					collision.gameObject.GetComponent<UnitInit>().takeDamage(10);
				}
				else if(collision.gameObject.tag == "UnitPlayerOne" ||
							collision.gameObject.tag == "UnitPlayerTwo") {
					if(unitTurn.tag == "UnitPlayerThree") {
						collision.gameObject.GetComponent<UnitInit>().takeHealing(25);
					}
				}
			}
		}
	}
	
    // Start is called before the first frame update
    void Start() {
		unitTurn = transform.parent.gameObject.GetComponent<UnitInit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
			if(unitTurn.selected && unitTurn.turn) {
				if(unitTurn.moved) {
					unitTurn.manaStat -= 5;
					unitTurn.attacked = true;
				}
			}
		}
    }
}
