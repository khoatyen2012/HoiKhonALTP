using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


    public AudioClip[] arrAudioClip;

    #region Singleton
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundManager>();
            return _instance;
        }
    }
    #endregion


    public void PlayAudioCick()
    {
		if (GameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [0]);
		}
    }

    public void PlayAudioOver()
    {
		if (GameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [1]);
		}
    }

    public void PlayAudioGameOver()
    {
		if (GameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [2]);
		}
    }

    public void PlayAudioGameOanh()
    {
		if (GameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [3]);
		}
    }

    public void PlayAudioWin()
    {
		if (GameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [4]);
		}
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
