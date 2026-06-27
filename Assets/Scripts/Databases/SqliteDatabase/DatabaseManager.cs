using UnityEngine;
using SQLite;
public class DatabaseManager : MonoBehaviour
{
    private SQLiteConnection _db;
    public static DatabaseManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        string path = Application.persistentDataPath + "/game.db";
        if (_db == null)
        {
            _db = new SQLiteConnection(path);
            _db.CreateTable<PlayerDatabase>();
        }
    }

    public void UpdateCompletedLevelsCount(int count)
    {
        var player = GetOrCreatePlayer();
        player.completedLevelsCount = count;
        _db.Update(player);
    }

    public int LoadCompletedLevelsCount()
    {
        var player = GetOrCreatePlayer();
        return player.completedLevelsCount;
    }

    private PlayerDatabase GetOrCreatePlayer()
    {
        var player = _db.Table<PlayerDatabase>().FirstOrDefault();
        if (player == null)
        {
            player = new PlayerDatabase();
            _db.Insert(player);
        }
        return player;
    }

    private void DeleteDatabase()
    {
        _db.DeleteAll<PlayerDatabase>();
    }

    private void OnApplicationQuit()
    {
        _db?.Dispose();
    }
}

public class PlayerDatabase
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int completedLevelsCount { get; set; } = 0;
}