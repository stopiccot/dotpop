using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotScript : MonoBehaviour {

	protected Vector2 speed;
	protected RectTransform rectTransform;
    
	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform>();
		speed = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
		speed = speed / speed.magnitude;
		GetComponent<Image>().color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.anchoredPosition = rectTransform.anchoredPosition + 50 * speed * Time.deltaTime;

		const float fieldSize = 100;

		if (Mathf.Abs(rectTransform.anchoredPosition.x) > fieldSize) {
			speed.x = -speed.x;
		}

		if (Mathf.Abs(rectTransform.anchoredPosition.y) > fieldSize) {
            speed.y = -speed.y;
        }

		rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, -fieldSize, fieldSize), Mathf.Clamp(rectTransform.anchoredPosition.y, -fieldSize, fieldSize));
	}
}
