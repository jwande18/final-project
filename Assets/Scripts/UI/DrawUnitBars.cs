using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawUnitBars : MonoBehaviour
{
	public RectTransform unitHealthBar;
	public RectTransform unitManaBar;
	public UnitInit unitStats;
	Vector2 unitHealthBarStartPos;
	Vector2 unitManaBarStartPos;
	
    // Start is called before the first frame update
    void Start() {
        unitHealthBarStartPos = unitHealthBar.anchoredPosition;
		unitManaBarStartPos = unitManaBar.anchoredPosition;
    }

    // Update is called once per frame
    void Update() {
        // draw health
		unitHealthBar.sizeDelta = new Vector2(unitStats.healthStat * 3, 10);
		unitHealthBar.anchoredPosition = new Vector2(unitHealthBarStartPos.x - ((3.0f * (100.0f - unitStats.healthStat)) / 2.0f), unitHealthBarStartPos.y);
		
		// draw mana
		unitManaBar.sizeDelta = new Vector2(unitStats.manaStat * 2, 10);
		unitManaBar.anchoredPosition = new Vector2(unitManaBarStartPos.x - ((2.0f * (100.0f - unitStats.manaStat)) / 2.0f), unitManaBarStartPos.y);
    }
}
