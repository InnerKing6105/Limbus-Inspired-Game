using UnityEngine;

[CreateAssetMenu(
    fileName = "NewCharacter",
    menuName = "Game/Character Data"
)]
public class CharacterData : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string characterName;
    [SerializeField] private Sprite portrait;

    [Header("Base Stats")]
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxSanity = 0;
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 5;
    [SerializeField] private int speed = 10;

    [Header("Skills")]
    [SerializeField] private SkillData[] skills;

    public string CharacterName => characterName;
    public Sprite Portrait => portrait;

    public int MaxHP => maxHP;
    public int MaxSanity => maxSanity;
    public int Attack => attack;
    public int Defense => defense;
    public int Speed => speed;

    public SkillData[] Skills => skills;
}