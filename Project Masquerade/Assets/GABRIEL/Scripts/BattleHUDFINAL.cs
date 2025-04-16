using UnityEngine;
using UnityEngine.UI;

public class BattleHUDFINAL : MonoBehaviour
{
    //this is the latest copy of the BattleHUD script by gabriel
    //dont use the one in elias's folder thats outdated

    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Image healthBar;

    public void SetHUD(UnitFINAL unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        healthBar.fillAmount = unit.currentHP / unit.maxHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        healthBar.fillAmount = hp;
    }
}
