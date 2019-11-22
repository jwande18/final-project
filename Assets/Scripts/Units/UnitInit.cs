using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInit : MonoBehaviour
{
	public bool selected = false;
	public bool turn = false;
	public BattleState battleController;
	public Renderer attackRadius;
	public Renderer accuracyRadius;
	
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
		if(battleController.isBattling) {
			if(selected) {
				attackRadius.enabled = true;
				accuracyRadius.enabled = true;
			}
			else {
				attackRadius.enabled = false;
				accuracyRadius.enabled = false;
			}
		}
        
    }
}
