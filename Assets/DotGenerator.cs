using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerator : MonoBehaviour {

	public RectTransform dotPrefab;

	void Start () {
		for (int i = 0; i < 10000; i++) {
			var dot = Instantiate(dotPrefab, this.transform);
			dot.gameObject.name = $"dot{i}";
			dot.anchoredPosition = new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
