using UnityEngine;
using System.Collections;

public class DataManager  {

    private static string TAG_HIGHT = "ssf";

    //get lai gia tri second cua bai 3 khi con thong thai.

	private static string TAG_VUOTQUA = "vuotqua";

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
