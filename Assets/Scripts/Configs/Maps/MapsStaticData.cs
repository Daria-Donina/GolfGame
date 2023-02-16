using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Configs
{
    [ConfigPath("Maps")]
    [CreateAssetMenu(menuName = "Configs/MapsConfig")]
    public class MapsStaticData : BaseConfig
    {
        [SerializeField] private List<MapData> mapData;

        public MapData GetDataBy(int id) => 
            mapData.Find(data => data.id == id);
    }
}