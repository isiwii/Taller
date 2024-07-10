using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject Question;
    public GameObject Text;

    

    // Start is called before the first frame update
    void Start()
    {
        Question.SetActive(false);
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
          if(Input.GetKeyDown(interactKey))
          {
            Text.SetActive(false);
            Text.SetActive(true);
          }  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
            Question.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player not in range");
            Question.SetActive(false);
        }
    }
}
