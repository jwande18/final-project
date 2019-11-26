using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerRadius : MonoBehaviour
{
	public GameObject textString;
	public GameObject battleManager;
	
	UnityEngine.AI.NavMeshAgent agent;
	Transform unit;
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "UnitPlayer") {
			transform.parent.gameObject.GetComponent<UnitInit>().selected = true;
			unit = collision.transform;
		}
	}
	
    // Start is called before the first frame update
    void Start() {
        agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
		battleManager = GameObject.Find("BattleManager");
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
