using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {





	public enum GameStates
	{
		Menu,
		Settings,
		Credits,
		LoadingLevel,
		InLevel,
		Pause
	};

	public GameStates gameState;

	public bool saving = false;

    protected static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;    
        }    
    }


	void Awake()
	{
		
		if (instance == null) {


			instance = this;

		} else if (instance != this) {


			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

	}

	void Start()
	{
		
        SaveAndLoadManager.Instance.LoadPlayerData ();
	}
		
	#region level handling



	#endregion

	#region comunication with Players car




	#endregion
}
