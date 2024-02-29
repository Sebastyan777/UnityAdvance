using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeField] private SceneInitData sceneInitData;

    private void Start()
    {
        var prefabLight = sceneInitData.Light;
        var prefabGround = sceneInitData.Ground;
        var prefabGoofy = sceneInitData.Goofy;
        var prefabCannon = sceneInitData.Cannon;
        var prefabTree = sceneInitData.Tree;

        var spawnPoint = sceneInitData.SpawnPosition;

        Instantiate(prefabTree, spawnPoint, Quaternion.identity);
        Instantiate(prefabGoofy, spawnPoint, Quaternion.identity);
        Instantiate(prefabCannon, spawnPoint, Quaternion.identity);
        Instantiate(prefabGround, spawnPoint, Quaternion.identity);
        Instantiate(prefabLight, spawnPoint, Quaternion.identity);
    }
}
