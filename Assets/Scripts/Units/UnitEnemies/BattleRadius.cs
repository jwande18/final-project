using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BattleRadius : MonoBehaviour
{
	UnityEngine.AI.NavMeshAgent agent;
	Transform unit;
	
	void OnCollisionEnter(Collision collision) {
		transform.parent.gameObject.GetComponent<UnitInit>().selected = true;
		unit = collision.transform;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.gameObject.GetComponent<UnitInit>().selected) {
			agent.destination = unit.position;
			Destroy(gameObject);
		}
    }
}
