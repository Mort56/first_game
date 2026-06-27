using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Database), true)]
public class DatabaseEditor : Editor
{
    private Database _itemBase;
    private void Awake()
    {
        _itemBase = (Database)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("<="))
            _itemBase.Prev();

        if (GUILayout.Button("Create"))
        {
            _itemBase.Create();
            EditorUtility.SetDirty(_itemBase);
        }

        if (GUILayout.Button("Delete"))
        {
            _itemBase.Delete();
            EditorUtility.SetDirty(_itemBase);
        }

        if (GUILayout.Button("=>"))
            _itemBase.Next();

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
