using UnityEngine;
using System.Collections;

public class NextGame : MonoBehaviour {


	public tk2dUIItem btnHoiTiep;
    public tk2dUIItem btnBalo;

	public tk2dTextMesh txtGiaiThich;
	public tk2dSprite Avatar;
    public tk2dTextMesh txtTitle;

	public void doRandonSprite()
	{
		int chon = UnityEngine.Random.Range (0, 20);
		switch (chon) {
		case 1:
			Avatar.SetSprite ("e_1");
            txtTitle.text = "Lầy Lội";
			break;
		case 2:
			Avatar.SetSprite ("e_2");
            txtTitle.text = "Thường Thôi";
			break;
		case 3:
			Avatar.SetSprite ("e_3");
            txtTitle.text = "Bá Đạo";
			break;
		case 4:
			Avatar.SetSprite ("e_4");
            txtTitle.text = "Chuẩn CMNR !";
			break;
		case 5:
			Avatar.SetSprite ("e_5");
            txtTitle.text = "Khôn VL";
			break;
		case 6:
			Avatar.SetSprite ("e_6");
            txtTitle.text = "Ngon Zaj Đấy";
			break;
		case 7:
			Avatar.SetSprite ("e_7");
            txtTitle.text = "Được Lắm";
			break;
		case 8:
			Avatar.SetSprite ("e_8");
            txtTitle.text = "Khôn Như Cờ ho'";
			break;
		case 9:
			Avatar.SetSprite ("e_9");
            txtTitle.text = "Đẹp zaj'";
			break;
		case 10:
			Avatar.SetSprite ("e_10");
			break;
		case 11:
			Avatar.SetSprite ("e_11");
			break;
		case 12:
			Avatar.SetSprite ("e_12");
			break;
		case 13:
			Avatar.SetSprite ("e_13");
			break;
		case 14:
			Avatar.SetSprite ("e_14");
			break;
		case 15:
			Avatar.SetSprite ("e_15");
			break;
		case 16:
			Avatar.SetSprite ("e_16");
			break;
		case 17:
			Avatar.SetSprite ("e_17");
			break;
		case 18:
			Avatar.SetSprite ("e_18");
			break;
		case 19:
			Avatar.SetSprite ("e_19");
			break;
		default:
			Avatar.SetSprite ("e_19");
			break;
		}
	}

	public void setData(string pGT,bool ok)
	{
		txtGiaiThich.text = "" + pGT;
		if (ok) {
			Avatar.SetSprite ("e_9");
		} else {
			doRandonSprite ();
		}

        AdmobManger.Instance.RequestBanner();
        AdmobManger.Instance.ShowBanner();
	}



	public void btnHoiTiep_OnClick()
	{
		try
		{
        SoundManager.Instance.PlayAudioCick();
		PopUpController.instance.HideNextGame ();
		PopUpController.instance.ShowInGame ();

        AdmobManger.Instance.HidewBanner();
		}
		catch (System.Exception)
		{

			throw;
		}
	}

    public void btnBalo_OnClick()
    {
		try
		{
        ShareRate.RateBalo();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	// Use this for initialization
	void Start () {
		btnHoiTiep.OnClick += btnHoiTiep_OnClick;
        btnBalo.OnClick += btnBalo_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
