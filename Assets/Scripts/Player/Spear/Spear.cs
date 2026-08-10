using UnityEngine;

public class SpearFindTargetsEnemy : AbstractFindByRadius
{
    public int NumberOfTargetsFound => numberOfTargetsFound;
    public Collider2D[] Objects => objects;
}
