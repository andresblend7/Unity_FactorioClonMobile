using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpMessages : MonoBehaviour
{
    public TMP_Text popUpText;
    private GameObject window;
    private Animator popUpAnimator;

    private Queue<string> popUpQueue;
    private bool isActive;
    private Coroutine queueChecker;

    // Start is called before the first frame update
    void Start()
    {
        window = transform.GetChild(0).gameObject;
        popUpAnimator = window.GetComponent<Animator>();
        window.SetActive(false);
        popUpQueue = new Queue<string>();
    }


    void ShowPopUp(string text) {

        isActive = true;
        window.SetActive(true);
        popUpText.text = text;
        popUpAnimator.Play("PopUpMessage");

    }

    public void AddToQueue(string text) {

        this.popUpQueue.Enqueue(text);
        if (queueChecker == null)
            queueChecker = StartCoroutine(CheckQueue());
    }

    public IEnumerator CheckQueue() {

        do {
            ShowPopUp(popUpQueue.Dequeue());
            do
            {
                yield return null;
            } while (!popUpAnimator.GetCurrentAnimatorStateInfo(0).IsTag("idle"));
        } while (popUpQueue.Count>0);

        isActive = false;
        window.SetActive(false);
        queueChecker = null;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
