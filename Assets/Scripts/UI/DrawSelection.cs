using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawSelection : MonoBehaviour
{
	public Text selection;
	public Text turnSelection;
	public Text enemyCounter;
	public Image unitOneImage;
	public Image unitTwoImage;
	public Image unitThreeImage;
	public BattleState battleController;
	
    // Start is called before the first frame update
    void Start() {
        selection.text = "Selected: None";
    }

    // Update is called once per frame
    void Update() {
        if(GetComponent<SelectUnit>().unit_1.selected) {
			selection.text = "Selected: Unit 1";
			
			// image draw
			unitOneImage.enabled = true;
			unitTwoImage.enabled = false;
			unitThreeImage.enabled = false;
		}
		else if(GetComponent<SelectUnit>().unit_2.selected) {
			selection.text = "Selected: Unit 2";
			
			// image draw
			unitOneImage.enabled = false;
			unitTwoImage.enabled = true;
			unitThreeImage.enabled = false;
		}
		else if(GetComponent<SelectUnit>().unit_3.selected) {
			selection.text = "Selected: Unit 3";
			
			// image draw
			unitOneImage.enabled = false;
			unitTwoImage.enabled = false;
			unitThreeImage.enabled = true;
		}
		else {
			selection.text = "None";
		}
		
		if(GetComponent<SelectUnit>().unit_1.turn) {
			turnSelection.text = "Unit 1's Turn";
		}
		else if(GetComponent<SelectUnit>().unit_2.turn) {
			turnSelection.text = "Unit 2's Turn";
		}
		else if(GetComponent<SelectUnit>().unit_3.turn) {
			turnSelection.text = "Unit 3's Turn";
		}
		else {
			turnSelection.text = "No Ones's Turn";
		}
		
		enemyCounter.text = "Enemy Count: " + battleController.enemyCount;
    }
}
