using Unity.VisualScripting;
using UnityEngine;

public class turncounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int turn = 1;
    public TMPro.TMP_Text turnText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onTurnClick()
    {
        turn++;
        turnText.SetText("TURN - " +  turn);
    }
}
