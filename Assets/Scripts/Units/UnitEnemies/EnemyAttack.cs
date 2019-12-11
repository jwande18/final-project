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
	
	// renderers
	public Transform movementRadius;
	
	GameObject[] playerUnits;
	int target;
	
	NavMeshAgent agent;
	
	
	void OnTriggerEnter(Collider collision) {
			if(collision.gameObject.tag == "UnitPlayerOne" || collision.gameObject.tag == "UnitPlayerTwo" ||
					collision.gameObject.tag == "UnitPlayerThree") {
				collision.gameObject.GetComponent<UnitInit>().takeDamage(100);
			}
	}
	
    // Start is called before the first frame update
    void Start() {
		transform.parent.gameObject.GetComponent<UnitInit>().startingPosition = transform.parent.gameObject.transform.position;
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
				agent.speed = 3.5f;
				
				if(transform.parent.gameObject.tag == "UnitEnemyGoblin") {
					transform.parent.gameObject.GetComponent<UnitInit>().modelAnimation.SetBool("IsWalking", true);
				}
			}
			
			if((Vector3.Distance(transform.parent.gameObject.transform.position, playerUnits[target].transform.position) <= 3) ||
					(Vector3.Distance(transform.parent.gameObject.transform.position, transform.parent.gameObject.GetComponent<UnitInit>().startingPosition) > (movementRadius.localScale.x / 2))) {
						
				agent.speed = 0.0f;
				if(transform.parent.gameObject.tag == "UnitEnemyGoblin") {
					transform.parent.gameObject.GetComponent<UnitInit>().modelAnimation.SetBool("IsWalking", false);
				}
				
				transform.parent.gameObject.GetComponent<UnitInit>().moved = true;
				transform.parent.gameObject.GetComponent<UnitInit>().attacked = true;
			}

		}
    }
}
