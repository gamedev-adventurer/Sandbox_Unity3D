using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

	public enum InputType
	{
		mouse,
		touch,
	};

	public InputType inputType;

	bool touchMoved;

	bool resetingLevel = false;
	bool oncePlay = false;

	public AudioClip buttonSoundFx;

	void Awake()
	{

		Button[] sceneButtons = GameObject.FindObjectsOfType<Button> ();

		foreach (Button b in sceneButtons) {

			if (inputType == InputType.mouse) {

				b.animationTriggers.pressedTrigger = "Pressed";

			} else if (inputType == InputType.touch) {

				b.animationTriggers.pressedTrigger = "Highlighted";

			}

		}

	}

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

        if (Input.touchCount > 0 && GameManager.Instance.gameState == GameManager.GameStates.InLevel) {

			Touch touch = Input.GetTouch (0);


			if (touch.phase == TouchPhase.Began) {

				//Debug.Log("Touch Began");
				touchMoved = false;
			}
			if (touch.phase == TouchPhase.Stationary) {

				//Debug.Log("Touch Stationary");
				touchMoved = false;

			}
			if (touch.phase == TouchPhase.Moved) {

				//Debug.Log("Touch Moving");
				touchMoved = true;
			}

			if (touch.phase == TouchPhase.Ended) {
				//Debug.Log("Touch Ended");

				if (touch.tapCount > 0) {
					//Debug.Log("Tap");
				} else {
					//Debug.Log (touchMoved);
					if (touchMoved == true) {	
						//Debug.Log("Swipe");
					} else {

						//gm.PlayerEndedTouch ();

					}


				}

			}

		}
	
	}

	private bool IsPointerOverUIObject(Touch t)
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(t.position.x, t.position.y);

		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

		return results.Count > 0;
	}

	public void GoToMenu()
	{
		if (oncePlay == false) {
            GameManager.Instance.gameState = GameManager.GameStates.LoadingLevel;
			playButtonSound ();
            SceneLoaderManager.Instance.GoToMenu ();
			oncePlay = true;
		}
	}

	public void GotoLevel(int levelToGo)
	{
		if (oncePlay == false) {
			playButtonSound ();
            GameManager.Instance.gameState = GameManager.GameStates.LoadingLevel;
            SceneLoaderManager.Instance.GoToLevelByNumber (levelToGo);
			oncePlay = true;
		}
	}

	public void resetLevel()
	{
		if (resetingLevel == false) {
			resetingLevel = true;
			playButtonSound ();
            SceneLoaderManager.Instance.ResetLevel ();
		}


	}
	public void LoadNextLevel()
	{
        GameManager.Instance.gameState = GameManager.GameStates.LoadingLevel;
		playButtonSound ();
        SceneLoaderManager.Instance.LoadNextLevel ();
	}
	public void play()
	{
		if (oncePlay == false) {
			oncePlay = true;
            GameManager.Instance.gameState = GameManager.GameStates.LoadingLevel;
            SceneLoaderManager.Instance.GoToLevelByNumber (1);
			playButtonSound ();
		}
	}

	public void SavePlayerSettings()
	{
        if (GameManager.Instance.saving == false) {

            GameManager.Instance.saving = true;
            Debug.Log (GameManager.Instance.saving);
            SaveAndLoadManager.Instance.SavePlayerData ();
			playButtonSound ();


		}

	}
	public void ShowCredits()
	{
        GameManager.Instance.gameState = GameManager.GameStates.Credits;
		playButtonSound ();
	}
	public void showSettings()
	{
		
        GameManager.Instance.gameState = GameManager.GameStates.Settings;
			playButtonSound ();

	}
	public void showMenu()
	{
		
        GameManager.Instance.gameState = GameManager.GameStates.Menu;
			playButtonSound ();

	}

	public void PauseUnpauseGame(Toggle pause)
	{

		if (pause.isOn == true) {

			GameObject.Find ("MenuButtons").GetComponent<Animator> ().SetTrigger ("On");
            GameManager.Instance.gameState = GameManager.GameStates.Pause;

		} else {


			GameObject.Find ("MenuButtons").GetComponent<Animator> ().SetTrigger ("Off");
            GameManager.Instance.gameState = GameManager.GameStates.InLevel;
		}

		playButtonSound ();

	}
	void playButtonSound()
	{

        SoundManager.Instance.PlaySingle (buttonSoundFx);

	}

	public void SoundFXVolumeChanged(Slider slide)
	{
		
        SoundManager.Instance.efxVolume = slide.value;
	}


	public void MusicVolumenChanged(Slider slide)
	{

        SoundManager.Instance.musicVolume = slide.value;
	}

}
