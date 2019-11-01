using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInit : MonoBehaviour
{
	public bool selected = false;
	
	public void setUnitColor(Color color) {
		Renderer unit_mesh = GetComponent<Renderer>();
		unit_mesh.material.SetColor("_Color", color);
	}
	
    // Start is called before the first frame update
    void Start() {
        Renderer unit_mesh = GetComponent<Renderer>();
		unit_mesh.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
