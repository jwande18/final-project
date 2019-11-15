using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerRadius : MonoBehaviour
{
	public GameObject textString;
	public BattleState battle_m;
	
	UnityEngine.AI.NavMeshAgent agent;
	Transform unit;
	
	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "UnitPlayer") {
			transform.parent.gameObject.GetComponent<UnitInit>().selected = true;
			unit = collision.transform;
			textString.GetComponent<MeshRenderer>().enabled = true;
			battle_m.isBattle = true;
			battle_m.lookingPoint = collision.transform.position;
		}
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
