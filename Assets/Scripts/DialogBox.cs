using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    bool show = true;
    private Text uiText;
    private bool writing = false;
    private int currentText = 0;
    private int currentDialog;
    private Animator anim;

    [SerializeField] private float timeToNext;

    public string[] texts;
    public int[] dialogEnd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        uiText = GetComponentInChildren<Text>();
    }

    IEnumerator showText()
    {
        uiText.text = "";
        writing = true;
        foreach (char c in texts[currentText])
        {
            yield return new WaitForSeconds(timeToNext);
            if(writing)
                uiText.text += c;
        }
        writing = false;
    }

    public void showAllText()
    {
        if(writing)
        {
            StopCoroutine(showText());
            uiText.text = texts[currentText];
            writing = false;
        }else{
            if(currentText < texts.Length - 1 && currentText < dialogEnd[currentDialog]) {
                currentText++;
                uiText.text = "";
                StartCoroutine(showText());
            }
            else
            {
                setShow(false);
            }
        }
    }

    public void setShow(bool b)
    {
        show = b;
        anim.SetBool("up", show);
        if (b)
        {
            StartCoroutine(showText());
        }else
        {
            changeDialog();
        }
    }

    private void changeDialog()
    {
        if(currentDialog < dialogEnd.Length - 1)
        {
            currentDialog++;
        }
        if(currentText < texts.Length - 1)
        {
            currentText++;
        }
    }

}