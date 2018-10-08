using UnityEngine;
using System.Collections;

public class AlSoundController : MonoBehaviour {


	public AudioSource audioSourceBGMusicPrefab;
	private AudioSource audioSourceBGMusicCreated;

	public AudioClip[] arrAudioClip;

	bool ok = true;

	#region Singleton
	private static AlSoundController _instance;

	public static AlSoundController Instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<AlSoundController>();
			return _instance;
		}
	}
	#endregion

	void Awake()
	{
		PlayBGMusic();

	}

	// Update is called once per frame
	void Update()
	{
		if ((!CheckISPlay()) && (ok == false)&&(AlGameController.instance.checkVoulumOpen))
		{

			audioSourceBGMusicCreated.Play();
			ok = true;
		}
	}


	void PlayBGMusic()
	{
		audioSourceBGMusicCreated =
			GameObject.Instantiate
			(
				audioSourceBGMusicPrefab
			) as AudioSource;
		audioSourceBGMusicCreated.loop = true;
		audioSourceBGMusicCreated.Play();   


	}

	public void rePlayBGMusic()
	{
		audioSourceBGMusicCreated.Play();
	}
	public void StopBGMusic()
	{
		audioSourceBGMusicCreated.Stop();
	}

	public void PauseBGMusic()
	{
		audioSourceBGMusicCreated.Pause();
	}

	public void PlayBatDau()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [0]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi1()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [1]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi2()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [2]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}


	public void PlayHoi3()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [3]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}


	public void PlayHoi4()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [4]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi5()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [5]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi6()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [6]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi7()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [7]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi8()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [8]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi9()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [9]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi10()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [10]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi11()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [11]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi12()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [12]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi13()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [13]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi14()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [14]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHoi15()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [15]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayChungTa()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [16]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayChonA()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [17]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayChonB()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [18]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayChonC()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [19]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayChonD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [20]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayGoiNguoiThan()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [21]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHetGio()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [22]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayKhanGia()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [23]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlaySaiA()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [24]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlaySaiB()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [25]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}
	public void PlaySaiC()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [26]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlaySaiD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [27]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}
	public void PlayNamMuoi()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [28]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}


	public void PlayDuaRa1()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [29]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayDuaRa2()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [30]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}


	public void PlayVuotQua14()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [31]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}



	public void PlayVuotQua15()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [32]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}


	public void PlayCamXuc()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [33]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayQuanTrong()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [34]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayTamBiet()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [35]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayDungA()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [36]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayDungB()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [37]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayDungC()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [38]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayDungD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [39]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayAB()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [40]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayAC()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [41]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayAD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [42]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayBC()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [43]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayBD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [44]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayCD()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [45]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHetMoc5()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [46]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}

	public void PlayHetMoc10()
	{
		if (AlGameController.instance.checkVoulumOpen) {
			tk2dUIAudioManager.Instance.Play (arrAudioClip [47]);
			audioSourceBGMusicCreated.Pause ();
			ok = false;
		}
	}



	public void Stop()
	{
		tk2dUIAudioManager.Instance.curentStop();
	}

	public bool CheckISPlay()
	{
		return tk2dUIAudioManager.Instance.CheckPlay();
	}
}
