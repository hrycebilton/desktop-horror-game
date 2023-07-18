using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dm;

    public void TriggerDialogue()
    {
        dm.StartDialogue(dialogue);
    }

    IEnumerator StartTyping()
    {
        yield return new WaitForSeconds(1f);
        TriggerDialogue();
    }

    void Start()
    {
        StartCoroutine(StartTyping());
    }
}
