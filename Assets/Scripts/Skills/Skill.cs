using UnityEngine;

public class Skill : MonoBehaviour
{
    [Header("Skill")]
    [SerializeField] private SkillData skillData;

    private CharacterStats owner;

    public SkillData Data => skillData;
    public CharacterStats Owner => owner;

    public void Initialize(CharacterStats character)
    {
        owner = character;
    }

    public void Use(CharacterStats target)
    {
        if (owner == null)
        {
            Debug.LogError(
                "Skill has no owner."
            );

            return;
        }

        if (skillData == null)
        {
            Debug.LogError(
                "SkillData has not been assigned."
            );

            return;
        }

        if (target == null)
        {
            Debug.LogError(
                "Skill has no target."
            );

            return;
        }

        if (owner.IsDefeated)
        {
            Debug.LogWarning(
                owner.Data.CharacterName +
                " cannot use a skill because they are defeated."
            );

            return;
        }

        if (target.IsDefeated)
        {
            Debug.LogWarning(
                target.Data.CharacterName +
                " is already defeated."
            );

            return;
        }

        int damage = CalculateDamage(target);

        target.TakeDamage(damage);

        Debug.Log(
            owner.Data.CharacterName +
            " used " +
            skillData.SkillName +
            " on " +
            target.Data.CharacterName +
            " for " +
            damage +
            " damage."
        );
    }

    private int CalculateDamage(CharacterStats target)
    {
        int damage =
            owner.Attack +
            skillData.Power -
            target.Defense;

        return Mathf.Max(1, damage);
    }
}