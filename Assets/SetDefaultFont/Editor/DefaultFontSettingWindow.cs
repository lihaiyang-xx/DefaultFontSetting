using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DefaultFontSettingWindow : EditorWindow
{
    private Font font;
    [MenuItem("DefaultFont/Setting")]
    static void InitWindow()
    {
        DefaultFontSettingWindow window = EditorWindow.GetWindow<DefaultFontSettingWindow>();
        //window.Show();
    }

    void Reset()
    {
        font = DefaultFontSettingLaunch.GetDefaultFont();
    }


    void OnGUI()
    {
        font = EditorGUILayout.ObjectField("Default Font", font, typeof(Font), false) as Font;
        GUILayout.Space(100);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Apply",GUILayout.Width(100)))
        {
            if (font)
            {
                string path = AssetDatabase.GetAssetPath(font);
                string guid = AssetDatabase.AssetPathToGUID(path);
                EditorPrefs.SetString("fontGUID", guid);
                Debug.Log("set default font : " + font.name);
            }
            else
            {
                EditorPrefs.DeleteKey("fontGUID");
                Debug.Log("clear custom default font ,will use unity default font arial");
            }

            DefaultFontSettingLaunch.UpdateFont();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

}
