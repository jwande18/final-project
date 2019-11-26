using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
	public UnitInit unitTurn;
	public Renderer attackRadius;
	public GameObject battleManager;
	public GameObject unitOne;
	public GameObject unitTwo;
	public GameObject unitThree;
	GameObject[] playerUnits;
	int target;
	
	NavMeshAgent agent;
	
	
	void OnTriggerEnter(Collider collision) {
			if(collision.gameObject.tag == "UnitPlayer") {
				collision.gameObject.GetComponent<UnitInit>().takeDamage(5);
			}
	}
	
    // Start is called before the first frame update
    void Start() {
        agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
		battleManager = GameObject.Find("BattleManager");
		
		playerUnits = new GameObject[3];
		playerUnits[0] = unitOne;
		playerUnits[1] = unitTwo;
		playerUnits[2] = unitThree;
		
		target = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
		if(!battleManager.GetComponent<BattleState>().playerTurn) {
			if(unitTurn.selected && unitTurn.turn) {
				agent.destination = playerUnits[target].transform.position;
			}
		
			if(Vector3.Distance(transform.position, agent.destination) <= (attackRadius.bounds.extents.magnitude / 2.0f)) {
				agent.speed = 0.0f;
			}
		}
    }
}
