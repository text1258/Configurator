using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DatabaseController : MonoBehaviour
{
    private Videocard testInfoVideocard;
    private string seletedTech = "RAM";

    private void Start()
    {
        testInfoVideocard = new Videocard();
        testInfoVideocard.name = "Ô2";
        testInfoVideocard.VideoMemory = "24";

        var list = JObject.Parse(File.ReadAllText(Application.streamingAssetsPath + "/TestDB.json")).SelectToken(seletedTech).ToObject<List<string>>();

        foreach (var item in list)
        {
        }
        // if (dict[nameof(testInfoVideocard.VideoMemoryT)] == testInfoVideocard.VideoMemoryT.ToString())
    }
}