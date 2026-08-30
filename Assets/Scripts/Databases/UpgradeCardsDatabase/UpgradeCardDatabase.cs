using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "new UpgradeCard Database", menuName = "Database/UpgradeCard")]
public class UpgradeCardDatabase : GenericDatabase<UpgradeCard>
{
    public UpgradeCard GetCardById(int id)
    {
        return items.FirstOrDefault(card => card.Id == id);
    }
}

[System.Serializable]
public class UpgradeCard
{
    [SerializeField] private int id;
    public int Id => id;
    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;
    [SerializeField] private string description;
    public string Description => description;
    [SerializeField] private TypeOfComponentsChangedByUpgradeCards component;
    public TypeOfComponentsChangedByUpgradeCards Component => component; 
    [SerializeField] private float value;
    public float Value => value;
}

public enum TypeOfComponentsChangedByUpgradeCards
{
    Health,
    Damage,
    Speed,
    AttackCooldown,
    Count,
    Vampirism,
    Stamina,
    Shield,
    Luck
}