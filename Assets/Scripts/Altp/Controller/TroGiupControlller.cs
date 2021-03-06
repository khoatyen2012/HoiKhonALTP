﻿using UnityEngine;
using System.Collections;

public class TroGiupControlller : MonoBehaviour {


	public tk2dUIItem btnNamMuoi;
	public tk2dUIItem btnHoiYKien;
	public tk2dUIItem btnHoiNguoiThan;
	public tk2dUIItem btnDoiCauHoi;


	#region Singleton
	private static TroGiupControlller _instance;

	public static TroGiupControlller instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<TroGiupControlller>();
			return _instance;
		}
	}
	#endregion


	public void resetHelp()
	{
		btnNamMuoi.gameObject.GetComponent<tk2dSprite>().SetSprite("nammuoi");
		btnNamMuoi.gameObject.GetComponent<BoxCollider>().enabled = true;
		btnHoiYKien.gameObject.GetComponent<tk2dSprite>().SetSprite("hoikhangia");
		btnHoiYKien.gameObject.GetComponent<BoxCollider>().enabled = true;
		btnHoiNguoiThan.gameObject.GetComponent<tk2dSprite>().SetSprite("nguoithan");
		btnHoiNguoiThan.gameObject.GetComponent<BoxCollider>().enabled = true;
		btnDoiCauHoi.gameObject.GetComponent<tk2dSprite>().SetSprite("doicauhoi");
		btnDoiCauHoi.gameObject.GetComponent<BoxCollider>().enabled = true;
		btnDoiCauHoi.gameObject.SetActive (false);
	}

	public void setEnableTuVan ()
	{
		btnDoiCauHoi.gameObject.SetActive (true);
	}


	IEnumerator WaitTimeNamMUoi(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		AlGameController.instance.helpNamMuoi();


	}

	IEnumerator WaitTimeKhanGia(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		AlPopupController.instance.ShowPopupKhanGia();


	}

	void btnNamMuoi_Onlick()
	{
		try{
			if (AlGameController.instance.currentState == AlGameController.State.Question)
			{
				AlGameController.instance.currentState = AlGameController.State.Help;
				AlSoundController.Instance.PlayNamMuoi();
				StartCoroutine(WaitTimeNamMUoi(4f));
				btnNamMuoi.gameObject.GetComponent<tk2dSprite>().SetSprite("nammuoi2");
				btnNamMuoi.gameObject.GetComponent<BoxCollider>().enabled=false;
			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	void btnHoiYKien_Onlick()
	{
		try
		{
			if (AlGameController.instance.currentState == AlGameController.State.Question)
			{

				AlGameController.instance.currentState = AlGameController.State.Help;
				AlSoundController.Instance.PlayKhanGia();
				btnHoiYKien.gameObject.GetComponent<tk2dSprite>().SetSprite("hoikhangia1");
				btnHoiYKien.gameObject.GetComponent<BoxCollider>().enabled = false;
				DapAnController.instance.doSetEnabal(false);
				StartCoroutine(WaitTimeKhanGia(6f));
			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	void btnHoiNguoiThan_Onlick()
	{
		try
		{
			if (AlGameController.instance.currentState == AlGameController.State.Question)
			{

				AlGameController.instance.currentState = AlGameController.State.Help;
				btnHoiNguoiThan.gameObject.GetComponent<tk2dSprite>().SetSprite("nguoithan2");
				btnHoiNguoiThan.gameObject.GetComponent<BoxCollider>().enabled = false;
				DapAnController.instance.doSetEnabal(false);
				AlPopupController.instance.ShowPopUpNguoiThan();

			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	void btnDoiCauHoi_Onlick()
	{
		try
		{
			if (AlGameController.instance.currentState == AlGameController.State.Question)
			{
				AlGameController.instance.currentState = AlGameController.State.Help;
				btnDoiCauHoi.gameObject.GetComponent<tk2dSprite>().SetSprite("doicauhoi2");
				btnDoiCauHoi.gameObject.GetComponent<BoxCollider>().enabled = false;
				//AlGameController.instance.currentState = AlGameController.State.Question;
				//AlGameController.instance.suget();
				DapAnController.instance.doSetEnabal(false);
				AlSoundController.Instance.PlayHoiToTuVan();
				StartCoroutine(WaitTimeToTuVan(2f));
			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	IEnumerator WaitTimeToTuVan(float time)
	{
		//do something...............
		yield return new WaitForSeconds (time);
		AlSoundController.Instance.PlayPing ();
		AlPopupController.instance.ShowPopUpTuVan();
	}


	// Use this for initialization
	void Start () {
		btnNamMuoi.OnClick += btnNamMuoi_Onlick;
		btnHoiYKien.OnClick += btnHoiYKien_Onlick;
		btnHoiNguoiThan.OnClick += btnHoiNguoiThan_Onlick;
		btnDoiCauHoi.OnClick += btnDoiCauHoi_Onlick;

	}

	// Update is called once per frame
	void Update () {

	}
}
