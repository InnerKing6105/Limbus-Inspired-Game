using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("Battle Units")]
    [SerializeField] private CharacterStats playerUnit;
    [SerializeField] private CharacterStats enemyUnit;

    public CharacterStats PlayerUnit => playerUnit;
    public CharacterStats EnemyUnit => enemyUnit;

    private void Start()
    {
        if (playerUnit == null)
        {
            Debug.LogError(
                "Player Unit has not been assigned."
            );

            return;
        }

        if (enemyUnit == null)
        {
            Debug.LogError(
                "Enemy Unit has not been assigned."
            );

            return;
        }

        Debug.Log(
            "Battle started: " +
            playerUnit.Data.CharacterName +
            " vs " +
            enemyUnit.Data.CharacterName
        );
    }

    public void PlayerUseSkill(SkillData skillData)
    {
        if (skillData == null)
        {
            Debug.LogError(
                "No SkillData was provided."
            );

            return;
        }

        if (playerUnit == null)
        {
            Debug.LogError(
                "Player Unit has not been assigned."
            );

            return;
        }

        if (enemyUnit == null)
        {
            Debug.LogError(
                "Enemy Unit has not been assigned."
            );

            return;
        }

        if (playerUnit.IsDefeated)
        {
            Debug.LogWarning(
                "The player unit is defeated."
            );

            return;
        }

        if (enemyUnit.IsDefeated)
        {
            Debug.LogWarning(
                "The enemy unit is defeated."
            );

            return;
        }

        Skill skill = playerUnit.GetSkill(skillData);

        if (skill == null)
        {
            Debug.LogError(
                playerUnit.Data.CharacterName +
                " does not have the skill " +
                skillData.SkillName
            );

            return;
        }

        skill.Use(enemyUnit);
    }
}