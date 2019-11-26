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
	
	// child objects
	public Transform unitModel;
	public Transform unitAttackRange;
	public Transform unitAccuracyPointer;
	
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
    }

    // Update is called once per frame
    void Update() {
		if(battleController.isBattling) {
			if(selected) {
				attackRadius.enabled = true;
				accuracyPointer.enabled = true;
			}
			else {
				attackRadius.enabled = false;
				accuracyPointer.enabled = false;
			}
		}
		
		// check health
		if(healthStat <= 0) {
			battleController.enemyCount -= 1;
			Destroy(this.gameObject.transform.parent.gameObject);
		}
		
		if(Input.GetKeyDown(KeyCode.H)) {
			healthStat -= 5;
		}
    }
	
	public void takeDamage(int damage) {
		healthStat = healthStat - damage;
	}
}
