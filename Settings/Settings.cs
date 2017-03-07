using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

	public GameObject[] settingsPanels;
	public Toggle[] habitats;
	public Toggle[] bubbles;
	public Toggle[] languages;

	public Text bubbleCount;
	public Slider bubbleCountSlider;
	public Slider volumeSlider;

	public Animator anim;

	public InputField password;
	public InputField confirmPassword;

	public Button okayButton;
	public GameObject passNotMatch;
	public GameObject loadingScreen;

	public Object LoadNextScene;

	private void Awake()	{
		bubbleCountSlider.value = PlayerPrefs.GetInt ("SpawnCount");
		volumeSlider.value = PlayerPrefs.GetFloat ("Volume");

		for(int i = 0; i < habitats.Length; i++)
			habitats[i].isOn = PlayerPrefs.GetInt("H" + i) == 1 ? true:false;

		for(int i = 0; i < bubbles.Length; i++)
			bubbles[i].isOn = PlayerPrefs.GetInt("B" + i) == 1 ? true : false;

		languages[PlayerPrefs.GetInt("Language")].isOn = true;

		password.text = PlayerPrefs.GetString ("clp");
		confirmPassword.text = PlayerPrefs.GetString ("clp");

	}//Awake

	private void FixedUpdate()	{
		SetPassword ();

		for(int i = 0; i < habitats.Length; i++)	{
			if(i == habitats.Length - 1 && !habitats[i].isOn)	{
				print ("You should select atleast one! Selecting the first one."); //error
				habitats[0].isOn = true;
			}//if
			else if(i != habitats.Length - 1 && habitats[i].isOn)
				break;
			else continue;
		}//for

		for (int i = 0; i < bubbles.Length; i++) {
			if(i == bubbles.Length - 1 && !bubbles[i].isOn)	{
				print ("You should select alteast one bubble! Selecting the first one.");//error
				bubbles[0].isOn = true;
			}//if
			else if(i != bubbles.Length - 1 && bubbles[i].isOn)
				break;
			else continue;
		}//for
	}//FixedUpdate

	public void ChangePane(int value)	{
//		print ("Chage to value " + value);
		for(int i = 0; i < settingsPanels.Length; i++)
			if(settingsPanels[i].activeSelf)
				settingsPanels[i].SetActive(false);

		settingsPanels[value].SetActive(true);
	}//changePane

	public void SetBubbleCount()	{
//		bubbleCount.text = bubbleCountSlider.value.ToString ();
		switch ((int)bubbleCountSlider.value) {
		case 1: bubbleCount.text = "MIN"; break;
		case 2: bubbleCount.text = "LESS"; break;
		case 3: bubbleCount.text = "NORMAL"; break;
		case 4: bubbleCount.text = "MANY"; break;
		case 5: bubbleCount.text = "MAX"; break;
		}//switch
		PlayerPrefs.SetInt ("SpawnCount", (int)bubbleCountSlider.value);
	}//SetBubbleCoutn()

	public void SetVolume()	{
		PlayerPrefs.SetFloat("Volume", volumeSlider.value);
	}//SEtVolume();



	public void OkaySettings()	{
		anim.SetBool ("ActiveSettings", false);

		for (int i = 0; i < habitats.Length; i++)
			PlayerPrefs.SetInt ("H" + i, habitats [i].isOn ? 1 : 0);
		for(int i = 0; i < bubbles.Length; i++)
			PlayerPrefs.SetInt("B" + i, bubbles[i].isOn ? 1:0);

		for(int i = 0; i < languages.Length; i++)	{
			if(languages[i].isOn)	{
				PlayerPrefs.SetInt ("Language", i);
				break;
			}//if
		}//for
	}//OkaySettings

	public void SetPassword()	{
		if (password.text != confirmPassword.text) {
			print ("Password do not match");
			okayButton.interactable = false;
			passNotMatch.SetActive(true);
		}//if
		else {
			okayButton.interactable = true;
			PlayerPrefs.SetString("clp", password.text);
			passNotMatch.SetActive(false);
		}//else
	}//setPassword()

	public void LoadGame()	{
		loadingScreen.SetActive (true);
		if (loadingScreen.activeSelf == true)
			StartCoroutine (LoadDelay ());
	}//Load

	public IEnumerator LoadDelay()	{
		yield return new WaitForSeconds (.5f);
		Application.LoadLevelAsync (2);
		yield return new WaitForSeconds (0);
	}//

	public void ToggleSettings()	{
		anim.SetBool ("ActiveSettings", true);
	}//ToggleSettings


}//class
