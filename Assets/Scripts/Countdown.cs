using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Countdown : MonoBehaviour
{
	public float timer;
	public TextMeshProUGUI textBox;
	public bool death = false;
	public float timeBoost;
	public int hourglassNumber;
	public float startTimer;

	public int hourglass1;
	public int hourglass2;
	public int hourglass3;
	public int hourglass4;
	public int hourglass5;
	public int hourglass6;
	public int hourglass7;
	public int hourglass8;
	public int hourglass9;
	public int hourglass10;

	public GameObject hourglass1Object;
	public GameObject hourglass2Object;
	public GameObject hourglass3Object;
	public GameObject hourglass4Object;
	public GameObject hourglass5Object;
	public GameObject hourglass6Object;
	public GameObject hourglass7Object;
	public GameObject hourglass8Object;
	public GameObject hourglass9Object;
	public GameObject hourglass10Object;

	public bool canIncrease;

	void Start()
	{

		FindObjectOfType<AudioManager>().Play("BackgroundMusic");

		textBox.text = timer.ToString();
		startTimer = PlayerPrefs.GetFloat("Timer", 10);
		timer = startTimer;

		hourglassNumber = PlayerPrefs.GetInt("HourglassNumber", 0);

		hourglass1 = PlayerPrefs.GetInt("Hourglass1", 0);
		hourglass2 = PlayerPrefs.GetInt("Hourglass2", 0);
		hourglass3 = PlayerPrefs.GetInt("Hourglass3", 0);
		hourglass4 = PlayerPrefs.GetInt("Hourglass4", 0);
		hourglass5 = PlayerPrefs.GetInt("Hourglass5", 0);
		hourglass6 = PlayerPrefs.GetInt("Hourglass6", 0);
		hourglass7 = PlayerPrefs.GetInt("Hourglass7", 0);
		hourglass8 = PlayerPrefs.GetInt("Hourglass8", 0);
		hourglass9 = PlayerPrefs.GetInt("Hourglass9", 0);
		hourglass10 = PlayerPrefs.GetInt("Hourglass10", 0);

		if(hourglass1 == 0)
		{
			hourglass1Object.SetActive(true);
		}
		else
		{
			hourglass1Object.SetActive(false);
		}

		if (hourglass2 == 0)
		{
			hourglass2Object.SetActive(true);
		}
		else
		{
			hourglass2Object.SetActive(false);
		}

		if (hourglass3 == 0)
		{
			hourglass3Object.SetActive(true);
		}
		else
		{
			hourglass3Object.SetActive(false);
		}

		if (hourglass4 == 0)
		{
			hourglass4Object.SetActive(true);
		}
		else
		{
			hourglass4Object.SetActive(false);
		}

		if (hourglass5 == 0)
		{
			hourglass5Object.SetActive(true);
		}
		else
		{
			hourglass5Object.SetActive(false);
		}

		if (hourglass6 == 0)
		{
			hourglass6Object.SetActive(true);
		}
		else
		{
			hourglass6Object.SetActive(false);
		}

		if (hourglass7 == 0)
		{
			hourglass7Object.SetActive(true);
		}
		else
		{
			hourglass7Object.SetActive(false);
		}

		if (hourglass8 == 0)
		{
			hourglass8Object.SetActive(true);
		}
		else
		{
			hourglass8Object.SetActive(false);
		}

		if (hourglass9 == 0)
		{
			hourglass9Object.SetActive(true);
		}
		else
		{
			hourglass9Object.SetActive(false);
		}

		if (hourglass10 == 0)
		{
			hourglass10Object.SetActive(true);
		}
		else
		{
			hourglass10Object.SetActive(false);
		}
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerPrefs.DeleteAll();
			hourglass1 = 0;
			hourglass2 = 0;
			hourglass3 = 0;
			hourglass4 = 0;
			hourglass5 = 0;
			hourglass6 = 0;
			hourglass7 = 0;
			hourglass8 = 0;
			hourglass9 = 0;
			hourglass10 = 0;
			hourglassNumber = 0;
		}

		timer -= Time.deltaTime;
		textBox.text = Mathf.Round(timer).ToString();

		if (timer < 10.5)
		{
			textBox.color = new Color32(255, 0, 0, 255);
		}

		if (timer > 10.5)
		{
			textBox.color = new Color32(255, 255, 255, 255);
		}

		if (timer <= 0.5)
		{
			timer = 0;
			death = true;
		}

		if(hourglass1 == 1)
		{
			PlayerPrefs.SetInt("Hourglass1", 1);
		}
		if (hourglass2 == 1)
		{
			PlayerPrefs.SetInt("Hourglass2", 1);
		}
		if (hourglass3 == 1)
		{
			PlayerPrefs.SetInt("Hourglass3", 1);
		}
		if (hourglass4 == 1)
		{
			PlayerPrefs.SetInt("Hourglass4", 1);
		}
		if (hourglass5 == 1)
		{
			PlayerPrefs.SetInt("Hourglass5", 1);
		}
		if (hourglass6 == 1)
		{
			PlayerPrefs.SetInt("Hourglass6", 1);
		}
		if (hourglass7 == 1)
		{
			PlayerPrefs.SetInt("Hourglass7", 1);
		}
		if (hourglass8 == 1)
		{
			PlayerPrefs.SetInt("Hourglass8", 1);
		}
		if (hourglass9 == 1)
		{
			PlayerPrefs.SetInt("Hourglass9", 1);
		}
		if (hourglass10 == 1)
		{
			PlayerPrefs.SetInt("Hourglass10", 1);
		}
	}

	public void IncreaseTime()
	{
			Debug.Log("Time Increased");
			timer += timeBoost;
			startTimer += timeBoost;
			PlayerPrefs.SetFloat("Timer", startTimer);
	}
}