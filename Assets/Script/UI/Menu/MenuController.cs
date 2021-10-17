using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSevedGameDialogue = null;

    [Header("Volume Setting")]
    [SerializeField] private TMP_TextElement volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private GameObject ConfirmationPrompt = null;
    
    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogueYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSevedGameDialogue.SetActive(true);
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        //volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfirmationPrompt.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
    
}
