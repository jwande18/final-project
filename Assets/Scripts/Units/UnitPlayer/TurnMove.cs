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
		// unit movement turn
        if(unitTurn.turn && !unitTurn.moved) {
			if(Input.GetMouseButtonDown(1)){
				unitTurn.moved = true;
				
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					agent.destination = hit.point;
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
    }
}
