using UnityEngine;

    [CreateAssetMenu(menuName = "Init Data/Scene", fileName = "Scene", order = 0)]

    public class SceneInitData : ScriptableObject
    {
        public GameObject Ground, Light, Cannon, Goofy, Tree;
        public Vector3 SpawnPosition;
    }