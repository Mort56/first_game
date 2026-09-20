public class ExperienceBar : AbstractGenericProgressBar<ExperienceManager>
{
    private void Start()
    {
        targetNormalized = targetObject.GetNormalized();
    }

    private void OnEnable()
    {
        ExperienceOrb.onTakeOrb += ExperienceOrb_onTakeOrb;
    }

    private void ExperienceOrb_onTakeOrb(object sender, System.EventArgs e)
    {
        targetNormalized = targetObject.GetNormalized();
    }

    private void OnDisable()
    {
        ExperienceOrb.onTakeOrb -= ExperienceOrb_onTakeOrb;
    }
}
