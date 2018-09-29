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
	}
	
	// Update is called once per frame
	void Update () {
	
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

		if (stQuestion.Length > 192) {
			txtQuestion.scale = new Vector3 (0.4f,0.4f,0.4f);
		} else {
			txtQuestion.scale = new Vector3 (0.45f,0.45f,0.45f);
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
		AlSoundController.Instance.Stop();
		if (currentState == State.Question)
		{

			AlSoundController.Instance.PlayQuanTrong();
		}

	}

	public void setLaiVanSam(string caij)
	{
		spLaiVanSam.SetSprite(caij);
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
