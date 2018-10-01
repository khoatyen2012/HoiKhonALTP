using UnityEngine;
using System.Collections;

public class AlPopupController : MonoBehaviour {

	#region Singleton
	private static AlPopupController _instance;

	public static AlPopupController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<AlPopupController>();
			return _instance;
		}
	}
	#endregion

	public float moveSpeed;
	public float showPositionY;
	public float hidePostionY;
	public GameObject sha;
	public AlMainGame mainGame;
	public Win15 iwin;
	public AlGameOver gameOver;
	public KhanGia khangia;
	public NguoiThan nguoithan;

	public void ShowPopUpNguoiThan()
	{
		nguoithan.transform.position = new Vector3(nguoithan.transform.position.x, showPositionY, 60f);
	}

	public void HidePopupNguoiThan()
	{
		StartCoroutine(ieMoveUp(nguoithan.gameObject));

	}



	public void HidePopupKhanGia()
	{
		StartCoroutine(ieMoveUp(khangia.gameObject));

	}

	public void ShowPopupKhanGia()
	{
		khangia.setPhanTram();
		khangia.transform.position = new Vector3(khangia.transform.position.x, showPositionY, 60f);
	}

	public void HidePopupGameOver()
	{
		StartCoroutine(ieMoveUp(gameOver.gameObject));

	}

	public void ShowPopupGameOver(int level,int maxlevel)
	{
		gameOver.setlevel(level, maxlevel);
		StartCoroutine(ieMoveDown(gameOver.gameObject));
		HidePopupKhanGia();
		HidePopupNguoiThan();
		nguoithan.resetNguoiThan();

	}

	public void ShowPopUpWin()
	{
		iwin.transform.position = new Vector3(iwin.transform.position.x, showPositionY, 10f);
	}

	public void HidePopUpWin()
	{
		iwin.transform.position = new Vector3(iwin.transform.position.x, hidePostionY, 10f);
	}


	public void ShowMainGame()
	{
		StartCoroutine(ieMoveDown(mainGame.gameObject));
	}

	public void HideMainGame()
	{
		StartCoroutine(ieMoveUp(mainGame.gameObject));
	}

	public void ShowSHA()
	{
		StartCoroutine(ieMoveLeft(sha));
	}


	public void HideSHA()
	{
		StartCoroutine(ieMoveRight(sha));
	}



	IEnumerator ieMoveDown(GameObject popup)
	{
		while (popup.transform.position.y > showPositionY)
		{
			popup.transform.position += Vector3.down
				* (moveSpeed+300)
				* Time.deltaTime;
			yield return 0;
		}
		popup.transform.position = new Vector3(popup.gameObject.transform.position.x, showPositionY, popup.gameObject.transform.position.z);

	}

	IEnumerator ieMoveUp(GameObject popup)
	{
		while (popup.transform.position.y < hidePostionY)
		{
			popup.transform.position += Vector3.up
				* (moveSpeed + 300)
				* Time.deltaTime;
			yield return 0;
		}
		popup.transform.position = new Vector3(popup.gameObject.transform.position.x, hidePostionY, popup.gameObject.transform.position.z);

	}

	IEnumerator ieMoveLeft(GameObject popup)
	{
		while (popup.transform.position.x > 0f)
		{
			popup.transform.position += Vector3.left
				* (moveSpeed+200)
				* Time.deltaTime;
			yield return 0;
		}

	}

	IEnumerator ieMoveRight(GameObject popup)
	{
		while (popup.transform.position.x < 1500f)
		{
			popup.transform.position += Vector3.right
				* (moveSpeed + 200)
				* Time.deltaTime;
			yield return 0;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
