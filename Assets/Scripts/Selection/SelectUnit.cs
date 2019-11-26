using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
	public UnitInit unit_1;
	public UnitInit unit_2;
	public UnitInit unit_3;
	public BattleState battleController;
	
    // Start is called before the first frame update
    void Start()
    {
		unit_1.selected = true;
    }
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) {
			unit_1.selected = true;
			unit_2.selected = false;
			unit_3.selected = false;
			
			// check for battling
			if(battleController.isBattling && (!unit_1.moved || !unit_1.attacked)) {
				unit_1.turn = true;
				unit_2.turn = false;
				unit_3.turn = false;
			}
			
			// re-color units
			unit_1.setUnitColor(Color.green);
			unit_2.setUnitColor(Color.red);
			unit_3.setUnitColor(Color.red);
			
			// set the goals
			unit_2.gameObject.GetComponent<Movement>().followUnit(unit_1.gameObject.GetComponent<Transform>());
			unit_3.gameObject.GetComponent<Movement>().followUnit(unit_2.gameObject.GetComponent<Transform>());
		}
		else if(Input.GetKey(KeyCode.Alpha2)) {
			unit_1.selected = false;
			unit_2.selected = true;
			unit_3.selected = false;
			
			// check for battling
			if(battleController.isBattling && (!unit_2.moved || !unit_2.attacked)) {
				unit_1.turn = false;
				unit_2.turn = true;
				unit_3.turn = false;
			}
			// re-color units
			unit_1.setUnitColor(Color.red);
			unit_2.setUnitColor(Color.green);
			unit_3.setUnitColor(Color.red);
			
			// set the goals
			unit_1.gameObject.GetComponent<Movement>().followUnit(unit_2.gameObject.GetComponent<Transform>());
			unit_3.gameObject.GetComponent<Movement>().followUnit(unit_1.gameObject.GetComponent<Transform>());
		}
		else if(Input.GetKey(KeyCode.Alpha3)) {
			unit_1.selected = false;
			unit_2.selected = false;
			unit_3.selected = true;
			
			// check for battling
			if(battleController.isBattling && (!unit_3.moved || !unit_3.attacked)) {
				unit_1.turn = false;
				unit_2.turn = false;
				unit_3.turn = true;
			}
			
			// re-color units
			unit_1.setUnitColor(Color.red);
			unit_2.setUnitColor(Color.red);
			unit_3.setUnitColor(Color.green);
			
			// set the goals
			unit_1.gameObject.GetComponent<Movement>().followUnit(unit_3.gameObject.GetComponent<Transform>());
			unit_2.gameObject.GetComponent<Movement>().followUnit(unit_1.gameObject.GetComponent<Transform>());
		}
    }
}
