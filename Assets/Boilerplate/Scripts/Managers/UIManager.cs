using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {


	public AudioClip sceneMusic;

	CanvasGroup loadingScreen;
	CanvasGroup savingScreen;
	CanvasGroup menuScreen;
	CanvasGroup settingsScreen;
	CanvasGroup creditsScreen;

	// Use this for initialization
	void Start () {

		if (this.tag == "MenuScene") {

            GameManager.Instance.gameState = GameManager.GameStates.Menu;
			try{

				menuScreen = GameObject.FindGameObjectWithTag("Menu").GetComponent<CanvasGroup>();


			}catch{

				Debug.LogError ("UIManager ---> start() No se encontro el objeto menu");

			}

			try{

				settingsScreen = GameObject.FindGameObjectWithTag("Settings").GetComponent<CanvasGroup>();


			}catch{

				Debug.LogError ("UIManager ---> start() No se encontro el objeto loadingScreen");

			}
			try{

				creditsScreen = GameObject.FindGameObjectWithTag("Credits").GetComponent<CanvasGroup>();


			}catch{

				Debug.LogError ("UIManager ---> start() No se encontro el objeto loadingScreen");

			}

		}else if (this.tag == "Level")
		{


            GameManager.Instance.gameState = GameManager.GameStates.InLevel;
		}

		try{

			loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<CanvasGroup>();


		}catch{

			Debug.LogError ("UIManager ---> start() No se encontro el objeto loadingScreen");

		}

		try{

			savingScreen = GameObject.FindGameObjectWithTag("SavingScreen").GetComponent<CanvasGroup>();


		}catch{

			Debug.LogError ("UIManager ---> start() No se encontro el objeto SavingScreen");

		}



		if (sceneMusic != null) {

			SoundManager.Instance.ChangeMusicClip (sceneMusic);
		}
	

		SetSoundSliders ();
	}
	
	// Update is called once per frame
	void Update () {

		TurnOffAllCanvasGroups ();

		if (this.tag == "Level") {


		}
			

        if (GameManager.Instance.gameState == GameManager.GameStates.Menu) {

			menuScreen.alpha = 1;
			menuScreen.blocksRaycasts = true;
			menuScreen.interactable = true;

		}
        if (GameManager.Instance.gameState == GameManager.GameStates.Settings) {
			settingsScreen.alpha = 1;
			settingsScreen.blocksRaycasts = true;
			settingsScreen.interactable = true;

		}
        if (GameManager.Instance.gameState == GameManager.GameStates.Credits) {
			creditsScreen.alpha = 1;
			creditsScreen.blocksRaycasts = true;
			creditsScreen.interactable = true;

		}
        if (GameManager.Instance.gameState == GameManager.GameStates.LoadingLevel) {

			loadingScreen.alpha = 1;
			loadingScreen.blocksRaycasts = true;
			loadingScreen.interactable = true;
		}

        if (GameManager.Instance.saving == true) {

			savingScreen.alpha = 1;
			savingScreen.blocksRaycasts = true;
			savingScreen.interactable = true;
		}
	}

	void TurnOffAllCanvasGroups()
	{
		CanvasGroup[] canvasGroups = GameObject.FindObjectsOfType<CanvasGroup>();

		foreach (CanvasGroup canvas in canvasGroups) {

			canvas.alpha = 0;
			canvas.blocksRaycasts = false;
			canvas.interactable = false;
		}

	}

	public void SetSoundSliders()
	{
        if (GameManager.Instance.gameState == GameManager.GameStates.Menu) {

            GameObject.FindGameObjectWithTag ("MusicSlider").GetComponent<Slider> ().value = SoundManager.Instance.musicVolume;
            GameObject.FindGameObjectWithTag ("FXSlider").GetComponent<Slider> ().value = SoundManager.Instance.efxVolume;

		}

	}
		

}
