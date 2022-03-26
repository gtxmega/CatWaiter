using System;

namespace CodeBase.Infrastructure.Data
{
    [Serializable]
    public struct WorldData
    {
        public string SceneName;
    }
    
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData { get; private set; }
        
        public float Gold;
    }
}