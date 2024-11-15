using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public Button settingsButton;
    public Button closeButton;
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    /// <summary>
    /// Initializes the settings menu, sets up listeners for buttons and sliders, 
    /// and applies current volume settings from SoundManager.
    /// </summary>
    private void Start()
    {
        settingsMenu.SetActive(false);

        settingsButton.onClick.AddListener(() => UIAnimator.ShowUI(settingsMenu));
        closeButton.onClick.AddListener(() => UIAnimator.HideUI(settingsMenu));

        CanvasGroup canvasGroup = settingsMenu.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = settingsMenu.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0;

        SoundManager.Instance.PlayMusic("MainBackground");

        musicVolumeSlider.value = SoundManager.Instance.GetMusicVolume();
        soundEffectsVolumeSlider.value = SoundManager.Instance.GetSoundEffectsVolume();

        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        soundEffectsVolumeSlider.onValueChanged.AddListener(SetSoundEffectsVolume);
    }

    public void PlayButtonClickSound()
    {
        SoundManager.Instance.PlaySound("Click");
    }
    /// <summary>
    /// Updates the music volume based on the slider value.
    /// </summary>
    /// <param name="value">The value of the music volume slider (0 to 1).</param>
    private void SetMusicVolume(float value)
    {
        SoundManager.Instance.SetMusicVolume(value);
    }

    /// <summary>
    /// Updates the sound effects volume based on the slider value.
    /// </summary>
    /// <param name="value">The value of the sound effects volume slider (0 to 1).</param>
    private void SetSoundEffectsVolume(float value)
    {
        SoundManager.Instance.SetSoundEffectsVolume(value);
    }
}