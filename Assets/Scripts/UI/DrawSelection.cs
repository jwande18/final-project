using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawSelection : MonoBehaviour
{
	public Text selection;
	
    // Start is called before the first frame update
    void Start() {
        selection.text = "Selected: None";
    }

    // Update is called once per frame
    void Update() {
        if(GetComponent<SelectUnit>().unit_1.selected) {
			selection.text = "Selected: Unit 1";
		}
		else if(GetComponent<SelectUnit>().unit_2.selected) {
			selection.text = "Selected: Unit 2";
		}
		else if(GetComponent<SelectUnit>().unit_3.selected) {
			selection.text = "Selected: Unit 3";
		}
		else {
			selection.text = "None";
		}
    }
}
