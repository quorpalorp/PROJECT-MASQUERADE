using System;
using UnityEditorInternal;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Character_Base characterBase;

    private void Awake()
    {
        characterBase = GetComponent<Character_Base>();
    }

    private void Start()
    {
        
    }

    public Vector3 GetPosition()
    {
        return transform.position; 
    }

    

    private void Attack(CharacterBattle targetCharacterBattle)
    {
        Vector2 attackDir = (targetCharacterBattle.GetPosition() - GetPosition()).normalized; 
    }   
}
