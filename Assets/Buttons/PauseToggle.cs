using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseToggle : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnValueChange()
	{

		if (GetComponent<Toggle> ().isOn == true) {

			transform.Find("Label").GetComponent<Text>().text = "Play";

		} else {


			transform.Find("Label").GetComponent<Text>().text = "Pause";

		}

	}
}
