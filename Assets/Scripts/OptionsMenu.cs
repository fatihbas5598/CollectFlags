using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeText;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
        else
        {
            LoadMuteToggle();
        }
    }


    void LoadMuteToggle()
    {
        muteToggle.isOn = PlayerPrefs.GetInt("Mute") == 1;
    }

    public void MuteToggle()
    {
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);

       if (muteToggle.isOn)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    private void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void VolumeControl(float volume)
    {
        volumeText.text = "Ses Duzeyi  " + volume.ToString("0");
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }

    private void Update()
    {
        LoadVolume();
    }
}
