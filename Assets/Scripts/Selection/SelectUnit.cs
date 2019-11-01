using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
	public UnitInit unit_1;
	public UnitInit unit_2;
	public UnitInit unit_3;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) {
			unit_1.selected = true;
			unit_2.selected = false;
			unit_3.selected = false;
			
			// re-color units
			unit_1.setUnitColor(Color.green);
			unit_2.setUnitColor(Color.red);
			unit_3.setUnitColor(Color.red);
		}
		else if(Input.GetKey(KeyCode.Alpha2)) {
			unit_1.selected = false;
			unit_2.selected = true;
			unit_3.selected = false;
			
			// re-color units
			unit_1.setUnitColor(Color.red);
			unit_2.setUnitColor(Color.green);
			unit_3.setUnitColor(Color.red);
		}
		else if(Input.GetKey(KeyCode.Alpha3)) {
			unit_1.selected = false;
			unit_2.selected = false;
			unit_3.selected = true;
			
			// re-color units
			unit_1.setUnitColor(Color.red);
			unit_2.setUnitColor(Color.red);
			unit_3.setUnitColor(Color.green);
		}
		
    }
}
