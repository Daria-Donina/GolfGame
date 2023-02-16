using System;
using UnityEngine;

namespace DefaultNamespace.Configs
{
    [Serializable]
    public class MapData
    {
        public int id;
        public string mapName;
        public string playerPrefab;
        public Vector3 startPosition;
    }
}