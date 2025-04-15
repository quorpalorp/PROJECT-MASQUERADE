using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStates { START, PLAYERTURN, ENEMYTURN, WON, LOST }

//this is the latest copy of the BattleSystem script by gabriel
//dont use the one in elias's folder thats outdated
public class BattleSystemFINAL : MonoBehaviour
{

    public GameObject PCharacterPrefab;
    public GameObject enemyPrefab;

    public Transform PCharacterBattleStation;
    public Transform enemyBattleStation;

    UnitFINAL playerUnit;
    UnitFINAL enemyUnit;

    public Text dialougeText;

    public BattleHUDFINAL playerHUD;
    public BattleHUDFINAL enemyHUD;
    //public BattleHUDTHEFINALS DISSUN;


    public BattleStates state;

    void Start()
    {
        state = BattleStates.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(PCharacterPrefab, PCharacterBattleStation);
        playerUnit = playerGO.GetComponent<UnitFINAL>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<UnitFINAL>();

        dialougeText.text = enemyUnit.unitName + " Wants to kill you... ";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleStates.PLAYERTURN;
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
            state = BattleStates.WON;
            EndBattle();
        }
        else
        {
            state = BattleStates.ENEMYTURN;
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
            state = BattleStates.LOST;
            EndBattle();
        }
        else
        {
            state = BattleStates.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleStates.WON)
        {
            dialougeText.text = "Lovley kill... Player.";
        }
        else if (state == BattleStates.LOST)
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

        state = BattleStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerBlock()
    {
        playerUnit.setdefense();

        yield return new WaitForSeconds(1f);

        state = BattleStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleStates.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleStates.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void OnBlockButton()
    {
        if (state != BattleStates.PLAYERTURN)
            return;

        StartCoroutine(PlayerBlock());
    }
}

