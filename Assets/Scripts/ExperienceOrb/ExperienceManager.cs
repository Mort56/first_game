using System;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private float experienceRequiredForUpgrade = 100f;
    [SerializeField] private float experienceByOrb;
    [SerializeField] private float modifier = 1.15f;
    [SerializeField] private float minExperienceByOrb = 8f;
    [SerializeField] private float maxExperienceByOrb = 12f;
    private float _currentExperience;
    public float ExperienceReuiredForUograde => experienceRequiredForUpgrade;

    public static ExperienceManager Instance;
    public static event EventHandler onBarFilledUp;

    private void Awake()
    {
        Instance = this;
        _currentExperience = 0f;
    }

    private void OnEnable()
    {
        ExperienceOrb.onTakeOrb += ExperienceOrb_onTakeOrb;
    }

    private void ExperienceOrb_onTakeOrb(object sender, System.EventArgs e)
    {
        experienceByOrb = GetRandomExpirienceByOrb();
        _currentExperience += experienceByOrb;
        if (_currentExperience >= experienceRequiredForUpgrade)
        {
            _currentExperience -= experienceRequiredForUpgrade;
            experienceRequiredForUpgrade *= modifier;
            onBarFilledUp?.Invoke(this, new EventArgs());
        }
    }

    private float GetRandomExpirienceByOrb()
    {
        return UnityEngine.Random.Range(minExperienceByOrb, maxExperienceByOrb);
    }

    public float GetNormalized()
    {
        return _currentExperience / experienceRequiredForUpgrade;
    }

    private void OnDisable()
    {
        ExperienceOrb.onTakeOrb -= ExperienceOrb_onTakeOrb;
    }
}
