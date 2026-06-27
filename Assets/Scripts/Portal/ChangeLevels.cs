using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelVisual
{
    public int levelIndex;
    public GameObject normal;
    public GameObject broken;
}

public class ChangeLevels : MonoBehaviour
{
    [SerializeField] private List<LevelVisual> levels;

    public void ChangeVisualOfLevelsTeleporter()
    {
        int currentLevel = DatabaseManager.Instance.LoadCompletedLevelsCount();

        foreach (var level in levels)
        {
            bool unlocked = currentLevel >= level.levelIndex;
            level.normal.SetActive(unlocked);
            level.broken.SetActive(!unlocked);
        }
    }
}