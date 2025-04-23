using UnityEngine;
using UnityEngine.UI;

public class UnitFINAL : MonoBehaviour
{
    //this is the latest copy of the Unit script by gabriel
    //dont use the one in elias's folder thats outdated
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;
    public int Defense;
    public int maxAP;
    public int currentAP;

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

    public void Heal(int fillAmount)
    {
        currentHP += fillAmount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void Block(int amount)
    {
        int actualBlock = Mathf.Clamp(amount, 0, Defense);
        Defense -= actualBlock;
    }

    public void Setdefense()
    {
        cantakedamage = false;
    }

    public void ResetDefense()
    {
        cantakedamage = true;
    }
}