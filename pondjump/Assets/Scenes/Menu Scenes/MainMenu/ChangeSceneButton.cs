using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ChangeSceneButton : MonoBehaviour
{
	
    private void Start()
    {
		for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			Debug.Log("Scene " + i + ": " + SceneManager.GetSceneByBuildIndex(i).name);
		}
	
	}


	public void OnPlaySound()
	{
		FindObjectOfType<AudioManager>().Play("PlayMM");
	}

	public void PressButton()
	{
		FindObjectOfType<AudioManager>().Play("ButtonPressGeneral");
	}

	public void GoBack()
	{
		FindObjectOfType<AudioManager>().Play("LillyClick");
	}

	public void HSMenu()
	{



		FindObjectOfType<AudioManager>().Play("HSClick");
	}

	public void Quit()
	{
		FindObjectOfType<AudioManager>().Play("Quit");
	}


	//Starts Environmental Sounds
	public void GeneralAmb()
	{
		FindObjectOfType<AudioManager>().Play("General Ambiance");
	}

	public void AmbBurbs()
	{
		FindObjectOfType<AudioManager>().Play("AmbientSuburbs");
	}

	public void BreezeGrass()
	{
		FindObjectOfType<AudioManager>().Play("breezeandgrass");
	}

	public void FactoryAmb()
	{
		FindObjectOfType<AudioManager>().Play("FactoryAmbiance");
	}

	public void FrogCroak()
	{
		
		FindObjectOfType<AudioManager>().Play("FrogCroak");
	}

	public void EveRain()
	{
		FindObjectOfType<AudioManager>().Play("Rain");
	}
	public void SoftWind()
	{
		FindObjectOfType<AudioManager>().Play("Soft-Wind");
	}

	public void WatDrips()
	{
	
		FindObjectOfType<AudioManager>().Play("WaterDrips");
	}

	
	public void CaveWat()
	{
		FindObjectOfType<AudioManager>().Play("WaterInCave");
	}

	public void WellWat()
	{
		FindObjectOfType<AudioManager>().Play("WellWater");
	}

	public void VentWind()
	{
		
		FindObjectOfType<AudioManager>().Play("WindInVent");
	}
	public void LoadScene(int sceneName)
	{
		
		change = sceneName;
		//Invoke("ChangeScene", 2f);
		ChangeScene();
		Debug.Log(change);

		DontDestroyOnLoad(this.gameObject);
	}


	public void ChangeScene()
    {

		SceneManager.LoadScene(change);
		
	}

	public void RestartScene()
    {
		Scene thisscene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(thisscene.name);
		DontDestroyOnLoad(this.gameObject);
    }


	public int change;

}


