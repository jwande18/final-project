using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitInit))]
public class Movement : MonoBehaviour {
	// variables
	NavMeshAgent agent;
	public Transform goal;
	
	public void followUnit(Transform transform) {
		goal = transform;
	}
	
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
		if(GetComponent<UnitInit>().selected) {
			// move to point action
			if(Input.GetMouseButtonDown(1)){
				RaycastHit hit;
			
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					agent.destination = hit.point;
				}
			}
			
			// sprinting action
			if(Input.GetKeyDown(KeyCode.LeftShift)) {
				agent.speed = 5.0f;
			}
			else if(Input.GetKeyUp(KeyCode.LeftShift)) {
				agent.speed = 3.5f;
			}
		}
		else {
			// unit not selected
			agent.destination = goal.position;
		}
    }
}
