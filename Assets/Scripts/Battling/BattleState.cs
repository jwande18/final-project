using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{
	public bool isBattling;
	public bool playerTurn;
	public int enemyCount;
	public Vector3 cameraFocus;
	public Vector3 cameraAnchor;
	
	// units
	public UnitInit unitOne;
	public UnitInit unitTwo;
	public UnitInit unitThree;
	
    // Start is called before the first frame update
    void Start() {
        isBattling = false;
		playerTurn = true;
		enemyCount = 0;
    }

    // Update is called once per frame
    void Update() {
        if(unitOne.moved && unitTwo.moved && unitThree.moved) {
			playerTurn = false;
			
			// reset unit movement
			unitOne.moved = true;
			unitTwo.moved = true;
			unitThree.moved = true;
			
			Debug.Log("Battling OVER");
		}
		else {
			
		}
		
		// check state
		if(enemyCount == 0 && isBattling) {
			isBattling = false;
			
			// clear battle interfaces
			UnitBattleClear();
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
	}
}
