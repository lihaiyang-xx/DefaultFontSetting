using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[InitializeOnLoad]
public class DefaultFontSettingLaunch : Editor
{
    public static Font defaultFont;
    static DefaultFontSettingLaunch()
    {
        UpdateFont();

        EditorApplication.hierarchyWindowChanged += OnHierarchyWindowChanged;

        Debug.Log("default font:" + defaultFont);
    }

    
	static void OnHierarchyWindowChanged()
    {
        if(!defaultFont)
            return;
        GameObject selectGameObject = Selection.activeGameObject;
        if (selectGameObject)
        {
            Text[] texts = selectGameObject.GetComponentsInChildren<Text>();
            foreach (var text in texts)
            {
                text.font = defaultFont;
            }
        }
    }

    public static void UpdateFont()
    {
        defaultFont = GetDefaultFont();
    }


    public static Font GetDefaultFont()
    {
        string guid = EditorPrefs.GetString("fontGUID");
        if (!string.IsNullOrEmpty(guid))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Font font = AssetDatabase.LoadAssetAtPath<Font>(path);
            return font;
        }

        return null;
    }
}
