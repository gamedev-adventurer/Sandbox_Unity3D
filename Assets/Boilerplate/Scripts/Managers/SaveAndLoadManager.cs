using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoadManager : MonoBehaviour {



	[System.Serializable]
	public class PlayerData
	{

		public float fxVolume;
		public float musicVolume;

		//public int[] levelIsLocked;
		//public int[] levelClearedWithNumberOfStars;
		//public int[] levelClearedWithScore;
	}



	//CONSTANTS
	const string SAVES_ROUTE = "/Saves";
	const string PLAYER_DATA_ROUTE = "/Saves/playerdata.dat";
	const int PLAYER_DATA = 0;

    protected static SaveAndLoadManager instance;

    public static SaveAndLoadManager Instance{
        get{
            return instance;
        }
    }

	void Awake()
	{

		if (instance == null)


			instance = this;


		else if (instance != this)


			Destroy(gameObject);    


		DontDestroyOnLoad(gameObject);

	}


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	
	}






	public void LoadPlayerData()
	{
		string file = Application.persistentDataPath + PLAYER_DATA_ROUTE;

		bool fileExist = CheckIfFileExist (file);

		if (fileExist == true) {
			Debug.Log ("LOADING PLayerData");
			LoadFile (file, PLAYER_DATA);
		} else {

			Debug.Log ("no PLayerData existing");
			string saveRoute = Application.persistentDataPath + SAVES_ROUTE;
			DirectoryInfo savesDir = new DirectoryInfo (saveRoute);

			if (savesDir.Exists == false) {
				Debug.Log ("cant find saves");
				savesDir.Create ();

			}
		}

	}

	public void SavePlayerData()
	{
		Debug.Log ("Saving PLayerData");
		string file = Application.persistentDataPath + PLAYER_DATA_ROUTE;
		SaveFile (file,PLAYER_DATA);

	}	


	bool CheckIfFileExist(string fileToCheck)
	{

		bool fileExist = File.Exists (fileToCheck);
		return fileExist;
	}

	#region file handling
	void SaveFile(string fileToSave, int fileType)
	{
		Debug.Log ("creating PLayerData file");
		FileStream file = File.Open (fileToSave, FileMode.Create);
		SerializeFile (file, fileType);
		file.Close ();
        GameManager.Instance.saving = false;
        GameManager.Instance.gameState = GameManager.GameStates.Menu;
        Debug.Log ("saved PLayerData: "+ GameManager.Instance.saving);


	}

	void LoadFile(string fileToOpen, int fileType)
	{

		Debug.Log ("Open PLayerData file");
		FileStream savedFile = File.Open (fileToOpen, FileMode.Open);
		DeserializeFile (savedFile, fileType);
		savedFile.Close ();

		Debug.Log ("finish loading PLayerData");
	}

	#endregion

	#region serialize and deserialize handling

	void SerializeFile(FileStream fileToSave, int fileType)
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		switch (fileType) {

		case PLAYER_DATA:
			Debug.Log ("serializing PLayerData");
			PlayerData newPlayerData = new PlayerData ();
                newPlayerData.fxVolume = SoundManager.Instance.efxVolume;
                newPlayerData.musicVolume = SoundManager.Instance.musicVolume;
			//newPlayerData.levelIsLocked = new int[GameManager.instance.levelIsLocked.Length];
			//newPlayerData.levelClearedWithNumberOfStars =  new int[GameManager.instance.levelIsLocked.Length];
			//newPlayerData.levelClearedWithScore  = new int[GameManager.instance.levelIsLocked.Length];
			formatter.Serialize (fileToSave, newPlayerData);
			break;

		default:

			break;


		}
	}

	void DeserializeFile(FileStream savedFile, int fileType)
	{
		BinaryFormatter formatter = new BinaryFormatter ();


		switch (fileType) {

		case PLAYER_DATA:
			Debug.Log ("Deserializing PLayerData");
			PlayerData newPlayerData = (PlayerData)formatter.Deserialize (savedFile);
			SetPlayersSavedData (newPlayerData);
			break;

		default:

			break;


		}

	}
	#endregion

	void SetPlayersSavedData(PlayerData playerData)
	{

        SoundManager.Instance.setVolumeFromPlayerData (playerData.fxVolume,playerData.musicVolume);
		/*SoundManager.instance.se
		for (int i = 0; i < playerData.levelIsLocked.Length; i++) {

			//GameManager.instance.levelIsLocked [i] = playerData.levelIsLocked [i];
			//GameManager.instance.levelClearedWithNumberOfStars [i] = playerData.levelClearedWithNumberOfStars [i];
			//GameManager.instance.levelClearedWithScore [i] = playerData.levelClearedWithScore [i];

		}*/


	}
		
}
