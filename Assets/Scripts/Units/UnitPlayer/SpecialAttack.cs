using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
	UnitInit unitTurn;
	Collider collisionFastAttack;
	
	void OnTriggerStay(Collider collision) {
		if(Input.GetKeyDown(KeyCode.W)) {
			if(unitTurn.turn && unitTurn.moved && !unitTurn.attacked) {
				if(unitTurn.tag == "UnitPlayerOne") {
					int critChance = Random.Range(5, 100);
					collision.gameObject.GetComponent<UnitInit>().takeDamage(critChance);
				}
				else if(unitTurn.tag == "UnitPlayerTwo") {
					int attackRate = Random.Range(1, 5);
					
					collision.gameObject.GetComponent<UnitInit>().takeDamage(10 * attackRate);
				}
				else if(unitTurn.tag == "UnitPlayerThree") {
					if(collision.gameObject.tag == "UnitPlayerOne" ||
						collision.gameObject.tag == "UnitPlayerTwo") {
						// heal teammate
						collision.gameObject.GetComponent<UnitInit>().takeHealing(25);
					}
				}
			}
		}
	}
	
    // Start is called before the first frame update
    void Start() {
        unitTurn = transform.parent.gameObject.GetComponent<UnitInit>();
		attackSpeed = 0;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.W)) {
			if(unitTurn.selected && unitTurn.turn) {
				if(unitTurn.moved && !unitTurn.attacked) {
					unitTurn.manaStat -= 15;
					unitTurn.attacked = true;
				}
			}
		}
    }
}
