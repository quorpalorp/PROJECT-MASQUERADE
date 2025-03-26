using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {  START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
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
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn(); 
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {

        } else if (state == BattleState.LOST)
        {

        }
    }

    void PlayerTurn()
    {

    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

}
