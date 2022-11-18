using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text textField;

    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeSlider(float volume)
    {
        textField.text = volume.ToString("0.0");
        SaveVolume();

    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue",volumeValue);
        LoadValues();
    }
    
    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    // public void ChangeVol(float newValue) 
    // {
    //     float newVol = AudioListener.volume;
    //     newVol = newValue;
    //     AudioListener.volume = newVol;
    // }
}
