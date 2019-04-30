using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour {

    protected static SceneLoaderManager instance = null;

    public static SceneLoaderManager Instance{
        get{
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


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToMenu()
	{
		StartCoroutine(LoadNewSceneByName("Menu"));

	}
	public void GoToLevelByNumber(int indexLevel)
	{
		StartCoroutine(LoadNewSceneByIndex(indexLevel));

	}
	public void GoToLevelByName(string levelName)
	{
		StartCoroutine(LoadNewSceneByName(levelName));

	}
	public void ResetLevel()
	{
		Scene sceneNow = SceneManager.GetActiveScene ();
		StartCoroutine (LoadNewSceneByIndex(sceneNow.buildIndex));
	}
	public void LoadNextLevel()
	{

		Scene sceneNow = SceneManager.GetActiveScene ();
		int index = sceneNow.buildIndex + 1;

		if (index > SceneManager.sceneCountInBuildSettings - 1) {
			
			index = 0;
		} 

		StartCoroutine (LoadNewSceneByIndex(index));

	}
	IEnumerator LoadNewSceneByIndex(int levelIndex) {
		
		AsyncOperation async = SceneManager.LoadSceneAsync(levelIndex);

		while (!async.isDone) {
			yield return null;
		}
	}
	IEnumerator LoadNewSceneByName(string levelName) {

		AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

		while (!async.isDone) {
			yield return null;
		}
	}
}
