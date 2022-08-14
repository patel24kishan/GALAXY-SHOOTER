using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Sprite[] lives; 
	public Image LivesImage;
	public Text ScoreText;

	public GameObject titleScreen;

	public int Score=0;

	public void UpdateLives(int currentLives)
	{
		LivesImage.sprite = lives [currentLives];
	}

	public void UpdateScore()
	{
		Score += 10;

		ScoreText.text = "Score:" + Score;
	}

	public void ShowTitlescreen()
	{
		titleScreen.SetActive (true);
	}

	public void HideTitleScreen()
	{
		titleScreen.SetActive (false);
		ScoreText.text = "Score:";
	}
}
