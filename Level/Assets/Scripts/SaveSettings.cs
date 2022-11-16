using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SaveSettings : MonoBehaviour
{
    [SerializeField] private Slider MSSlider;
    public float MSVaule;
    
    [SerializeField] private Slider PlayerVolumeSlider;
    public float playervolumeVaule;

    [SerializeField] private Slider AudioSlider;
    public float audioVaule;
    
    [SerializeField] private Slider gunSlider;
    public float gunVaule;

    [SerializeField] private Slider OverallSlider;
    public float overallVaule;

    [SerializeField] AudioMixer MasterMixer;
    public float volume;

    void OnEnable()
    {
        if (PlayerPrefs.HasKey("msValue"))
        {
            LoadMSSettings();
            LoadPVSettings();
            LoadAudioSettings();
            LoadGunSettings();
            LoadOverallSettings();
        }
        else
        {
            DefaultSettings();
        }
    }
    public void SaveAllSettings()
    {
        SaveMSSettings();
        SavePlayerVolumeSettings();
        SaveAudioSettings();
        SaveGunSettings();
        SaveOverallSettings();
    }

    public void DefaultSettings()
    {
        MSVaule = 350;
        playervolumeVaule = 0.5f;
        audioVaule = 0.5f;
        gunVaule = 0.5f;
        overallVaule = 0.5f;
    }


    //Manages Mouse senseitivity
    public void SaveMSSettings()
    {
        MSVaule = MSSlider.value;
        PlayerPrefs.SetFloat("msValue", MSVaule);
        LoadMSSettings();
    }
    void LoadMSSettings()
    {
        float MSVaule = PlayerPrefs.GetFloat("msValue");
        MSSlider.value = MSVaule;
    }
    //Manages Player volume
    public void SavePlayerVolumeSettings()
    {
        playervolumeVaule = PlayerVolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", playervolumeVaule);
        LoadPVSettings();
    }
    void LoadPVSettings()
    {
        float playervolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        PlayerVolumeSlider.value = playervolumeValue;
    }
    //Manages Music volume
    public void SaveAudioSettings()
    {
        audioVaule = AudioSlider.value;
        PlayerPrefs.SetFloat("AudioValue", audioVaule);
        LoadAudioSettings();
    }
    void LoadAudioSettings()
    {
        float audioVaule = PlayerPrefs.GetFloat("AudioValue");
        AudioSlider.value = audioVaule;
    }
    //Manages Gun volume
    public void SaveGunSettings()
    {
        gunVaule = gunSlider.value;
        PlayerPrefs.SetFloat("GunSlider", gunVaule);
        LoadGunSettings();
    }
    void LoadGunSettings()
    {
        float gunVaule = PlayerPrefs.GetFloat("GunSlider");
        gunSlider.value = gunVaule;
    }
    //Manages Overall volume
    public void SaveOverallSettings()
    {
        overallVaule = OverallSlider.value;
        MainMenuManager.instance.OverallVaule = overallVaule;
        MasterMixer.SetFloat("Audio Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("OverallSlider", overallVaule);
        LoadOverallSettings();
    }
    void LoadOverallSettings()
    {
        float overallVaule = PlayerPrefs.GetFloat("OverallSlider");
        OverallSlider.value = overallVaule;
    }
}
