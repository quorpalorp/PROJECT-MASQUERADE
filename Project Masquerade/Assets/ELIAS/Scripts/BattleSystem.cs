using System.Collections;
using UnityEngine;

public enum BattleState {  START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject PCharacterPrefab;
    public GameObject enemyPrefab;

    public Transform PCharacterBattleStation;
    public Transform enemyBattleStation;

    
    public BattleState state; 

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle()); 
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(PCharacterPrefab, PCharacterBattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
       
        yield return new WaitForSeconds(2f); 

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2f);
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
