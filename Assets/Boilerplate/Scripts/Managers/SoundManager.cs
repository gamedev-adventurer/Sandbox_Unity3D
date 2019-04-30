using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	


	public AudioSource musicSource;


	public AudioSource[] efxSourceArray;


	public float efxVolume;
	public float musicVolume;

    protected static SoundManager instance = null;

    public static SoundManager Instance{
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


		efxVolume = Mathf.Clamp(efxVolume, 0.0f, 1.0f);
		musicVolume = Mathf.Clamp (musicVolume, 0.0f, 1.0f);
		musicSource.volume = musicVolume;

		foreach (AudioSource source in efxSourceArray) {

			source.volume = efxVolume;
		}
	}

	public void  PlaySingle(AudioClip clip)
	{


		foreach (AudioSource audioS in efxSourceArray) {

			if (audioS.isPlaying == false) {

				audioS.clip = clip;
				audioS.Play ();
				break;


			}

		}




	}

	public void ChangeMusicClip(AudioClip clip)
	{
		if (musicSource.clip != clip) {
			musicSource.clip = clip;
			musicSource.Play ();
		}
	}
	public void setVolumeFromPlayerData(float fx, float music)
	{
		musicVolume = music;
		efxVolume = fx;
		UIManager ui = GameObject.FindObjectOfType<UIManager> ();
		ui.SetSoundSliders ();

	}
}
