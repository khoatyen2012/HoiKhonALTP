using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
	public static string appId = "ca-app-pub-2127327600096597~6853376404";
	public static string adsID = "ca-app-pub-2127327600096597/4624946117";
	public static string adsInID = "ca-app-pub-2127327600096597/8256945657";


#endif

#if UNITY_ANDROID

    public static string appId = "ca-app-pub-2577061470072962~3751790098";
    public static string adsID = "ca-app-pub-2577061470072962/8897317322";
    public static string adsInID = "ca-app-pub-2577061470072962/7734556697";


#endif

}
