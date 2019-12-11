using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInit : MonoBehaviour
{
	// unit base stats
	public int healthStat;
	public int defenseStat;
	public int manaStat;
	
	public bool selected = false;
	
	// combat variables
	public bool turn = false;
	public bool moved = false;
	public bool attacked = false;
	
	public BattleState battleController;
	public Renderer attackRadius;
	public Renderer accuracyPointer;
	public Renderer movementRadius;
	
	// child objects
	public Transform unitModel;
	public Transform unitAttackRange;
	public Transform unitAccuracyPointer;
	public Vector3 startingPosition;

	// animators
	public Animator healingSpell;
	public Animator damageSpell;
	
	// animations
	public Animator modelAnimation;
	
	public void setUnitColor(Color color) {
		Renderer unit_mesh = GetComponent<Renderer>();
		unit_mesh.material.SetColor("_Color", color);
	}
	
    // Start is called before the first frame update
    void Start() {
        Renderer unit_mesh = GetComponent<Renderer>();
		unit_mesh.material.SetColor("_Color", Color.red);
		
		// set battleController
		battleController = GameObject.Find("BattleManager").GetComponent<BattleState>();
		
		// unit children
		unitModel = this.gameObject.transform.GetChild(0);
		unitAttackRange = this.gameObject.transform.GetChild(1);
		unitAccuracyPointer = this.gameObject.transform.GetChild(2);
		
		// unit stats
		healthStat = 100;
		manaStat = 100;
		defenseStat = 5;
		
		// animation controls
		if(this.gameObject.tag == "UnitPlayerOne" || this.gameObject.tag == "UnitPlayerTwo" || this.gameObject.tag == "UnitPlayerThree") {
			//modelAnimation.SetBool("IsIdle", true);
		}
		else if(this.gameObject.tag == "UnitEnemyGoblin") {
			modelAnimation.SetBool("IsWalking", true);
		}
    }

    // Update is called once per frame
    void Update() {
		if(battleController.isBattling) {
			if(selected && turn) {
				if(!moved) {
					attackRadius.enabled = false;
					accuracyPointer.enabled = false;
					movementRadius.enabled = true;
				}
				else {
					attackRadius.enabled = true;
					accuracyPointer.enabled = true;
					movementRadius.enabled = false;
				}
			}
			else {
				attackRadius.enabled = false;
				accuracyPointer.enabled = false;
				movementRadius.enabled = false;
			}
		}
		else {
			attackRadius.enabled = false;
			accuracyPointer.enabled = false;
		}
		
		// check health
		if(healthStat <= 0) {
			if(this.tag == "UnitPlayerOne" || this.tag == "UnitPlayerTwo" || this.tag == "UnitPlayerThree") {
				turn = false;
				selected = false;
				attacked = true;
				moved = true;
				modelAnimation.SetBool("IsDefeat", true);
			}
			else {
				battleController.enemyCount -= 1;
				Destroy(this.gameObject.transform.parent.gameObject);
			}
		}
		
		if(manaStat <= 0) {
			if(this.tag == "UnitPlayerOne" || this.tag == "UnitPlayerTwo" || this.tag == "UnitPlayerThree") {
				turn = false;
				selected = false;
				attacked = true;
				moved = true;
				modelAnimation.SetBool("IsDefeat", true);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.W)) {
			if(this.tag == "UnitPlayerOne" || this.tag == "UnitPlayerTwo" || this.tag == "UnitPlayerThree") {
				defenseStat = 10;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.E)) {
			if(this.tag == "UnitPlayerOne" && selected) {
				moved = true;
				attacked = true;
			}
			else if(this.tag == "UnitPlayerTwo" && selected) {
				moved = true;
				attacked = true;
			}
			else if(this.tag == "UnitPlayerThree" && selected) {
				moved = true;
				attacked = true;
			}
		}
		
		// check turn
		if(moved && attacked) {
			turn = false;
		}
    }
	
	public void takeDamage(int damage) {
		if(healthStat - damage >= 0) {
			healthStat -= damage;
		}
		else {
			healthStat = 0;
		}

		damageSpell.Play("Explode");
	}
	
	public void takeHealing(int health) {
		if(healthStat + health <= 100) {
			healthStat += health;
		}
		else {
			healthStat = 100;
		}
		
		healingSpell.Play("HealingSpell");
	}
}
