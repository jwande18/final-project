using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{
	public BattleTimer mainTimer;
	public bool isBattling;
	public bool playerTurn;
	public int enemyCount;
	public Vector3 cameraFocus;
	public Vector3 cameraAnchor;
	
	// units
	public UnitInit unitOne;
	public UnitInit unitTwo;
	public UnitInit unitThree;
	
	// enemies
	public GameObject enemyOne;
	public GameObject enemyTwo;
	public GameObject enemyThree;
	public GameObject enemyFour;
	public GameObject enemyFive;
	
    // Start is called before the first frame update
    void Start() {
        isBattling = false;
		playerTurn = true;
		enemyCount = 0;
		
		mainTimer = GetComponent<BattleTimer>();
    }

    // Update is called once per frame
    void Update() {
		if(isBattling) {
			if(playerTurnComplete()) {
				playerTurn = false;
				deselectUnits();
			}
			else if(enemyTurnComplete()) {
				playerTurn = true;
			}
			
			// check for enemy attack
			if(!playerTurn) {
				if(mainTimer.timerCount > 1000 && mainTimer.timerCount < 2000) {
					enemyOne.GetComponent<UnitInit>().turn = true;
				}
				else if(mainTimer.timerCount > 2000 && mainTimer.timerCount < 3000) {
					enemyTwo.GetComponent<UnitInit>().turn = true;
				}
				else if(mainTimer.timerCount > 3000 && mainTimer.timerCount < 4000) {
					enemyThree.GetComponent<UnitInit>().turn = true;
				}
			}
		
			// check state
			if(enemyCount == 0 && isBattling) {
				isBattling = false;
			
				// clear battle interfaces
				UnitBattleClear();
			}
		}
    }
	
	public void deselectUnits() {
		unitOne.selected = false;
		unitTwo.selected = false;
		unitThree.selected = false;
	}
	
	public void UnitBattleClear() {
		unitOne.attackRadius.enabled = false;
		unitOne.accuracyPointer.enabled = false;
		unitTwo.attackRadius.enabled = false;
		unitTwo.accuracyPointer.enabled = false;
		unitThree.attackRadius.enabled = false;
		unitThree.accuracyPointer.enabled = false;
		
		playerTurn = false;
			
		// reset unit movement
		unitOne.moved = true;
		unitTwo.moved = true;
		unitThree.moved = true;
			
		// reset health
		unitOne.healthStat = 100;
		unitTwo.healthStat = 100;
		unitThree.healthStat = 100;
			
		// reset mana
		unitOne.manaStat = 100;
		unitTwo.manaStat = 100;
		unitThree.manaStat = 100;
			
		Debug.Log("Battling OVER");
	}
	
	bool playerTurnComplete() {
		bool result;
		
		if(!unitOne.turn && !unitTwo.turn && !unitThree.turn) {
				result = true;
		}
		else {
			result = false;
		}
		
		return result;
	}
	
	bool enemyTurnComplete() {
		return false;
	}
}
