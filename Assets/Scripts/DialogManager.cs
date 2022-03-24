using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public static DialogManager instance;
    public Text nameText;
    public Text dialogText;

    private Queue<string> sentences;
    public GameObject dialogBox;
    public bool dialogWorking = false;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialog(DialogQueue dialog)
    {
        dialogWorking = true;
        dialogBox.SetActive(true);

        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialog()
    {
        dialogBox.SetActive(false);
        dialogWorking = false;
    }
}