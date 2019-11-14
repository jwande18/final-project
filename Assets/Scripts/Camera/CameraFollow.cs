using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform unit_to_follow;
	public UnitInit unit_1;
	public UnitInit unit_2;
	public UnitInit unit_3;
	private Vector3 camera_offset;
	
	public float smooth_factor = 0.01f;
	
    // Start is called before the first frame update
    void Start() {
		unit_to_follow = unit_1.gameObject.transform;
		camera_offset = (transform.position - unit_to_follow.position) * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
			// check for which unit to prioritize
			if(unit_1.selected) {
				unit_to_follow = unit_3.gameObject.transform;
				Vector3 new_position = unit_to_follow.position + camera_offset;
				transform.position = Vector3.Slerp(transform.position, new_position, smooth_factor);
			}
			else if(unit_2.selected) {
				unit_to_follow = unit_1.gameObject.transform;
				Vector3 new_position = unit_to_follow.position + camera_offset;
				transform.position = Vector3.Slerp(transform.position, new_position, smooth_factor);
			}
			else if(unit_3.selected) {
				unit_to_follow = unit_2.gameObject.transform;
				Vector3 new_position = unit_to_follow.position + camera_offset;
				transform.position = Vector3.Slerp(transform.position, new_position, smooth_factor);
			}
    }
}
