using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabManipulation : MonoBehaviour {

	public Toggle settingsToggle;
	public Toggle habitatToggle;
	public Toggle bubbleToggle;

	public Toggle[] habitats;
	public Toggle[] bubbles;

	public GameObject settingsPane;
	public GameObject habitatPane;
	public GameObject bubblePane;
	public GameObject loadingScreen;

	public Text language;
	public int habitatNumber;

	public Scrollbar volumeBar;
	public Scrollbar bubbleBar;

	public InputField ChildLockPassField;

	string[] languages = {"ENGLISH", "ESPAÑOL", "ENGLISH & ESPAÑOL"};
	int lanMode = 0; // varies from 0 - 3;

	int hold; // for for language mode;

	private void Awake()	{
		language.text = languages [lanMode];
		Revert ();
	}//Awake()

	private void FixedUpdate()	{
		PlayerPrefs.SetFloat ("Volume", volumeBar.value);
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
	}//fixedupdate

	public void OnClickSettings()	{
		habitatPane.SetActive (false);
		bubblePane.SetActive (false);
		settingsPane.SetActive (true);
	}//OnClickSettings

	public void OnClickHabitat()	{
		settingsPane.SetActive (false);
		bubblePane.SetActive (false);
		habitatPane.SetActive (true);
	}//OnClickHabitat

	public void OnClickBubble()	{
		settingsPane.SetActive (false);
		habitatPane.SetActive (false);
		bubblePane.SetActive (true);
	}//OnClickBubble

	public void CloseSettings()	{
//		bool status = this.GetComponent<Animator> ().GetBool ("ActiveSettings");
		this.GetComponent<Animator> ().SetBool ("ActiveSettings", false);
	}//CloseSettings

	public void OpenSettings()	{
		this.GetComponent<Animator> ().SetBool ("ActiveSettings", true);
		Revert ();
	}//OpenSettings

	public void Load()	{
		loadingScreen.SetActive (true);
		Application.LoadLevelAsync (1);
//		Application.LoadLevel (1);
	}//Load

	public void ChangeLanguageLeft()	{
		lanMode -= 1;
		if (lanMode == -1)
			lanMode = 2;
		language.text = languages [lanMode];
	}//ChangeLangaugeLeft()

	public void ChangeLanguageRight()	{
		lanMode = lanMode;
		lanMode += 1;
		if (lanMode == 3)
			lanMode = 0;
		language.text = languages [lanMode];
	}//ChangeLanguageRight()

	public void SetHabitatNumber(int number)	{
		habitatNumber = number;
	}//SetHabitatNumber

	public void Apply()	{
		PlayerPrefs.SetString ("clp", ChildLockPassField.text);
		PlayerPrefs.SetFloat("VolumeFinal", volumeBar.value);
		PlayerPrefs.SetInt("HabitatNumber", habitatNumber); 
		PlayerPrefs.SetInt ("Language", lanMode);
//		PlayerPrefs.SetInt("H0", habitats

		//spawncount
//		PlayerPrefs.SetInt ("SpawnCount", (int)bubbleBar.value * 25/*max count*/);
		float rounded = Mathf.Round((bubbleBar.value * 25) * 100f) / 100f;
		if ((int)rounded == 0)
			rounded = 1;
		PlayerPrefs.SetInt ("SpawnCount", (int)rounded);


		for(int i = 0; i < habitats.Length; i++)
			PlayerPrefs.SetInt("H" + i, habitats[i].isOn ? 1:0);

		for (int i = 0; i < bubbles.Length; i++)
			PlayerPrefs.SetInt ("B" + i, bubbles [i].isOn ? 1 : 0);

	}//Apply

	public void Cancel()	{
		ChildLockPassField.text = PlayerPrefs.GetString ("clp");
		volumeBar.value = PlayerPrefs.GetFloat ("VolumeFinal");
		lanMode = PlayerPrefs.GetInt ("Language");
		language.text = languages [lanMode];
//		habitats [PlayerPrefs.GetInt ("HabitatNumber")].isOn = true;
		for(int i = 0; i < habitats.Length; i++)
			habitats[i].isOn = PlayerPrefs.GetInt("H" + i) == 1 ? true:false;

		for(int i = 0; i < bubbles.Length; i++)
			bubbles[i].isOn = PlayerPrefs.GetInt("B" + i) == 1 ? true : false;

		settingsToggle.isOn = true;
	}//cancel and close settings

	public void Revert()	{
		Cancel ();
	}//revert()

}//class
