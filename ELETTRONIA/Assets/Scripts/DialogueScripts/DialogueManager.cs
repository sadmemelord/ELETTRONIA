using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Image textBox;
    private int count = 0;
    private bool to_start;
    private string _name;

    void Start()
    {
        to_start = true;
        dialogueText.enabled = false;
        textBox.enabled = false;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        if(to_start == true)
        {
            sentences = new Queue<string>();
            to_start = false;
        }
        
        dialogueText.enabled = true;
        textBox.enabled = true;
        _name = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        count++;
        if (count == 4) //modify whenever the number of sentences changes
        {
            EndDialogue();
            return;
        }
        else
        {
            string current_sentence = sentences.Dequeue();
            dialogueText.text = current_sentence;
            nameText.text = _name;
        }
    }
    void EndDialogue()
    {
        Debug.Log("End");
        to_start = true;
        dialogueText.enabled = false;
        nameText.enabled = false;
        textBox.enabled = false;
        count = 0;
        NPC_Behavior_FSM.end_dialogue = true;
    }
    // Update is called once per frame
    
}
