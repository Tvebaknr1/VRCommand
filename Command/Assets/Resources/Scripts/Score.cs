using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Score :NetworkBehaviour{

    [SyncVar(hook ="incScore")]
    int score = 0;

    public int incrPerMinute;
	
	public int getScore()
    {
        return (int) (score +  Time.realtimeSinceStartup *  incrPerMinute / 60);
    }
    public void incScore(int Score)
    {
        this.score += score;
    }
}
