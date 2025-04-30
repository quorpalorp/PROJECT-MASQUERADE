using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStates { START, PLAYERTURN, ENEMYTURN, WON, LOST }

//this is the latest copy of the BattleSystem script by gabriel
//dont use the one in elias's folder thats outdated
public class BattleSystemFINAL : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;

    public Transform PlayerBattleStation;
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
        GameObject playerGO = Instantiate(Player, PlayerBattleStation);
        playerUnit = playerGO.GetComponent<UnitFINAL>();
        GameObject enemyGO = Instantiate(Enemy, enemyBattleStation);
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
        playerUnit.currentAP = playerUnit.currentAP - playerUnit.damageCost;

        enemyHUD.SetHP(enemyUnit.currentHP);
        enemyUnit.ResetDefense();
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
        dialougeText.text = enemyUnit.unitName + " Is Choosing... "; 

        yield return new WaitForSeconds(2f);
         
        int choice = Random.Range(1, 4);

        if (choice == 1) //attack
        {
            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

            dialougeText.text = enemyUnit.unitName + " Has thrown an attack! ";

            playerHUD.SetHP(playerUnit.currentHP);
            playerUnit.ResetDefense();

            yield return new WaitForSeconds(2f);

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
        else if (choice == 2) //heal
        { 
            enemyUnit.Heal(5);

            enemyHUD.SetHP(enemyUnit.currentHP);
            dialougeText.text = enemyUnit.unitName + " Has healed... ";

            yield return new WaitForSeconds(2f);

            state = BattleStates.PLAYERTURN;
            PlayerTurn();
            
        }
        else if (choice == 3) //block
        {
            enemyUnit.Setdefense();
            dialougeText.text = enemyUnit.unitName + " Is Blocking... ";

            yield return new WaitForSeconds(2f);

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
            dialougeText.text = "hehe get gud bozo"; 
        }
    }

    void PlayerTurn()
    {
        dialougeText.text = "It's Your Turn... Player."; 
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.heal);
        playerUnit.currentAP = playerUnit.currentAP - playerUnit.healCost;
        playerHUD.SetHP(playerUnit.currentHP);
        dialougeText.text = "Player Healed... NOW GIVE IT YOUR ALL!";

        yield return new WaitForSeconds(2f);

        state = BattleStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerBlock()
    {
        playerUnit.Setdefense();
        dialougeText.text = "Player Is Blocking...";

        yield return new WaitForSeconds(2f);

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

