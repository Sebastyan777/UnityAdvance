using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "InitData/SceneInitData", fileName = "SceneInitData", order = 0)]
public class SceneInitData : ScriptableObject
{
    [JsonProperty("Name")] public string nameOfLoadedScene;
    [JsonProperty("Player")] public string nameOfPlayer;
    [JsonProperty("Player - Experience")] public string playerExperience;
    [JsonProperty("Player Money")] public string playerMoney;
}
