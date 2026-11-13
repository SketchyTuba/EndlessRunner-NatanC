using UnityEngine;

[CreateAssetMenu(fileName = "DefaultInkMenuSettings", menuName = "UI/Ink Menu Settings")]
public class InkMenuSettingsSO : ScriptableObject
{
    [Header("Audio Defaults")]
    [Range(0f, 100f)]
    public float masterVolume = 80f;

    [Range(0f, 100f)]
    public float sfxVolume = 85f;

    [Header("Visual & Accessibility Defaults")]
    public bool showSubtitles = true;
    public bool enableParchmentGrain = true;
}