using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class StartUp : MonoBehaviour
{
    [SerializeField] private SceneInitData sceneInitData;

    private void Start()
    {
        var json = JsonConvert.SerializeObject(sceneInitData);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }
}
