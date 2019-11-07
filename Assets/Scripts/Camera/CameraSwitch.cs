using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
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
        if(unit_1.selected) {
			transform.LookAt(unit_1.gameObject.transform.position);
		}
		else if(unit_2.selected) {
			transform.LookAt(unit_2.gameObject.transform.position);
		}
		else if(unit_3.selected) {
			transform.LookAt(unit_3.gameObject.transform.position);
		}
    }
}
