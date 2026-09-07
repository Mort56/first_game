using System.Collections;
using UnityEngine;

public class PlayerTakeExperience : AbstractFindByRadius
{
    [SerializeField] private float timeBetweenExperienceCollections = 0.25f;

    private WaitForSeconds _waitTimeBetweenExperienceCollections;

    protected override void Awake()
    {
        base.Awake();
        _waitTimeBetweenExperienceCollections = new WaitForSeconds(timeBetweenExperienceCollections);
    }

    private void OnEnable()
    {
        StartCoroutine(ExperienceCollectionsCoroutine());
    }

    private IEnumerator ExperienceCollectionsCoroutine()    
    {
        while (true)
        {
            EffectToTargetInRadius();
            for (var i = 0; i < numberOfTargetsFound; i++)
                if (objects[i].TryGetComponent<ExperienceOrb>(out var orb))
                    orb.ChasingPlayer();
            yield return _waitTimeBetweenExperienceCollections;
        }
    }
}
