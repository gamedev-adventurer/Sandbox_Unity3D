using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {

	public float timeToWait;

	void Awake()
	{

		Invoke ("LoadMenu",timeToWait);
		//LoadMenu();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadMenu()
	{
        SceneLoaderManager.Instance.GoToMenu ();
	}
}
