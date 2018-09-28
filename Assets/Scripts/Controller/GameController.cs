using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour {


	#region Singleton
	private static GameController _instance;

	public static GameController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<GameController>();
			return _instance;
		}
	}
	#endregion

	public enum State
	{
		Start,
		Question,
		ReplyTrue,
		ReplyFalse,
		HetLuot,
		Next,
		GameOver
	}

	public int mScore = 0;
	public int mNgu=3;
	public int mNext=3;

	public State currentState;


	string sText = "hailao";
	public List<Question> lst=new List<Question>();
	public List<string> lstVuotQua=new List<string>();
	public bool checkVoulumOpen=true;

	public void doReset()
	{
		mScore = 0;
		mNgu=3;
		mNext=3;
	}

	// Use this for initialization
	void Start () {
	
		try
		{
		string ss = ReadText.readTextFile(sText);
		GetDaTa (ss);

		string stVuotQua = DataManager.GetVuotQua ();
		if (stVuotQua.Equals ("")) {
			
		} else {
			if (stVuotQua.Contains ("+")) {

				string[] mang = stVuotQua.Split ('+');
				for (int i = 0; i < mang.Length; i++) {
					lstVuotQua.Add (mang [i]);
				}


			} else {
				lstVuotQua.Add (stVuotQua);
			}
		}
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	void GetDaTa(string tmg)
	{
		string[] mang = tmg.Trim().Split('}');
		for (int i = 0; i < mang.Length-1; i++)
		{
			string[] items = mang[i].Split('^');
			Question qs = new Question (items[0],items[1],items[2],items[3],items[4],items[5],items[6],items[7],items[8],items[9],items[10],items[11]);
			lst.Add (qs);
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
