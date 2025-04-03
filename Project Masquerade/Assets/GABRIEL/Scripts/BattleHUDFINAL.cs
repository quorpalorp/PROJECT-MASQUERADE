using UnityEngine;
using UnityEngine.UI;

public class BattleHUDFINAL : MonoBehaviour
{


    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Image healthBar;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;

    }
}
