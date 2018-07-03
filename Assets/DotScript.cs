using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotScript : MonoBehaviour {

	public AnimationCurve popCurve;
	public float popDuration;
	public float defaultR;

	protected Vector2 speed;
	public RectTransform rectTransform { get; protected set; }

	public bool popping = false;
	public float scale = 1.0f;
	public float popTime = 0.0f;
    
	// Use this for initialization
	void Start() {
		rectTransform = GetComponent<RectTransform>();
		rectTransform.localScale = 2 * defaultR * Vector3.one;
		speed = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
		speed = speed / speed.magnitude;
		GetComponent<Image>().color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);      
	}
	
	// Update is called once per frame
	void Update() {
		if (popping) {
			popTime += Time.deltaTime;
			scale = popCurve.Evaluate(popTime / popDuration);
			rectTransform.localScale = 2 * defaultR * scale * Vector3.one;
			return;
		}

		rectTransform.anchoredPosition = rectTransform.anchoredPosition + 60 * speed * Time.deltaTime;

		const float fieldSize = 100;

		if (Mathf.Abs(rectTransform.anchoredPosition.x) > fieldSize) {
			speed.x = -speed.x;
		}

		if (Mathf.Abs(rectTransform.anchoredPosition.y) > fieldSize) {
            speed.y = -speed.y;
        }

		rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, -fieldSize, fieldSize), Mathf.Clamp(rectTransform.anchoredPosition.y, -fieldSize, fieldSize));
	}

	public void Pop() {
		speed = new Vector2(0, 0);
		popping = true;
		popTime = 0.0f;
	}
}
