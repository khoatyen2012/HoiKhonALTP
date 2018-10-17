using UnityEngine;
using System.Collections;

public class DataManager  {

    private static string TAG_HIGHT = "ssf";

    //get lai gia tri second cua bai 3 khi con thong thai.

	private static string TAG_VUOTQUA = "vuotqua";

	private static string TAG_HIGHT_ALTP = "altp";
	private static string TAG_SECOND_ALTP = "second";
	private static string TAG_NAME = "myname";
	private static string TAG_MAC = "mymac";
	private static string TAG_TOP = "mytop";


	public static string GetMac()
	{
		if (PlayerPrefs.HasKey(TAG_MAC))
		{
			return PlayerPrefs.GetString(TAG_MAC);
		}
		else
		{
			return "";
		}
	}

	public static void SaveMac(string newHightScore)
	{
		PlayerPrefs.SetString(TAG_MAC, newHightScore);
	}

	public static int GetTop()
	{
		if (PlayerPrefs.HasKey(TAG_TOP))
		{
			return PlayerPrefs.GetInt(TAG_TOP);
		}
		else
		{
			return 112110;
		}
	}

	public static void SaveTop(int newHightScore)
	{
		PlayerPrefs.SetInt(TAG_TOP, newHightScore);
	}



	public static string GetName()
	{
		if (PlayerPrefs.HasKey(TAG_NAME))
		{
			return PlayerPrefs.GetString(TAG_NAME);
		}
		else
		{
			return "";
		}
	}

	public static void SaveName(string newHightScore)
	{
		PlayerPrefs.SetString(TAG_NAME, newHightScore);
	}

	public static int GetHightSecondALTP()
	{
		if (PlayerPrefs.HasKey(TAG_SECOND_ALTP))
		{
			return PlayerPrefs.GetInt(TAG_SECOND_ALTP);
		}
		else
		{
			return 0;
		}
	}

	//Luu lai gia tri second cua bai 3 khi con thong thai.
	public static void SaveHightSecondALTP(int newHightScore)
	{
		PlayerPrefs.SetInt(TAG_SECOND_ALTP, newHightScore);
	}

	//-----------------------------------
	public static int GetHightScoreALTP()
	{
		if (PlayerPrefs.HasKey(TAG_HIGHT_ALTP))
		{
			return PlayerPrefs.GetInt(TAG_HIGHT_ALTP);
		}
		else
		{
			return 0;
		}
	}

	//Luu lai gia tri second cua bai 3 khi con thong thai.
	public static void SaveHightScoreALTP(int newHightScore)
	{
		PlayerPrefs.SetInt(TAG_HIGHT_ALTP, newHightScore);
	}
	//-----------------------------------

	public static string GetVuotQua()
	{
		if (PlayerPrefs.HasKey(TAG_VUOTQUA))
		{
			return PlayerPrefs.GetString(TAG_VUOTQUA);
		}
		else
		{
			return "";
		}
	}

	public static void SaveVuotQua(string newHightScore)
	{
		PlayerPrefs.SetString(TAG_VUOTQUA, newHightScore);
	}

    public static int GetHightScore()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHT))
        {
            return PlayerPrefs.GetInt(TAG_HIGHT);
        }
        else
        {
            return 0;
        }
    }

    //Luu lai gia tri second cua bai 3 khi con thong thai.
    public static void SaveHightScore(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHT, newHightScore);
    }
}
