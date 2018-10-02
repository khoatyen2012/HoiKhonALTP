using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public tk2dUIItem btnContinute;

    public tk2dTextMesh txtCauHoi;
    public tk2dTextMesh txtDapAn;
    public tk2dTextMesh txtDiemSo;
    public tk2dTextMesh txtDiemCao;

	public tk2dSprite avatar;
    public tk2dTextMesh txtTitle;



	public void doRandonSprite()
	{
		int chon = UnityEngine.Random.Range (0, 25);
		switch (chon) {
		case 1:
			avatar.SetSprite ("e_1");
            txtTitle.text = "Gà VL";
			break;
		case 2:
			avatar.SetSprite ("e_2");
            txtTitle.text = "Gà Vậy";
			break;
		case 3:
			avatar.SetSprite ("e_3");
            txtTitle.text = "Ngu VL";
			break;
		case 4:
			avatar.SetSprite ("e_4");
            txtTitle.text = "Óc ckó";
			break;
		case 5:
			avatar.SetSprite ("e_5");
            txtTitle.text = "Cay Cú";
			break;
		case 6:
			avatar.SetSprite ("e_6");
            txtTitle.text = "Có cố gắng";
			break;
		case 7:
			avatar.SetSprite ("e_7");
            txtTitle.text = "Định mệnh";
			break;
		case 8:
			avatar.SetSprite ("e_8");
            txtTitle.text = "Bực mình";
			break;
		case 9:
			avatar.SetSprite ("e_9");
            txtTitle.text = "Hỏi ngu";
			break;
		case 10:
			avatar.SetSprite ("e_10");
            txtTitle.text = "Trẻ trâu";
			break;
		case 11:
			avatar.SetSprite ("e_11");
            txtTitle.text = "Tha Thu";
			break;
		case 12:
			avatar.SetSprite ("e_12");
			txtTitle.text = "Thánh Ngu";
			break;
		case 13:
			avatar.SetSprite ("e_13");
			txtTitle.text = "Ngu Bẩm Sinh";
			break;
		case 14:
			avatar.SetSprite ("e_14");
			break;
		case 15:
			avatar.SetSprite ("e_15");
			break;
		case 16:
			avatar.SetSprite ("e_16");
			break;
		case 17:
			avatar.SetSprite ("e_17");
			break;
		case 18:
			avatar.SetSprite ("e_18");
			break;
		case 19:
			avatar.SetSprite ("e_19");
			break;
		case 20:
			avatar.SetSprite ("duongtang1");
			break;
		case 21:
			avatar.SetSprite ("duongtang2");
			break;
		default:
			avatar.SetSprite ("duongtang3");
			break;
		}
	}

    public void setData(string pQue,string pDa,int pMax)
    {
        txtCauHoi.text = pQue;
        txtDapAn.text = "Đáp án:"+pDa;
        txtDiemSo.text = "Điểm số:"+GameController.instance.mScore;
        txtDiemCao.text = "Điểm cao nhất:" + pMax;
		doRandonSprite ();
        if (GameController.instance.mScore % 2 == 0)
        {
            AdmobManger.Instance.LoadAdsInterstitial();
        }
    }

	public void btnContinute_OnClick()
	{
		try
		{
        if (GameController.instance.mScore % 2 == 0)
        {
            AdmobManger.Instance.ShowAdsInterstitial();
        }

        SoundManager.Instance.PlayAudioCick();
		GameController.instance.doReset ();
		PopUpController.instance.HideGameOver ();
		PopUpController.instance.ShowMainGame ();
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
