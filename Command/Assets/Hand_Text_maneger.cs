using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand_Text_maneger : MonoBehaviour {
    private int magSize;
    private int currentMagSize;
    private string gunName;
    private Text text;
    private int score;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        setText();
	}
    public void setMagSize(int i)
    {
        magSize = i;
    }
    public void setCurrentMagSize(int i)
    {
        currentMagSize = i;
    }
    public void setNewGun(int magSize,int currentMagSize,string gunName)
    {
        this.magSize = magSize;
        this.currentMagSize = currentMagSize;
        this.gunName = gunName;
    }
    public void setScore(int i)
    {
        score += i;
    }
    private void setText()
    {
        text.text = "Bullets:" + magSize + "/" + currentMagSize + "\n" +
                "Gun:" + gunName + " \n" +
                "score: " + score;
    }
}
