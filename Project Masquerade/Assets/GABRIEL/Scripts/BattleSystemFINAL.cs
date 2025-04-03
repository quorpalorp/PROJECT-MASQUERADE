using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

//this is the latest copy of the BattleSystem script by gabriel
//dont use the one in elias's folder thats outdated
public class BattleSystemFINAL : MonoBehaviour
{

    public GameObject PCharacterPrefab;
    public GameObject enemyPrefab;

    public Transform PCharacterBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialougeText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(PCharacterPrefab, PCharacterBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialougeText.text = enemyUnit.unitName + " Wants to kill you... ";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialougeText.text = "Nice attack... Player.";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialougeText.text = enemyUnit.unitName + " Turn to attack... ";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);
        playerUnit.ResetDefense();

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialougeText.text = "Lovley kill... Player.";
        }
        else if (state == BattleState.LOST)
        {
            dialougeText.text = "Get up... Player. GET UP!";
        }
    }

    void PlayerTurn()
    {
        dialougeText.text = "It's Your Turn... Player.";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(50);

        playerHUD.SetHP(playerUnit.currentHP);
        dialougeText.text = "Healed... NOW GIVE IT YOUR ALL!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerBlock()
    {
        playerUnit.setdefense();

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void OnBlockButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerBlock());
    }
}

