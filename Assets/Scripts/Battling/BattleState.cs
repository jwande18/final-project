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
				Debug.Log("PlayerTurnComplete");
				deselectUnits();
				playerTurn = false;
				
				unitOne.moved = false;
				unitOne.attacked = false;
				
				unitTwo.moved = false;
				unitTwo.attacked = false;
				
				unitThree.moved = false;
				unitThree.attacked = false;
			}
			else if(enemyTurnComplete()) {
				Debug.Log("EnemyTurnComplete");
				playerTurn = true;
				
				if(enemyOne != null) {
					enemyOne.GetComponent<UnitInit>().moved = false;
					enemyOne.GetComponent<UnitInit>().attacked = false;
				}
				
				if(enemyTwo != null) {
					enemyTwo.GetComponent<UnitInit>().moved = false;
					enemyTwo.GetComponent<UnitInit>().attacked = false;
				}
				
				if(enemyThree != null) {
					enemyThree.GetComponent<UnitInit>().moved = false;
					enemyThree.GetComponent<UnitInit>().attacked = false;
				}
				
				if(enemyFour != null) {
					enemyFour.GetComponent<UnitInit>().moved = false;
					enemyFour.GetComponent<UnitInit>().attacked = false;
				}
				
				if(enemyFive != null) {
					enemyFive.GetComponent<UnitInit>().moved = false;
					enemyFive.GetComponent<UnitInit>().attacked = false;
				}
				
				mainTimer.timerCount = 0;
			}
			
			// check for enemy attack
			Debug.Log(mainTimer.timerCount);
			if(!playerTurn) {
				if(mainTimer.timerCount > 500 / 2 && mainTimer.timerCount < 1000 / 2) {
					if(enemyOne != null) {
						if(!enemyOne.GetComponent<UnitInit>().turn) {
							enemyOne.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 1000 / 2 && mainTimer.timerCount < 1500 / 2) {
					if(enemyTwo != null) {
						if(!enemyTwo.GetComponent<UnitInit>().turn) {
							enemyTwo.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 1500 / 2 && mainTimer.timerCount < 2000 / 2) {
					if(enemyThree != null) {
						if(!enemyThree.GetComponent<UnitInit>().turn) {
							enemyThree.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 2000 / 2 && mainTimer.timerCount < 2500 / 2) {
					if(enemyFour != null) {
						if(!enemyFour.GetComponent<UnitInit>().turn) {
							enemyFour.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 2500 / 2 && mainTimer.timerCount < 3000 / 2) {
					if(enemyFive != null) {
						if(!enemyFive.GetComponent<UnitInit>().turn) {
							enemyFive.GetComponent<UnitInit>().turn = true;
						}
					}
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
		
		if(unitOne.moved && unitOne.attacked
			&& unitTwo.moved  && unitTwo.attacked
			&& unitThree.moved && unitThree.attacked) {
				result = true;
		}
		else {
			result = false;
		}
		
		return result;
	}
	
	bool enemyTurnComplete() {
		bool result = true;
		
		if(enemyOne != null) {
			if(enemyOne.GetComponent<UnitInit>().moved &&
				enemyOne.GetComponent<UnitInit>().attacked) {
					result = true;
			}
			else {
				return false;
			}
		}
		if(enemyTwo != null) {
			if(enemyTwo.GetComponent<UnitInit>().moved &&
				enemyTwo.GetComponent<UnitInit>().attacked) {
					result = true;
			}
			else {
				return false;
			}
		}
		if(enemyThree != null) {
			if(enemyThree.GetComponent<UnitInit>().moved &&
				enemyThree.GetComponent<UnitInit>().attacked) {
					result = true;
			}
			else {
				return false;
			}
		}
		if(enemyFour != null) {
			if(enemyFour.GetComponent<UnitInit>().moved &&
				enemyFour.GetComponent<UnitInit>().attacked) {
					result = true;
			}
			else {
				return false;
			}
		}
		if(enemyFive != null) {
			if(enemyFive.GetComponent<UnitInit>().moved &&
				enemyFive.GetComponent<UnitInit>().attacked) {
					result = true;
			}
			else {
				return false;
			}
		}
		
		return result;
	}
}
