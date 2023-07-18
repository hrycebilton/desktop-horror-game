using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI displayText, btnText;

    public AudioSource source;
    public AudioClip clip;
    public Image transition;
    public Color img;

    private bool canSkip = true;
    private bool canTransition = false;

    public int alpha;

    public float max, min;
    public float speed = .07f;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Debug.Log("No data.");
            EndDialogue();
            return;
        }
        else
        {
            btnText.text = "Skip Typing";
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(speed);
            source.PlayOneShot(clip);
        }
        EndDialogue();
    }

    IEnumerator TransitionScenes()
    {
        canTransition = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Startup");

    }

    public void SkipOrContinue()
    {
        if (canSkip)
        {
            speed = -10;
            source.volume = 0f;
        }
        if (!canSkip)
        {
            StartCoroutine(TransitionScenes());
        }

    }

    void Update()
    {
        source.pitch = Random.Range(min, max);
        transition.color = img;

        if (canTransition && img.a < 1)
        {
            img.a += 0.1f;
        }
    }

    void EndDialogue()
    {
        canSkip = false;
        btnText.text = "Continue";
    }
}
