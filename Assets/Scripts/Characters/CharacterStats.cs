using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] private CharacterData characterData;

    [Header("Current Resources")]
    [SerializeField] private int currentHP;
    [SerializeField] private int currentStagger;
    [SerializeField] private int currentSanity;

    [Header("Temporary Stat Modifiers")]
    [SerializeField] private int attackModifier;
    [SerializeField] private int defenseModifier;
    [SerializeField] private int speedModifier;

    [Header("Battle State")]
    [SerializeField] private bool isStaggered;
    [SerializeField] private bool isDefeated;
    [SerializeField] private bool isDefending;

    public CharacterData Data => characterData;

    public int CurrentHP => currentHP;
    public int CurrentStagger => currentStagger;
    public int CurrentSanity => currentSanity;

    public int Attack => characterData.Attack + attackModifier;
    public int Defense => characterData.Defense + defenseModifier;
    public int Speed => characterData.Speed + speedModifier;

    public bool IsStaggered => isStaggered;
    public bool IsDefeated => isDefeated;
    public bool IsDefending => isDefending;

    private void Awake()
    {
        Initialize();
        InitializeSkills();
    }

    public void Initialize()
    {
        if (characterData == null)
        {
            Debug.LogError(
                "CharacterData has not been assigned to " +
                gameObject.name
            );

            return;
        }

        currentHP = characterData.MaxHP;
        currentStagger = 0;
        currentSanity = characterData.MaxSanity;

        attackModifier = 0;
        defenseModifier = 0;
        speedModifier = 0;

        isStaggered = false;
        isDefeated = false;
        isDefending = false;
    }

    public void InitializeSkills()
    {
        Skill[] skills = GetComponents<Skill>();

        foreach (Skill skill in skills)
        {
            skill.Initialize(this);
        }
    }

    public Skill GetSkill(SkillData skillData)
    {
        if (skillData == null)
        {
            return null;
        }

        Skill[] skills = GetComponents<Skill>();

        foreach (Skill skill in skills)
        {
            if (skill.Data == skillData)
            {
                return skill;
            }
        }

        return null;
    }

    public void TakeDamage(int damage)
    {
        if (isDefeated)
        {
            return;
        }

        damage = Mathf.Max(0, damage);

        currentHP -= damage;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Defeat();
        }
    }

    public void Heal(int amount)
    {
        if (isDefeated)
        {
            return;
        }

        amount = Mathf.Max(0, amount);

        currentHP += amount;
        currentHP = Mathf.Min(
            currentHP,
            characterData.MaxHP
        );
    }

    private void Defeat()
    {
        isDefeated = true;
        isStaggered = false;

        Debug.Log(
            characterData.CharacterName +
            " has been defeated."
        );
    }
}