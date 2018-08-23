using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // interacting with scene change
using UnityEngine.UI; // interacting with GUI elements
using UnityEngine.EventSystems; // control the event
public class MenuHandler : MonoBehaviour
    {
    #region Variables
    public GameObject mainMenu, optionsMenu;
    public bool showOptions;
    public Slider volumeSlider, brightSlider;
    public AudioSource mainMusic;
    public Light dirLight;
    #endregion
    private void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        mainMusic = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    public void ToggleOptions()
    {
        OptionToggle();
    }
    bool OptionToggle()
    {
        if(showOptions)//showOptions == true means showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return true;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            return false;
        }
    }
    public void Volume()
    {
        mainMusic.volume = volumeSlider.value;
    }
    public void Brightness()
    {

    }
}



