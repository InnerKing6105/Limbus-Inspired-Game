using UnityEngine;

[CreateAssetMenu(
    fileName = "NewSkill",
    menuName = "Game/Skill Data"
)]
public class SkillData : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string skillName;
    [SerializeField] private string description;

    [Header("Combat")]
    [SerializeField] private int power = 10;
    [SerializeField] private int coins = 1;

    public string SkillName => skillName;
    public string Description => description;
    public int Power => power;
    public int Coins => coins;
}