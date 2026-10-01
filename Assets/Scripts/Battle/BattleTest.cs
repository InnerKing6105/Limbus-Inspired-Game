using UnityEngine;

public class BattleTest : MonoBehaviour
{
    [SerializeField] private BattleManager battleManager;
    [SerializeField] private SkillData testSkill;

    public void TestPlayerAttack()
    {
        if (battleManager == null)
        {
            Debug.LogError(
                "BattleManager has not been assigned."
            );

            return;
        }

        if (testSkill == null)
        {
            Debug.LogError(
                "Test Skill has not been assigned."
            );

            return;
        }

        battleManager.PlayerUseSkill(testSkill);
    }
}