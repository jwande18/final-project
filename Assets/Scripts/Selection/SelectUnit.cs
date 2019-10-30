using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
	public UnitInit unit_1;
	public UnitInit unit_2;
	
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
		}
		else if(Input.GetKey(KeyCode.Alpha2)) {
			unit_2.selected = true;
			unit_1.selected = false;
		}
		
    }
}
