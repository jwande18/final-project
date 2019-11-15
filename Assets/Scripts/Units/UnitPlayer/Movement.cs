using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitInit))]
public class Movement : MonoBehaviour {
	// variables
	NavMeshAgent agent;
	public Transform goal;
	private int followDistance;
	
	public void followUnit(Transform transform) {
		goal = transform;
	}
	
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
		followDistance = Random.Range(2, 5);
		goal = null;
    }

    // Update is called once per frame
    void Update() {
		// unit selected - is leader
		if(GetComponent<UnitInit>().selected) {
			// move to point action
			if(Input.GetMouseButtonDown(1)){
				RaycastHit hit;
			
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					agent.destination = hit.point;
				}
			}
			
			// check if destination met
			if(Vector3.Distance(transform.position, agent.destination) < 1) {
				agent.speed = 0.0f;
			}
			else {
				agent.speed = 3.5f;
			}
		}
		else {
			// unit not selected - is follower
			if(goal != null) {
			if(Vector3.Distance(transform.position, goal.position) < followDistance) {
				// check if too close
				agent.speed = 0.0f;
				
				followDistance = Random.Range(2, 5);
			}
			else {
				agent.speed = 3.5f;
			}
			
			agent.destination = goal.position;
			
			}
		}
    }
}
