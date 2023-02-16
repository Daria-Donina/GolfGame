using System;
using System.Runtime.InteropServices;
using UnityEngine.Serialization;

namespace DefaultNamespace.Progress
{
    public class PlayerProgress
    {
        public PlayerServerProgress playerInfo;

        public PlayerProgress(int levelId)
        {
            playerInfo = new PlayerServerProgress
            {
                level = levelId
            };
        }
    }

    [Serializable]
    public class PlayerServerProgress
    {
        public int level;
    }
}