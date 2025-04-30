using UnityEngine;
using UnityEngine.UI;

public class UnitFINAL : MonoBehaviour
{
    //this is the latest copy of the Unit script by gabriel
    //dont use the one in elias's folder thats outdated
    public string unitName;
    public int unitLevel;

    public int damage;
    public int damageCost;
    public int heal;
    public int healCost;
    //public int block;
    //public int bleed;

    public int maxHP = 100;
    public int currentHP = 100;
    public int Defense;
    public int maxAP = 3;
    public int currentAP;
    public Image healthBarImage;

    private bool cantakedamage = true;

    void Update()
    {
        healthBarImage.fillAmount = (float)currentHP / (float)maxHP;
    }

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