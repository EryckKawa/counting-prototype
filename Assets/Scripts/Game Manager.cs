using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI levelText;
	[SerializeField] TextMeshProUGUI livesText;
	[SerializeField] Slider progressBar;
	[SerializeField] GameObject gameOverScreen;
	[SerializeField] PlayerController player;
	[SerializeField] SpawnGems spawnGems;
	bool isGameActive;
	private int level;
	private int score;
	private int lives = 3; 
	private float multiplyRepeatRate = 0.5f;

	void Start()
	{
		progressBar.value = 0;
		level = 1;
		SetLevel(level);
		UpdateLivesText();
	}
	
	public void AddScore(int amount)
	{
		score += amount;
		progressBar.value = score;
		if (score >= progressBar.maxValue)
		{
			level++;
			score = 0;  
			progressBar.value = 0;  
			IncreaseProgressBar();  
			SetLevel(level);
			spawnGems.SetRepeatRate(spawnGems.GetRepeatRate() * multiplyRepeatRate);
		}
	}

	public void LoseLife()
	{
		lives--;
		UpdateLivesText();
		if (lives <= 0)
		{
			GameOver();
		}
	}

	public void SetLevel(int newLevel)
	{
		level = newLevel;
		UpdateLevelText();
	}
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	private void UpdateLevelText()
	{
		levelText.text = "Level: " + level.ToString();
	}

	private void UpdateLivesText()
	{
		livesText.text = "Lives: " + lives.ToString();
	}

	private void IncreaseProgressBar()
	{
		progressBar.maxValue *= 2;
	}
	
	private void GameOver()
	{
		gameOverScreen.SetActive(true);
		Time.timeScale = 0;
	}
	
}
