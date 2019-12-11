﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnMove : MonoBehaviour {
	UnitInit unitTurn;
	NavMeshAgent agent;
	public Transform movementRadius;
	BattleState battleController;
	
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
		unitTurn = GetComponent<UnitInit>();
		battleController = GameObject.Find("BattleManager").GetComponent<BattleState>();
    }

    // Update is called once per frame
    void Update() {
		// unit movement turn
        if(unitTurn.turn && !unitTurn.moved && battleController.playerTurn) {
			if(Input.GetMouseButtonDown(1)){				
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					if(Vector3.Distance(hit.point, agent.transform.position) <= (movementRadius.localScale.x / 2)) {
						unitTurn.moved = true;
						unitTurn.GetComponent<UnitInit>().modelAnimation.SetBool("IsIdle", false);
						agent.destination = hit.point;
					}
				}
			}
		}
		
		// unit attack and aim turn
		if(unitTurn.selected && unitTurn.turn && unitTurn.moved && !unitTurn.attacked) {
			// aiming
			if(Input.GetKey(KeyCode.A)) {
				// rotate left
				this.transform.Rotate(0.0f, -1.5f, 0.0f);
			}
			else if(Input.GetKey(KeyCode.D)) {
				// rotate right
				this.transform.Rotate(0.0f, 1.5f, 0.0f);
			}
		}
		
		// check if destination met
		if(Vector3.Distance(unitTurn.transform.position, agent.destination) < 0.2) {
			agent.speed = 0.0f;
			GetComponent<UnitInit>().modelAnimation.SetBool("IsIdle", true);
		}
    }
}
