using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnMove : MonoBehaviour {
	UnitInit unitTurn;
	NavMeshAgent agent;
	
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
		unitTurn = GetComponent<UnitInit>();
    }

    // Update is called once per frame
    void Update() {
        if(unitTurn.turn && !unitTurn.moved) {
			if(Input.GetMouseButtonDown(1)){
				unitTurn.moved = true;
				
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					agent.destination = hit.point;
				}
			}
		}
    }
}
