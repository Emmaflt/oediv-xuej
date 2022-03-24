using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogTrigger : MonoBehaviour
{
    public DialogQueue dialogQueue;
    public bool dialogStart = true;

    void Update()
    {
        if (dialogStart)
        {
            TriggerDialog();
            dialogStart = false;
        }
    }

    void TriggerDialog()
    {
        DialogManager.instance.StartDialog(dialogQueue);
    }
}
