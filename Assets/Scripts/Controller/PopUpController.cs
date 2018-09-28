using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour {

    #region Singleton
    private static PopUpController _instance;

    public static PopUpController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PopUpController>();
            return _instance;
        }
    }
    #endregion

    public float showY;
    public float hideY;

    public MainGame maingame;
    public InGame inGame;
    public NextGame nextGame;
    public GameOver gameOver;
	public HetLuot hetluot;

   

	public void ShowHetLuot()
	{
		
		hetluot.transform.position = new Vector3(hetluot.transform.position.x, showY, hetluot.transform.position.z);
	}

	public void HideHetLuot()
	{
		hetluot.transform.position = new Vector3(hetluot.transform.position.x, hideY, hetluot.transform.position.z);
	}


    public void ShowGameOver(string pQue, string pDa, int pMax)
    {
        gameOver.setData(pQue, pDa, pMax);
        gameOver.transform.position = new Vector3(gameOver.transform.position.x, showY, gameOver.transform.position.z);
    }

    public void HideGameOver()
    {
        gameOver.transform.position = new Vector3(gameOver.transform.position.x, hideY, gameOver.transform.position.z);
    }



	public void ShowNextGame(string pGT,bool ok)
    {
		nextGame.setData (pGT,ok);
        nextGame.transform.position = new Vector3(nextGame.transform.position.x, showY, nextGame.transform.position.z);
    }

    public void HideNextGame()
    {
        nextGame.transform.position = new Vector3(nextGame.transform.position.x, hideY, nextGame.transform.position.z);
    }


    public void ShowInGame()
    {
		inGame.setData ();
        inGame.transform.position = new Vector3(inGame.transform.position.x, showY, inGame.transform.position.z);
    }

    public void HideInGame()
    {
        inGame.transform.position = new Vector3(inGame.transform.position.x, hideY, inGame.transform.position.z);
    }


    public void ShowMainGame()
    {
		maingame.setData ();
        maingame.transform.position = new Vector3(maingame.transform.position.x, showY, maingame.transform.position.z);
    }

    public void HideMainGame()
    {
        maingame.transform.position = new Vector3(maingame.transform.position.x, hideY, maingame.transform.position.z);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
