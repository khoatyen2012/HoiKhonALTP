using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AlGameController : MonoBehaviour {

	#region Singleton
	private static AlGameController _instance;

	public static AlGameController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<AlGameController>();
			return _instance;
		}
	}
	#endregion

	public enum State
	{
		Start,
		Question,
		Reply,
		Help,
		PauseGame,
		GameOver

	}

	public State currentState;

	string sText = "databasez";
	List<AiLaTrieuPhu> lst = new List<AiLaTrieuPhu>();
	public bool checkVoulumOpen=true;
	public tk2dTextMesh txtQuestion;
	public Transform DAA;
	public Transform DAB;
	public Transform DAC;
	public Transform DAD;

	string stQuestion = "";
	string stDAA = "";
	string stDAB = "";
	string stDAC = "";
	string stDAD = "";

	public int level = 1;
	public int truecase;
	public int selectCase;

	int maxlevel = 0;

	public int dTime = 60;
	int demframe = 0;
	public tk2dTextMesh txtTime;
	public tk2dUIItem btnPower;
	public tk2dSprite spLaiVanSam;



	void Awake()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = -1;
	}

	// Use this for initialization
	void Start () {
		string ss = ReadText.readTextFile(sText);
		GetDaTa(ss);
		maxlevel = DataManager.GetHightScoreALTP();

		AlSoundController.Instance.PlayBatDau();
		btnPower.OnClick += btnPower_OnClick;
	}

	void btnPower_OnClick()
	{
		try
		{
			if (currentState == State.Question )
			{

				currentState = State.PauseGame;
				AlPopupController.instance.ShowPopupStop(level - 1);
			}
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == State.Question || currentState == State.Help)
		{
			if (demframe < 30)
			{
				demframe++;
			}
			else
			{
				dTime--;
				txtTime.text = "" + dTime;
				if (dTime <= 10)
				{
					txtTime.color = new Color(1, 0, 1, 1);
				}

				demframe = 0;
				if (dTime <= 0)
				{
					setLaiVanSam("traloisai");
					currentState = State.GameOver;

					int tmgb = level - 1;
					if (tmgb < 5)
					{
						tmgb = 0;
					}
					else if (tmgb >= 5 && tmgb < 10)
					{
						tmgb = 5;
					}
					else if (tmgb >= 10 && tmgb < 15)
					{
						tmgb = 10;
					}
					else
					{
						tmgb = 15;
					}

					DataManager.SaveHightScoreALTP(tmgb);
					DataManager.SaveHightSecondALTP(dTime);
					AlPopupController.instance.ShowPopupGameOver(tmgb,60-dTime);
					AlSoundController.Instance.PlayHetGio();
				}
			}

		}
	}

	IEnumerator WaitTimeVuot14(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);


		if (level == 14)
		{
			AlSoundController.Instance.PlayVuotQua14();
			nextgame(7f);
		}


	}

	IEnumerator WaitTimeNextLevel(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		DapAnController.instance.resetDapAN();
		currentState = State.Question;
		suget();




	}

	public void doSave()
	{

		DataManager.SaveHightScoreALTP(level - 1);
		DataManager.SaveHightSecondALTP(dTime);
	}



	void nextgame(float ss)
	{
		level++;
		StartCoroutine(WaitTimeNextLevel(ss));

	}

	IEnumerator WaitTimeWin(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		DataManager.SaveHightScoreALTP(15);
		DataManager.SaveHightSecondALTP(dTime);

		AlSoundController.Instance.PlayCamXuc();
		AlPopupController.instance.ShowPopUpWin();


	}

	IEnumerator WaitTimeCau10(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		AlSoundController.Instance.PlayHetMoc10();
		nextgame(7f);

	}

	IEnumerator WaitTimeEnableTuVan(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);
		TroGiupControlller.instance.setEnableTuVan ();
	}

	IEnumerator WaitTimeCau5(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		if (maxlevel >= 5) {
			nextgame (2f);
			TroGiupControlller.instance.setEnableTuVan ();
		} else {
			AlSoundController.Instance.PlayHetMoc5 ();
			nextgame (13f);
			if(level>=5)
			{
				StartCoroutine(WaitTimeEnableTuVan(12));
			}
		}

	}

	public  void doXuLy()
	{
		AlSoundController.Instance.Stop();
		if (truecase == selectCase)
		{
			//LevelController.instance.nhapnhay();
			setLaiVanSam("traloidung");


			if (level == 15)
			{
				AlSoundController.Instance.PlayVuotQua15();
				//se xu ly ket thuc o day
				StartCoroutine(WaitTimeWin(7f));
			}
			else
			{
				if (truecase == 1)
				{
					AlSoundController.Instance.PlayDungA();

				}
				if (truecase == 2)
				{
					AlSoundController.Instance.PlayDungB();
				}
				if (truecase == 3)
				{
					AlSoundController.Instance.PlayDungC();
				}

				if (truecase == 4)
				{
					AlSoundController.Instance.PlayDungD();
				}

				if (level == 5) {
					StartCoroutine(WaitTimeCau5(3f));
				}else if (level == 14)
				{
					StartCoroutine(WaitTimeVuot14(3f));
				}
				else
				{
					if (level == 10)
					{
						StartCoroutine(WaitTimeCau10(3f));
					}
					else
					{
						nextgame(5f);
					}

				}
			}







		}
		else
		{
			setLaiVanSam("traloisai");
			if (truecase == 1)
			{
				AlSoundController.Instance.PlaySaiA();
			}
			if (truecase == 2)
			{
				AlSoundController.Instance.PlaySaiB();
			}
			if (truecase == 3)
			{
				AlSoundController.Instance.PlaySaiC();
			}

			if (truecase == 4)
			{
				AlSoundController.Instance.PlaySaiD();
			}

			currentState = State.GameOver;
			StartCoroutine(WaitTimeGameOver(4f));
		}
	}

	IEnumerator WaitTimeGameOver(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		int tmgb = level - 1;
		if (tmgb < 5)
		{
			tmgb = 0;
		}
		else if (tmgb >= 5 && tmgb < 10)
		{
			tmgb = 5;
		}
		else if (tmgb >= 10 && tmgb < 15)
		{
			tmgb = 10;
		}
		else
		{
			tmgb = 15;
		}


		DataManager.SaveHightScoreALTP(tmgb);
		DataManager.SaveHightSecondALTP(dTime);
		maxlevel = tmgb;
		AlPopupController.instance.ShowPopupGameOver(tmgb, 60 - dTime);


	}

	public void suget()
	{
		List<AiLaTrieuPhu> lstTMG = new List<AiLaTrieuPhu>();
		foreach (AiLaTrieuPhu item in lst)
		{
			if (int.Parse(item.Level) != level)
			{
				continue;
			}
			lstTMG.Add(item);
		}

		int chon = UnityEngine.Random.Range(0, lstTMG.Count - 1);



		stQuestion="Câu "+level+": " + lstTMG[chon].Question;
		stDAA="A." +lstTMG[chon].Casea;
		stDAB="B." +lstTMG[chon].Caseb;
		stDAC="C." +lstTMG[chon].Casec;
		stDAD="D." +lstTMG[chon].Cased;

		if (stQuestion.Length > 230) {
			txtQuestion.scale = new Vector3 (0.45f,0.45f,0.45f);
		} else {
			txtQuestion.scale = new Vector3 (0.5f,0.5f,0.5f);
		}




		txtQuestion.text = stQuestion;

		if (stDAA.Length > 30) {
			DAA.GetChild (1).GetComponent<tk2dTextMesh> ().text = stDAA;
		} else {
			DAA.GetChild (0).GetComponent<tk2dTextMesh> ().text = stDAA;
		}

		if (stDAB.Length > 30) {
			DAB.GetChild (1).GetComponent<tk2dTextMesh> ().text = stDAB;
		} else {
			DAB.GetChild (0).GetComponent<tk2dTextMesh> ().text = stDAB;
		}

		if (stDAC.Length > 30) {
			DAC.GetChild (1).GetComponent<tk2dTextMesh> ().text = stDAC;
		} else {
			DAC.GetChild (0).GetComponent<tk2dTextMesh> ().text = stDAC;
		}
	
	
		if (stDAD.Length > 30) {
			DAD.GetChild (1).GetComponent<tk2dTextMesh> ().text = stDAD;
		} else {
			DAD.GetChild (0).GetComponent<tk2dTextMesh> ().text = stDAD;
		}

	
		truecase = int.Parse(lstTMG[chon].Truecase);

		if (level == 1)
		{
			AlSoundController.Instance.PlayHoi1();
		}

		if (level == 2)
		{
			AlSoundController.Instance.PlayHoi2();
		}

		if (level == 3)
		{
			AlSoundController.Instance.PlayHoi3();
		}

		if (level == 4)
		{
			AlSoundController.Instance.PlayHoi4();
		}

		if (level == 5)
		{
			AlSoundController.Instance.PlayHoi5();


			StartCoroutine(WaitTimeQuanTrong(3f));
		}

		if (level == 6)
		{
			AlSoundController.Instance.PlayHoi6();
		}

		if (level == 7)
		{
			AlSoundController.Instance.PlayHoi7();
		}

		if (level == 8)
		{
			AlSoundController.Instance.PlayHoi8();
		}

		if (level == 9)
		{
			AlSoundController.Instance.PlayHoi9();
		}
		if (level == 10)
		{
			AlSoundController.Instance.PlayHoi10();
			StartCoroutine(WaitTimeQuanTrong(2f));
		}
		if (level == 11)
		{
			AlSoundController.Instance.PlayHoi11();
		}
		if (level == 12)
		{
			AlSoundController.Instance.PlayHoi12();
		}
		if (level == 13)
		{
			AlSoundController.Instance.PlayHoi13();
		}
		if (level == 14)
		{
			AlSoundController.Instance.PlayHoi14();
		}
		if (level == 15)
		{
			AlSoundController.Instance.PlayHoi15();

		}

		if (level == 1 || level == 6 || level == 11)
		{
			btnPower.gameObject.SetActive(false);
		}
		else
		{
			btnPower.gameObject.SetActive(true);
		}


		//LevelController.instance.setEmptyChild(level);
		dTime = 60;
		demframe = 0;
		txtTime.color = new Color(1, 1, 1, 1);
		txtTime.text = "" + dTime;
		setLaiVanSam("hoi");

	}

	IEnumerator WaitTimeQuanTrong(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);
		//AlSoundController.Instance.Stop();
		if (currentState == State.Question)
		{

			AlSoundController.Instance.PlayQuanTrong();
		}

	}

	public void setLaiVanSam(string caij)
	{
		spLaiVanSam.SetSprite(caij);
	}

	public void setDefault()
	{
		level = 1;

		currentState = State.Question;


	}

	public void helpNamMuoi()
	{
		List<int> tmgList = new List<int>();
		for (int i = 1; i <= 4; i++)
		{
			if (i != truecase)
			{
				tmgList.Add(i);
			}
		}
		int chon = UnityEngine.Random.Range(0, tmgList.Count);
		tmgList.Remove(chon);
		LoaiPhuongAnSai(tmgList[0]);
		LoaiPhuongAnSai(tmgList[1]);

		doPhuongAnSai(tmgList[0], tmgList[1]);


	}

	void doPhuongAnSai(int k, int p)
	{
		if (k == 1)
		{
			if (p == 2)
			{
				AlSoundController.Instance.PlayAB();
			}

			if (p == 3)
			{
				AlSoundController.Instance.PlayAC();
			}

			if (p == 4)
			{
				AlSoundController.Instance.PlayAD();
			}
		}
		else if (k == 2)
		{
			if (p == 3)
			{
				AlSoundController.Instance.PlayBC();
			}

			if (p == 4)
			{
				AlSoundController.Instance.PlayBD();
			}
		}
		else
		{
			if (p == 4)
			{
				AlSoundController.Instance.PlayCD();
			}
		}
	}

	void LoaiPhuongAnSai(int k)
	{
		if (k == 1)
		{
			//txtDAA.text = "";
			DAA.GetChild (0).GetComponent<tk2dTextMesh> ().text = "";
			DAA.GetChild (1).GetComponent<tk2dTextMesh> ().text = "";
		}
		else if (k == 2)
		{
			DAB.GetChild (0).GetComponent<tk2dTextMesh> ().text = "";
			DAB.GetChild (1).GetComponent<tk2dTextMesh> ().text = "";
		}
		else if (k == 3)
		{
			DAC.GetChild (0).GetComponent<tk2dTextMesh> ().text = "";
			DAC.GetChild (1).GetComponent<tk2dTextMesh> ().text = "";
		}
		else
		{
			DAD.GetChild (0).GetComponent<tk2dTextMesh> ().text = "";
			DAD.GetChild (1).GetComponent<tk2dTextMesh> ().text = "";
		}
		currentState = State.Question;
	}

	void GetDaTa(string tmg)
	{
		string[] mang = tmg.Trim().Split('}');
		for (int i = 0; i < mang.Length-1; i++)
		{
			string[] items = mang[i].Split('^');
			  //Debug.Log("" + items[0] + ":" + items[1] + ":" + items[2] + ":" + items[3] + ":" + items[4] + ":" + items[5] + ":" + items[6] + ":" + items[7]);
			AiLaTrieuPhu altp = new AiLaTrieuPhu();
			altp.Id = "" + items[0];
			altp.Question = "" + items[1];
			altp.Level = "" + items[2];
			altp.Casea = "" + items[3];
			altp.Caseb = "" + items[4];
			altp.Casec = "" + items[5];
			altp.Cased = "" + items[6];
			altp.Truecase = "" + items[7];
			lst.Add(altp);
		}
	}

}
