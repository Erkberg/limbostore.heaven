using UnityEngine;

namespace Game
{
    [CreateAssetMenu(order = 0, fileName = "New DeathType", menuName = "Data/Death Type")]
    public class DeathType : ScriptableObject
    {
        public string title;
        [TextArea(2, 16)]
        public string description;
        public AudioClip deathClip;
        
        public int rewardFirstDeath = 10;
        public int rewardDefault = 1;
    }
}