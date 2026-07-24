using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon Databases", menuName = "Database/Weapons")]
public class WeaponDatabase : GenericDatabase<Weapon>
{

}

[System.Serializable]
public class Weapon
{
    [SerializeField] private int id;
    public int Id => id;

    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField] private int level;
    public int Level => level;

    [SerializeField] private float cooldown;
    public float Cooldown => cooldown;

    [SerializeField] private float scale;
    public float Scale => scale;
}
