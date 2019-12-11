using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
	public UnitInit unitBase;
	BattleState battleController;
	
    // Start is called before the first frame update
    void Start() {
		battleController = GameObject.Find("BattleManager").GetComponent<BattleState>();
    }

    // Update is called once per frame
    void Update() {
        GetComponent<TextMesh>().text = "HP: " + unitBase.healthStat;
		//this.gameObject.transform.LookAt(battleController.cameraAnchor);
    }
}
