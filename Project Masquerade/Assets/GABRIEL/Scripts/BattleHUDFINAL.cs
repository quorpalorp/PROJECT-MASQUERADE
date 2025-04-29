using UnityEngine;
using UnityEngine.UI;

public class BattleHUDFINAL : MonoBehaviour
{
    //this is the latest copy of the BattleHUD script by gabriel
    //dont use the one in elias's folder thats outdated

    public Text nameText;
    public Text levelText;
    public Image Healthbar;
    public Image APbar;

    public void SetHUD(UnitFINAL unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        Healthbar.fillAmount = unit.maxHP;
        Healthbar.fillAmount = unit.currentHP;
    }

    public void SetHP(int fillamount)
    {
        Healthbar.fillAmount = fillamount;
    }

    public void setAP(int apFill)
    {
        APbar.fillAmount = apFill;
    }
} 
      
        
     




