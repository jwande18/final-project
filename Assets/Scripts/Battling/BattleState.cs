using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	
	// battling interface elements
	public Image interfaceHUD;
	public Image interfaceSelector;
	public Text basicAttack;
	public Text specialAttack;
	public Text defendMove;
	public Text skipMove;
	
    // Start is called before the first frame update
    void Start() {
        isBattling = false;
		playerTurn = true;
		enemyCount = 0;
		
		// set battle interface element(s)
		interfaceHUD.enabled = false;
		interfaceSelector.enabled = false;
		basicAttack.enabled = false;
		specialAttack.enabled = false;
		defendMove.enabled = false;
		skipMove.enabled = false;
		
		mainTimer = GetComponent<BattleTimer>();
    }

    // Update is called once per frame
    void Update() {
		if(isBattling) {
			if(playerTurnComplete()) {
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
				playerTurn = true;
				
				if(enemyOne != null) {
					enemyOne.GetComponent<UnitInit>().moved = false;
					enemyOne.GetComponent<UnitInit>().attacked = false;
					enemyOne.GetComponent<UnitInit>().startingPosition = enemyOne.transform;
				}
				
				if(enemyTwo != null) {
					enemyTwo.GetComponent<UnitInit>().moved = false;
					enemyTwo.GetComponent<UnitInit>().attacked = false;
					enemyTwo.GetComponent<UnitInit>().startingPosition = enemyTwo.transform;
				}
				
				if(enemyThree != null) {
					enemyThree.GetComponent<UnitInit>().moved = false;
					enemyThree.GetComponent<UnitInit>().attacked = false;
					enemyThree.GetComponent<UnitInit>().startingPosition = enemyThree.transform;
				}
				
				if(enemyFour != null) {
					enemyFour.GetComponent<UnitInit>().moved = false;
					enemyFour.GetComponent<UnitInit>().attacked = false;
					enemyFour.GetComponent<UnitInit>().startingPosition = enemyFour.transform;
				}
				
				if(enemyFive != null) {
					enemyFive.GetComponent<UnitInit>().moved = false;
					enemyFive.GetComponent<UnitInit>().attacked = false;
					enemyFive.GetComponent<UnitInit>().startingPosition = enemyFive.transform;
				}
				
				mainTimer.timerCount = 0;
			}
			
			// check for enemy attack
			if(!playerTurn) {
				if(mainTimer.timerCount > 250 && mainTimer.timerCount < 500) {
					if(enemyOne != null) {
						if(!enemyOne.GetComponent<UnitInit>().turn) {
							enemyOne.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 500 && mainTimer.timerCount < 750) {
					if(enemyTwo != null) {
						if(!enemyTwo.GetComponent<UnitInit>().turn) {
							enemyTwo.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 750 && mainTimer.timerCount < 1000) {
					if(enemyThree != null) {
						if(!enemyThree.GetComponent<UnitInit>().turn) {
							enemyThree.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 1000 / 2 && mainTimer.timerCount < 1250) {
					if(enemyFour != null) {
						if(!enemyFour.GetComponent<UnitInit>().turn) {
							enemyFour.GetComponent<UnitInit>().turn = true;
						}
					}
				}
				else if(mainTimer.timerCount > 1250 / 2 && mainTimer.timerCount < 1500) {
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
		
		// set battle interface element(s)
		interfaceHUD.enabled = false;
		interfaceSelector.enabled = false;
		basicAttack.enabled = false;
		specialAttack.enabled = false;
		defendMove.enabled = false;
		skipMove.enabled = false;
		
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
	
	public void enableBattleHUD() {
		// set battle interface element(s)
		interfaceHUD.enabled = true;
		interfaceSelector.enabled = true;
		basicAttack.enabled = true;
		specialAttack.enabled = true;
		defendMove.enabled = true;
		skipMove.enabled = true;
	}
}
