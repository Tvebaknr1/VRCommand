using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand_Text_maneger : MonoBehaviour {
    private int magSize;
    private int currentMagSize;
    private string gunName;
    public Text TextField;
    private int score;
	// Use this for initialization
	void Awake() {
        TextField = GetComponent<Text>();
        setText();
	}
    public void setMagSize(int i)
    {
        magSize = i;
        setText();
    }
    public void setCurrentMagSize(int i)
    {
        currentMagSize = i;
        setText();
    }
    public void setNewGun(int magSize,int currentMagSize,string gunName)
    {
        this.magSize = magSize;
        this.currentMagSize = currentMagSize;
        this.gunName = gunName;
        if(TextField ==null)
            TextField = GetComponent<Text>();
        setText();
    }
    public void setScore(int i)
    {
        score += i;
        setText();
    }
    private void setText()
    {
        Debug.Log(magSize);
        Debug.Log(currentMagSize);
        Debug.Log(gunName);
        Debug.Log(score);
        TextField.text = "Bullets:" + currentMagSize + "/" + magSize + "\n" +
                "Gun:" + gunName + " \n" +
                "score: " + score;
    }
}
