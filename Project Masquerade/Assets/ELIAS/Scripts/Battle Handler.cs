using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleHandler : MonoBehaviour
{
    private static BattleHandler instance;

    public static BattleHandler GetInstance()
    {
        return instance;
    }


    [SerializeField] private Transform pfCharacterBattle;

    private CharacterBattle playerCharacterBattle;
    private CharacterBattle enemyCharacterBattle;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        playerCharacterBattle = SpawnCharacter(true);
        enemyCharacterBattle = SpawnCharacter(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             
        }
    }

    private CharacterBattle SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-7, 0);
        }
        else
        {
            position = new Vector3(+7, 0);
        }
            Transform characterTransform = Instantiate(pfCharacterBattle, position, Quaternion.identity);
            CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
            
            return characterBattle;
    }
}
