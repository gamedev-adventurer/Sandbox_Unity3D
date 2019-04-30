using UnityEngine;
using System.Collections;

public class LoadingScreenController : MonoBehaviour {

	public enum LoadingAnimation
	{
		TextAlpha,
	};

	public LoadingAnimation loadingAnimation;

	void Awake()
	{

		GetComponent<Animator> ().SetTrigger ("TextAlpha");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
