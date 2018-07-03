using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerator : MonoBehaviour {

	public RectTransform dotPrefab;
	protected List<DotScript> dots = new List<DotScript>();

	void Start() {
		for (int i = 0; i < 300; i++) {
			var dot = Instantiate(dotPrefab, this.transform);
			dot.gameObject.name = $"dot{i}";
			dot.anchoredPosition = new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
			dots.Add(dot.GetComponent<DotScript>());
		}
	}
	
	// Update is called once per frame
	void Update() {
		for (int i = 0; i < dots.Count; i++) {
			if (dots[i].popping) {
				continue;
			}

			for (int j = 0; j < dots.Count; j++) {
				if (!dots[j].popping || i == j || dots[j].scale < 0.001f) {
					continue;
				}

				var d = dots[i].rectTransform.anchoredPosition - dots[j].rectTransform.anchoredPosition;
				if (d.magnitude < dots[i].defaultR + dots[i].defaultR * dots[j].scale) {
					dots[i].Pop();
					break;
				}
			}
		}
	}

	public void ButtonClick() {
		dots[0].Pop();
	}
}
