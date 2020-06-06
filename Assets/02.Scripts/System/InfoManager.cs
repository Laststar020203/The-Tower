using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEditor;


public class InfoManager : MonoBehaviour {

    public Info info = new Info();

   
    public string NAME = "/GameData.xml";

    public void Create()
    {
        /*
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "GameInfo", string.Empty);
        xmlDoc.AppendChild(root);

        XmlElement sceneIndex = xmlDoc.CreateElement("SceneIdx");
        sceneIndex.InnerText = "0";
        root.AppendChild(sceneIndex);

        xmlDoc.Save("./Assets")
        */

        XmlSerializer serializer = new XmlSerializer(typeof(Info));
        FileStream stream = new FileStream(Application.dataPath + NAME, FileMode.Create);
        serializer.Serialize(stream, info);
        stream.Close();

    }
	public Info Load()
    {
		
        XmlSerializer serializer = new XmlSerializer(typeof(Info));
        FileStream stream = new FileStream(Application.dataPath + NAME, FileMode.Open);
		info = (Info)serializer.Deserialize(stream);
        stream.Close();

		return info;

    }
    [SerializeField]
    public class Info
    {
       
        public int sceneIndex = 0;
    }
}


[CustomEditor(typeof(InfoManager))]
public class InfoManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        InfoManager myTarget = (InfoManager)target;

        EditorGUILayout.LabelField("NAME", (Application.dataPath + myTarget.NAME).ToString().Substring(31));
        EditorGUILayout.HelpBox("This is Gamedata PATH :)", MessageType.Warning);

    }
}

