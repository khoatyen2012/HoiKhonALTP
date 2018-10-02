using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TuVan : MonoBehaviour {

	public tk2dTextMesh txt1;
	public tk2dTextMesh txt2;
	public tk2dTextMesh txt3;
	public tk2dUIItem btnContinute;
	List<int> tmgList;


	public void btnContinute_OnClick()
	{
		try
		{
		AlGameController.instance.currentState = AlGameController.State.Question;
		AlPopupController.instance.HidePopupTuVan();
		DapAnController.instance.doSetEnabal(true);
		}
		catch (System.Exception)
		{

			throw;
		}
	}


	public void setData()
	{
		try
		{
		int k = AlGameController.instance.truecase;
		int lv = AlGameController.instance.level;
		 tmgList = new List<int>();
		tmgList.Clear ();

		int chon = Random.Range(0, 20 - lv);
		if (chon == 0) {
			for (int i = 1; i <= 4; i++) {
				tmgList.Add(i);
			}
		} else {
			
			tmgList.Add (k);
			tmgList.Add (k);

			if (chon % 5 == 0) {
				tmgList.Add (1);
			} else if (chon % 4 == 0) {
				tmgList.Add (2);
			} else if (chon % 3 == 0) {
				tmgList.Add (3);
			} else {
				tmgList.Add (4);
			}
		}

		int chonLai = UnityEngine.Random.Range(0, tmgList.Count-1);
		tmgList.Remove(chonLai);
		setTxt (txt1, tmgList [chonLai]);

		chonLai = UnityEngine.Random.Range(0, tmgList.Count-1);
		tmgList.Remove(chonLai);
		setTxt (txt2, tmgList [chonLai]);

		chonLai = UnityEngine.Random.Range(0, tmgList.Count-1);
	
		setTxt (txt3, tmgList [chonLai]);
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	public void setTxt(tk2dTextMesh txtTMG,int pTMG)
	{
		if (pTMG == 1) {
			txtTMG.text = "A";
		} else if (pTMG == 2) {
			txtTMG.text = "B";
		} else if (pTMG == 3) {
			txtTMG.text = "C";
		} else {
			txtTMG.text = "D";
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
