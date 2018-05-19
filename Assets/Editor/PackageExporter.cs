using System.IO;
using UnityEditor;
using UnityEngine;

public static class PackageExporter
{
	[MenuItem("Custom/Export Package")]
	static void Export()
	{
		string directory = new DirectoryInfo(Application.dataPath + "/..").FullName;
		string exportPath = "Assets/Plugins/SouthPointe";
		ExportPackageOptions options = ExportPackageOptions.Recurse | ExportPackageOptions.Default;

		string path = EditorUtility.SaveFilePanel("Export Package", directory, "msgpack-unity", "unitypackage");
		AssetDatabase.ExportPackage(exportPath, path, options);
		Debug.LogFormat("Package exported to: {0}", path);
	}
}
