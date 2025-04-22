using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{


    public Text nameText;
    public Text levelText;
    

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
    }

    public void SetHP(int hp)
    {
       
    }
}
