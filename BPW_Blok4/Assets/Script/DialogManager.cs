using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool BoxActive;
    

    public string[] dialogLines;

    public int currentLine;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoxActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }



        if (currentLine >= dialogLines.Length)
        {
           dialogBox.SetActive(false);
           BoxActive = false;
            currentLine = 0;
        }

        dialogText.text = dialogLines[currentLine];

    }


  

    public void ShowDialog()
    {
        BoxActive = true;
        dialogBox.SetActive(true);
    }
}

