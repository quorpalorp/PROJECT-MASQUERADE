using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;
    public int Defense;

    private bool cantakedamage = true;

    public bool TakeDamage(int dmg)
    {
        if (!cantakedamage)
            return false; 

        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void Block(int amount)
    {
        int actualBlock = Mathf.Clamp(amount, 0, Defense);
        Defense -= actualBlock;
    }

    public void setdefense()
    {
        cantakedamage = false;
    }

    public void ResetDefense()
    {
        cantakedamage = true;
    }
}     