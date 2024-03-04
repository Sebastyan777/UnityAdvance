using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;
using System;

public class StartUp : MonoBehaviour
{
    [SerializeField] private GoofyMovement goofy;
    [SerializeField] private CannonMovement cannon;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private TextMeshProUGUI labelLevel;
    [SerializeField] private SaveData saveData = new SaveData();

    private void Start()
    {
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

    private void Save()
    {
        saveData.Level = labelLevel.text;
        saveData.CoordX = goofy.transform.position.x;
        saveData.CoordY = goofy.transform.position.y;
        saveData.CoordZ = goofy.transform.position.z;
        saveData.CoordX = cannon.transform.position.x;
        saveData.CoordY = cannon.transform.position.y;
        saveData.CoordZ = cannon.transform.position.z;

        var saveJson = JsonConvert.SerializeObject(saveData);
        PlayerPrefs.SetString("save", saveJson);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        var loadJson = PlayerPrefs.GetString("save");
        var loadData = JsonConvert.DeserializeObject<SaveData>(loadJson);

        goofy.transform.position = new Vector3(loadData.CoordX, loadData.CoordY, loadData.CoordZ);
        cannon.transform.position = new Vector3(loadData.CoordX, loadData.CoordY, loadData.CoordZ);
        labelLevel.text = saveData.Level;
    }
}

[Serializable]
public class SaveData
{
    public string Level;
    public float CoordX, CoordY, CoordZ;

    public SaveData()
    {
        Level = $"Level {0f}";
        CoordX = CoordY = CoordZ = 0f;
    }
}
