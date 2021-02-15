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

    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.enabled = false;
        textBox.enabled = false;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueText.enabled = true;
        textBox.enabled = true;
        nameText.text = dialogue.name;
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
        }
    }
    void EndDialogue()
    {
        Debug.Log("End");
        dialogueText.enabled = false;
        nameText.enabled = false;
        textBox.enabled = false;
        count = 0;
    }
    // Update is called once per frame
    
}
