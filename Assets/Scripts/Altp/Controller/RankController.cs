using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.SceneManagement;

public class RankController : MonoBehaviour {

	public GameObject ItemGD;
	public GameObject ListGD;
	public ScrollRect scroll;


	private string mymac = "";
	private int myCoin;
	private int mySecond;
	private int mytop;
	string url = "http://ailatrieuphu.somee.com/Service.asmx/gettop?sha=ai.la.trieu.phu.altp.tiengbuivanban";
	List<AltpUser> lst = new List<AltpUser>();
	public tk2dUIItem btnBack;
	public tk2dUIItem btnOK;
	public tk2dUIItem btnCancel;
	public GameObject wyn;
	public InputField iFName;
	private string sk;
	private string mynameShow = "";

	public tk2dTextMesh txtName;
	public tk2dTextMesh txtMyLevel;
	public tk2dTextMesh txtMyTop;
	private string hedieuhanh = "HA";

	void btnCancel_OnClick()
	{
		doHide ();
		StartCoroutine(WaitForRequest());
	}
	void btnOK_OnClick()
	{
		
		try
		{
			
			sk = "" + iFName.text;
			if (sk.Length > 40)
			{
				sk = sk.Substring(0, 39);
			}
			int i = sk.IndexOf(" ", 0);
			while (i >= 0 && i < sk.Length)
			{
				sk = sk.Replace(" ", "_");
				i = sk.IndexOf(" ", i);
			}

			if (!sk.Trim().Equals(""))
			{
				getSetData(sk);
			}
			doHide ();
			
		}catch(System.Exception)
		{
			
		}

	}

	public void getSetData(string Pmyname)
	{
		if (!Pmyname.Trim().Equals(""))
		{

			string check = "" + getPosive(mymac, "" + myCoin, "" + mySecond, Pmyname, "ai.la.trieu.phu.altp.tiengbuivanban");
			StartCoroutine(WaitForRequestPosive(check));
			DataManager.SaveName(Pmyname);
			txtName.text = Pmyname;
		}
		StartCoroutine(WaitForRequest());
	}
	IEnumerator WaitForRequestPosive(string checkhang)
	{
		WWW www = new WWW(checkhang);

		yield return www;
		// check for errors

		if (www.error == null)
		{



			string tmg = "" + www.text;

			mytop = int.Parse(tmg.Trim())+1;
			DataManager.SaveTop(mytop);




		}
		else
		{

			//txtMyTop.text = "Not Connected";

		}
		txtMyTop.text = "Top:" + mytop;

	}
	private string getPosive(string pMac, string pCoin,string pSecond, string pName, string sha)
	{
		string urls = "http://ailatrieuphu.somee.com/Service.asmx/updateMac?pMac=" + pMac + "&pCoin=" + pCoin + "&pSecond=" +pSecond+ "&pName=" + pName + "&sha=" + sha;
		return urls;
	}

	void doHide()
	{
		wyn.SetActive (false);
		iFName.gameObject.SetActive (false);
		scroll.gameObject.SetActive (true);
	}

	void btnBack_OnClick()
	{
		SceneManager.LoadScene("Altp");
	}


	// Use this for initialization
	void Start () {
		//for (int i = 0; i < 100; i++) {
			//GameObject item = (GameObject)Instantiate (ItemGD,ListGD.transform);
			//ItemGD.transform.GetChild (0).GetComponent<Text> ().text = "Top:"+i;
			//item.transform.localScale = new Vector3 (1,1,1);
		//}
		//scroll.verticalNormalizedPosition = 1;
		btnBack.OnClick+=btnBack_OnClick;
		btnOK.OnClick += btnOK_OnClick;
		btnCancel.OnClick += btnCancel_OnClick;

		#if UNITY_IPHONE
		hedieuhanh = "HO";
		#endif

		getInfoData ();

	}

	void getInfoData()
	{

		mynameShow = "" + DataManager.GetName();
		iFName.text = mynameShow;
		mymac = "" + DataManager.GetMac();
		mySecond = DataManager.GetHightSecondALTP();
		myCoin = DataManager.GetHightScoreALTP();
		mytop = DataManager.GetTop();


		if (mymac.Trim().Equals(""))
		{
			mymac = hedieuhanh+""+ GetUniqueIdentifier();
			DataManager.SaveMac("" + mymac);
		}
		txtMyLevel.text = "Câu:"+myCoin;
		txtName.text = mynameShow;
	}

	public static string GetUniqueIdentifier()
	{
		System.Guid uid = System.Guid.NewGuid();
		return uid.ToString();
	}


	void doLoadData()
	{
		for (int i = 1; i < lst.Count; ++i) {
			GameObject item = (GameObject)Instantiate (ItemGD,ListGD.transform);
			ItemGD.transform.GetChild (0).GetComponent<Text> ().text = "Top:"+(i+1);
			string tmgName = lst [i].Name;
			if (tmgName.Length > 19) {
				tmgName = tmgName.Substring (0, 18);
			}
			ItemGD.transform.GetChild (1).GetComponent<Text> ().text = ""+tmgName;
			ItemGD.transform.GetChild (2).GetComponent<Text> ().text = "Câu "+lst [i].Coin+"-"+lst[i].Second+"'";
			item.transform.localScale = new Vector3 (1,1,1);
		}

		GameObject itemO = (GameObject)Instantiate (ItemGD,ListGD.transform);
		ItemGD.transform.GetChild (0).GetComponent<Text> ().text = "Top:1";
		string tmgNameO = lst [0].Name;
		if (tmgNameO.Length > 19) {
			tmgNameO = tmgNameO.Substring (0, 18);
		}
		ItemGD.transform.GetChild (1).GetComponent<Text> ().text = ""+tmgNameO;
		ItemGD.transform.GetChild (2).GetComponent<Text> ().text = "Câu "+lst [0].Coin+"-"+lst[0].Second+"'";
		itemO.transform.localScale = new Vector3 (1,1,1);

		scroll.verticalNormalizedPosition = 1;
	}


	IEnumerator WaitForRequest()
	{
		WWW www = new WWW(url);

		yield return www;
		// check for errors

		if (www.error == null)
		{
			ParseAccessData(www.text);
		}
		else
		{
			
		}

	}

	void ParseAccessData(string wtxt)
	{

		try
		{


			JsonData data = JsonMapper.ToObject(wtxt);

			for (int i = 0; i < data.Count; i++)
			{
				if (int.Parse("" + data[i]["Coin"]) > 500)
				{
					continue;
				}
				AltpUser cb = new AltpUser();
				cb.Stt = "" + (i + 1);
				cb.Name = "" + data[i]["Name"];



				cb.Coin = "" + data[i]["Coin"];
				cb.Second = "" + data[i]["Second"];

				lst.Add(cb);
			}
		
			doLoadData();
		}
		catch
		{

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
