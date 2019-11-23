using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{
	public bool isBattling;
	public bool playerTurn;
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
    }

    // Update is called once per frame
    void Update() {
        
    }
	
	public void deselectUnits() {
		unitOne.selected = false;
		unitTwo.selected = false;
		unitThree.selected = false;
	}
}
