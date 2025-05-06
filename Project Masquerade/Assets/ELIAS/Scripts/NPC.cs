using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMesh dialogueTextMesh;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }


    public void zeroText()
    {
        dialogueTextMesh.text = " ";
        index = 0;
        dialoguePanel.SetActive(false);
    }


    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueTextMesh.text += letter;    
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueTextMesh.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
