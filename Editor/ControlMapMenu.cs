/*
 * InputManager in script changes: http://plyoung.appspot.com/blog/manipulating-input-manager-in-script.html
 * 
 */

using UnityEngine;
using UnityEditor;
using System;

namespace ThePipeCat.ControlMap
{
  public static class ControlMapMenu
  {
    private static string inputSettings = "ProjectSettings/InputManager.asset";
    private static string inputSettingsBackup = "ProjectSettings/InputManager~default.asset";

    private static string projectPath
    {
      get
      {
        string separator = "/";
        string[] pieces = Application.dataPath.Split(separator[0]);

        Array.Resize<string>(ref pieces, pieces.Length - 1);

        return string.Join(separator, pieces);
      }
    }

    [MenuItem("ThePipeCat/ControlMap/New Control Manager")]
    private static void NewControlManager()
    {
      ControlMapManager gameComponent = GameObject.FindObjectOfType<ControlMapManager>();

      if (gameComponent == null)
      {
        GameObject gameObject = new GameObject("Control Manager");

        gameObject.AddComponent<ControlMapManager>();

        Undo.RegisterCreatedObjectUndo(gameObject, "New Control Manager");

        Selection.activeGameObject = gameObject;
      }
      else
      {
        Selection.activeGameObject = gameComponent.gameObject;
      }
    }

    [MenuItem("ThePipeCat/ControlMap/New Control Profile")]
    private static ControlProfile NewControlProfile()
    {
      ControlProfile asset = ScriptableObject.CreateInstance<ControlProfile>();

      AssetDatabase.CreateAsset(asset, "Assets/New Control Profile.asset");
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();

      return asset;
    }

    [MenuItem("ThePipeCat/ControlMap/Backup Input Manager")]
    private static void BackupInputManager()
    {
      if (System.IO.File.Exists(projectPath + "/" + inputSettingsBackup))
      {
        System.IO.File.Delete(projectPath + "/" + inputSettingsBackup);
      }

      System.IO.File.Copy(projectPath + "/" + inputSettings, projectPath + "/" + inputSettingsBackup);
    }

    [MenuItem("ThePipeCat/ControlMap/Restore Input Manager")]
    private static void RestoreInputManager()
    {
      if (System.IO.File.Exists(projectPath + "/" + inputSettingsBackup))
      {
        SerializedObject oldSettings = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(inputSettingsBackup)[0]);
        SerializedObject settings = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(inputSettings)[0]);

        SerializedProperty oldAxisProperty = oldSettings.FindProperty("m_Axes");

        settings.CopyFromSerializedProperty(oldAxisProperty);

        settings.ApplyModifiedProperties();
      }
    }

    [MenuItem("ThePipeCat/ControlMap/Restore Input Manager", true)]
    private static bool RestoreInputManagerValidate()
    {
      return System.IO.File.Exists(projectPath + "/" + inputSettingsBackup);
    }
  }
}
