using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool dialogStart = true;

    void Update()
    {
        if (dialogStart)
        {
            TriggerDialogue();
            dialogStart = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
