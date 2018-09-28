using UnityEngine;
using System.Collections;

public class Question  {

	string id="";

	public string Id {
		get {
			return id;
		}
	}

	string question="";

	public string Question2 {
		get {
			return question;
		}
	}

	string da="";

	public string Da {
		get {
			return da;
		}
	}

	string db="";

	public string Db {
		get {
			return db;
		}
	}

	string dc="";

	public string Dc {
		get {
			return dc;
		}
	}

	string dd="";

	public string Dd {
		get {
			return dd;
		}
	}

	string truecase="";

	public string Truecase {
		get {
			return truecase;
		}
	}

	string gta="";

	public string Gta {
		get {
			return gta;
		}
	}

	string gtb="";

	public string Gtb {
		get {
			return gtb;
		}
	}

	string gtc="";

	public string Gtc {
		get {
			return gtc;
		}
	}

	string gtd="";

	public string Gtd {
		get {
			return gtd;
		}
	}

	string nickname="";

	public string Nickname {
		get {
			return nickname;
		}
	}

	public Question(string id,string question,string da,string db,string dc,string dd,string truecase,string gta,string gtb,string gtc,string gtd,string nickname)
	{
		this.id = id;
		this.question = question;
		this.da = da;
		this.db = db;
		this.dc = dc;
		this.dd = dd;
		this.truecase = truecase;
		this.gta = gta;
		this.gtb = gtb;
		this.gtc = gtc;
		this.gtd = gtd;
		this.nickname = nickname;
	}

}
