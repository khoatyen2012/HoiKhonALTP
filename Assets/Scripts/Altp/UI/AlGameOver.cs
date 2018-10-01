using UnityEngine;
using System.Collections;

public class AlGameOver : MonoBehaviour {

	public tk2dUIItem btnContinute;

	public tk2dTextMesh txtLevel;
	public tk2dTextMesh txtMaxLevel;




	void callResetDapAn()
	{
		DapAnController.instance.resetDapAN();

	}

	public void setlevel(int level, int maxlevel)
	{
		txtLevel.text = "Vượt qua: Câu " + level;
		txtMaxLevel.text = "Thời gian: " + maxlevel+" giây.";

	}


	void btnContinute_OnClick()
	{
		try
		{
			AlSoundController.Instance.PlayTamBiet();
			callResetDapAn();
			AlPopupController.instance.HidePopupGameOver();
			AlPopupController.instance.HidePopupKhanGia();
			AlPopupController.instance.HidePopupNguoiThan();
			AlPopupController.instance.HidePopUpWin();
			AlPopupController.instance.ShowMainGame();
			TroGiupControlller.instance.resetHelp();
			AlGameController.instance.level = 1;

		
		}
		catch (System.Exception)
		{

			throw;
		}
	
	}



	// Use this for initialization
	void Start () {
		btnContinute.OnClick += btnContinute_OnClick;

	}

	// Update is called once per frame
	void Update () {

	}
}
