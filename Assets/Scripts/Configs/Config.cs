﻿using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
	public static string appId = "ca-app-pub-2127327600096597~6853376404";
	public static string adsID = "ca-app-pub-2127327600096597/4624946117";
	public static string adsInID = "ca-app-pub-2127327600096597/8256945657";

	public static string adsIdBanerAL = "ca-app-pub-2127327600096597/4947762783";
	public static string adsInIdAL = "ca-app-pub-2127327600096597/4839951570";

#endif

#if UNITY_ANDROID

    public static string appId = "ca-app-pub-2577061470072962~3751790098";
    public static string adsID = "ca-app-pub-2577061470072962/8897317322";
    public static string adsInID = "ca-app-pub-2577061470072962/7734556697";

    public static string adsIdBanerAL = "ca-app-pub-2577061470072962/9815633005";
    public static string adsInIdAL = "ca-app-pub-2577061470072962/9380518730";


#endif

}
