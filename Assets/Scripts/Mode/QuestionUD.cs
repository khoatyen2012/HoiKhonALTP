using UnityEngine;
using System.Collections;

public class QuestionUD  {

	string id = "";
	string datetime="";
	string name="";
	string question="";
	string traloi="";
	string giaithich="";

	public QuestionUD(string id,string datetime,string name,string question,string traloi,string giaithich)
	{
		this.id = id;
		this.datetime = datetime;
		this.name = name;
		this.question = question;
		this.traloi = traloi;
		this.giaithich = giaithich;
	}
}
