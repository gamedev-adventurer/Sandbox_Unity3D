using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class ResizeToScreen : MonoBehaviour {

	public enum ScaleType
	{
		Height,
		Width,
		Full
	};

	public ScaleType scaleType;

	// Use this for initialization
	void Start () {

		ResizeSpriteToScreen ();
	}

	// Update is called once per frame
	void Update () {

		//ResizeSpriteToScreen ();

	}

	void ResizeSpriteToScreen() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;

		//transform.localScale = new Vector3(1,1,1);

		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;

		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		Vector3 newScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);

		if (scaleType == ScaleType.Height) {
			newScale = new Vector3 (transform.localScale.x, worldScreenHeight / height, transform.localScale.z);


		} else if (scaleType == ScaleType.Width) {

			newScale = new Vector3 (worldScreenWidth / width, transform.localScale.y, transform.localScale.z);
		} else if (scaleType == ScaleType.Full) {


			newScale = new Vector3 (worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z);

		}


		transform.localScale = newScale;

	}
}