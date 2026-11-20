using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Score
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Score/NewScoreIconsConfig", fileName = "ScoreIconsConfig")]
    public class ScoreIconsConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite WinsSprite { get; private set; }
        [field: SerializeField] public Sprite LosesSprite { get; private set; }
    }
}