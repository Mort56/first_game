public class ExperienceOrbSpawner : GenericItemPoolManager<ExperienceOrb>
{
    public static ExperienceOrbSpawner Instance;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
}
