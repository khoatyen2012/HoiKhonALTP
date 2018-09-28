using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGame : MonoBehaviour {



	public tk2dTextMesh txtQuestion;
	public tk2dTextMesh txtDa;
	public tk2dTextMesh txtDb;
	public tk2dTextMesh txtDc;
	public tk2dTextMesh txtDd;
	public tk2dTextMesh txtNickGame;
	public tk2dTextMesh txtLuotNgu;
	public tk2dTextMesh txtScore;

	public tk2dUIItem btnA;
	public tk2dUIItem btnB;
	public tk2dUIItem btnC;
	public tk2dUIItem btnD;
	public tk2dUIItem btnAvatar;
	public GameObject mesage;

	 Question quTMG;
	public string checkque;
    public string checkA;
    public string checkB;
    public string checkC;
    public string checkD;


	string selectcase="";

	List<Question> lst=new List<Question>();
    int chonk = 0;
    public int mScoreMax;
 


	public void btnA_OnClick()
	{
		try
		{
		if (GameController.instance.currentState == GameController.State.Question) {
			selectcase = "a";
			doXuLy ();
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnB_OnClick()
	{
		try
		{
		if (GameController.instance.currentState == GameController.State.Question) {
			selectcase = "b";
			doXuLy ();
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnC_OnClick()
	{
		try
		{
		if (GameController.instance.currentState == GameController.State.Question) {
			selectcase = "c";
			doXuLy ();
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnD_OnClick()
	{
		try
		{
		if (GameController.instance.currentState == GameController.State.Question) {
			selectcase = "d";
			doXuLy ();
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}


	void doXuLy()
	{

		if (selectcase.Equals (quTMG.Truecase)) {
            SoundManager.Instance.PlayAudioWin();
			GameController.instance.mScore++;
			txtScore.text = "" + GameController.instance.mScore;
			GameController.instance.currentState = GameController.State.ReplyTrue;
            StartCoroutine(WaitTimeDung(1f));
		} else {
			
			GameController.instance.currentState = GameController.State.ReplyFalse;
            SoundManager.Instance.PlayAudioOver();
			mesage.SetActive (true);
			GameController.instance.mNgu--;
			txtLuotNgu.text = "Lượt Ngu:" + GameController.instance.mNgu;
            chonk = UnityEngine.Random.Range(0, 5);
            switch (selectcase)
            {
                case "a":
                    if (quTMG.Gta.Trim().Equals(""))
                    {
                        if (chonk == 0)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vkl :))";
                        }
                        else if (chonk == 1)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vđ @@";
                        }
                        else
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Óc chó có thật :))";
                        }
                    }
                    else
                    {
                        mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = quTMG.Gta;
                    }
                    break;
                case "b":
                    if (quTMG.Gtb.Trim().Equals(""))
                    {
                        if (chonk == 0)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vkl :))";
                        }
                        else if (chonk == 1)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vđ @@";
                        }
                        else
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Óc chó có thật :))";
                        }
                    }
                    else
                    {
                        mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = quTMG.Gtb;
                    }
                    break;
                case "c":
                    if (quTMG.Gtc.Trim().Equals(""))
                    {
                        if (chonk == 0)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vkl :))";
                        }
                        else if (chonk == 1)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vđ @@";
                        }
                        else
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Óc chó có thật :))";
                        }
                    }
                    else
                    {
                        mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = quTMG.Gtc;
                    }
                    break;

                default:
                    if (quTMG.Gtd.Trim().Equals(""))
                    {
                        if (chonk == 0)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vkl :))";
                        }
                        else if (chonk == 1)
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Thím ngu vđ @@";
                        }
                        else
                        {
                            mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = "Óc chó có thật :))";
                        }
                    }
                    else
                    {
                        mesage.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = quTMG.Gtd;
                    }
                    break;
            }
			StartCoroutine(WaitTimeSai(2f));
		}
	}

	IEnumerator WaitTimeSai(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);
		mesage.SetActive (false);
		if (GameController.instance.mNgu <= 0) {
			GameController.instance.currentState = GameController.State.GameOver;
            CameraDrop.Instance.shakeDuration = 2f;
			PopUpController.instance.HideInGame ();
            SoundManager.Instance.PlayAudioGameOver();

            if (GameController.instance.mScore > mScoreMax)
            {
                mScoreMax = GameController.instance.mScore;
                DataManager.SaveHightScore(mScoreMax);
            }
            
            switch(quTMG.Truecase)
            {
                case "a":
                    PopUpController.instance.ShowGameOver(quTMG.Question2, quTMG.Da, mScoreMax);
                    break;
                case "b":
                    PopUpController.instance.ShowGameOver(quTMG.Question2, quTMG.Db, mScoreMax);
                    break;
                case "c":
                    PopUpController.instance.ShowGameOver(quTMG.Question2, quTMG.Dc, mScoreMax);
                    break;
                default:
                    PopUpController.instance.ShowGameOver(quTMG.Question2, quTMG.Dd, mScoreMax);
                    break;
            }


            //Luu lai cac id da vuot qua
            if (GameController.instance.lstVuotQua.Count > 0)
            {
                string tamtr = "";
                for (int i = 0; i < GameController.instance.lstVuotQua.Count; i++)
                {
                    if (i == 0)
                    {
                        tamtr += "" + GameController.instance.lstVuotQua[0];
                    }
                    else
                    {
                        tamtr += "+" + GameController.instance.lstVuotQua[i];
                    }
                }
                DataManager.SaveVuotQua(tamtr);
            }
			

		} else {
			GameController.instance.currentState = GameController.State.Question;
           
		}

	}

    IEnumerator WaitTimeDung(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        GameController.instance.currentState = GameController.State.Next;
        PopUpController.instance.HideInGame();
       
		switch(quTMG.Truecase)
		{
		case "a":
			PopUpController.instance.ShowNextGame(quTMG.Gta,false);
			break;
		case "b":
			PopUpController.instance.ShowNextGame(quTMG.Gtb,false);
			break;
		case "c":
			PopUpController.instance.ShowNextGame(quTMG.Gtc,false);
			break;
		default:
			PopUpController.instance.ShowNextGame(quTMG.Gtd,false);
			break;
		}

        //Them id da vuot qua vao danh sach
        GameController.instance.lstVuotQua.Add(quTMG.Id);


        
    
    }

	public void btnAvatar_OnClick()
	{
		try
		{
		if (GameController.instance.currentState == GameController.State.Question) {

            SoundManager.Instance.PlayAudioGameOanh();

			GameController.instance.mNext--;
			if (GameController.instance.mNext == 0) {
				GameController.instance.currentState = GameController.State.Next;
				PopUpController.instance.HideInGame ();
				PopUpController.instance.ShowNextGame("Em xin thua,thật là dã man mà, đành phải cho bác qua câu này vậy. A hi hi đồ ckó",true);

			} else if (GameController.instance.mNext < 0 && GameController.instance.mNext%3==0) {

				GameController.instance.currentState = GameController.State.HetLuot;
				PopUpController.instance.ShowHetLuot ();
				PopUpController.instance.HideInGame ();
			
			}
		}
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void setData()
	{
		GameController.instance.currentState = GameController.State.Question;
		if (lst.Count <= 0) {
	
            for (int i = 0; i < GameController.instance.lstVuotQua.Count; i++)
            {
                for (int k = 0; k < GameController.instance.lst.Count; k++)
                {
                    if (GameController.instance.lstVuotQua[i].Equals(GameController.instance.lst[k].Id))
                    {
                        continue;
                    }

                    lst.Add(GameController.instance.lst[k]);

                }
            }

            if (lst.Count <= 0)
            {
                lst = GameController.instance.lst;
                DataManager.SaveVuotQua("");
                GameController.instance.lstVuotQua.Clear();
                GameController.instance.lstVuotQua = new List<string>();
				Debug.Log ("Deo có");
            }
		}

		doSubGet ();
	}

	public void doSubGet()
	{
        if (lst.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, lst.Count);
            quTMG = lst[chon];
            txtQuestion.text = quTMG.Question2;
            txtDa.text = quTMG.Da;
            txtDb.text = quTMG.Db;
            txtDc.text = quTMG.Dc;
            txtDd.text = quTMG.Dd;
            txtNickGame.text = "Nick Name:" + quTMG.Nickname;
            checkque = quTMG.Truecase;

            checkA = quTMG.Gta;
            checkB = quTMG.Gtb;
            checkC = quTMG.Gtc;
            checkD = quTMG.Gtd;
            lst.RemoveAt(chon);

        }
        

		txtLuotNgu.text = "Lượt Ngu:" + GameController.instance.mNgu;
		txtScore.text = "" + GameController.instance.mScore;
		doRandonSprite ();
	}

	public void doRandonSprite()
	{
		int chon = UnityEngine.Random.Range (0, 25);
		switch (chon) {
		case 1:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_1");
			break;
		case 2:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_2");
			break;
		case 3:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_3");
			break;
		case 4:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_4");
			break;
		case 5:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_5");
			break;
		case 6:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_6");
			break;
		case 7:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_7");
			break;
		case 8:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_8");
			break;
		case 9:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_9");
			break;
		case 10:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_10");
			break;
		case 11:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_11");
			break;
		case 12:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_12");
			break;
		case 13:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_13");
			break;
		case 14:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_14");
			break;
		case 15:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_15");
			break;
		case 16:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_16");
			break;
		case 17:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_17");
			break;
		case 18:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_18");
			break;
		case 19:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("e_19");
			break;
		case 20:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("duongtang1");
			break;
		case 21:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("duongtang2");
			break;	
		default:
			btnAvatar.GetComponent<tk2dSprite>().SetSprite ("duongtang3");
			break;
		}
	}


	// Use this for initialization
	void Start () {
	
		try
		{
		btnA.OnClick += btnA_OnClick;
		btnB.OnClick += btnB_OnClick;
		btnC.OnClick += btnC_OnClick;
		btnD.OnClick += btnD_OnClick;
		btnAvatar.OnClick += btnAvatar_OnClick;
        mScoreMax = DataManager.GetHightScore();
		}
		catch (System.Exception)
		{

			throw;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
