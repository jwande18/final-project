using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTimer : MonoBehaviour
{
	public int timerCount;
	BattleState battleController;
	
    // Start is called before the first frame update
    void Start()
    {
		battleController = GetComponent<BattleState>();
        timerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(battleController.isBattling && !battleController.playerTurn) {
			timerCount += 1;
		}
    }
}
