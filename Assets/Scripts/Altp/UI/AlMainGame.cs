using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlMainGame : MonoBehaviour {

	public tk2dUIItem btnContinute;
	public tk2dUIItem btnDiemCao;
	public tk2dUIItem btnExit;
	public tk2dUIItem btnVolums;
	public tk2dUIItem btnHoiNGu;

	void btnHoiNGu_OnClick()
	{
		try
		{
			SceneManager.LoadScene("InGame");
		}
		catch (System.Exception)
		{

			throw;
		}

	}


	void btnVolums_OnClick()
	{
		try
		{
			if(AlGameController.instance.checkVoulumOpen)
			{
				btnVolums.transform.GetComponent<tk2dSprite>().SetSprite("vollock");
				AlSoundController.Instance.Stop();
				AlSoundController.Instance.PauseBGMusic();
				AlGameController.instance.checkVoulumOpen=false;
			}else
			{
				btnVolums.transform.GetComponent<tk2dSprite>().SetSprite("volopen");
				AlSoundController.Instance.rePlayBGMusic();
				AlGameController.instance.checkVoulumOpen=true;
			}
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	void btnExit_OnClick()
	{
		try
		{
			Application.Quit();
		}
		catch (System.Exception)
		{

			throw;
		}

	}


	void btnContinute_OnClick()
	{
		try
		{
			
			AlPopupController.instance.ShowSHA();
			AlSoundController.Instance.Stop();
			AlSoundController.Instance.PlayChungTa();
			AlPopupController.instance.HideMainGame();
			StartCoroutine(WaitTimeSHA(4f));
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	IEnumerator WaitTimeSHA(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		AlPopupController.instance.HideSHA();
		AlGameController.instance.suget();
		AlGameController.instance.currentState = AlGameController.State.Question;


	}

	void btnDiemCao_OnClick()
	{
		try
		{
			AlPopupController.instance.ShowPopupMaxScore();
			AlPopupController.instance.HideMainGame();
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	// Use this for initialization
	void Start () {
		btnDiemCao.OnClick += btnDiemCao_OnClick;
		btnContinute.OnClick += btnContinute_OnClick;
		btnExit.OnClick += btnExit_OnClick;
		btnVolums.OnClick += btnVolums_OnClick;
		btnHoiNGu.OnClick += btnHoiNGu_OnClick;

	}

	// Update is called once per frame
	void Update () {

	}
}
