using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodePanel : MonoBehaviour
{

    [SerializeField]
    Text codeText;
    
    string CodeTextValue = "";
    
    
    
    // Update is called once per frame
    void Update()
    {
        codeText.text = CodeTextValue;

        if(CodeTextValue == "9898")
        {
            SceneManager.LoadScene("EndScene");
            Time.timeScale = 1f;
            Debug.Log("isopened");
        }

        if(CodeTextValue.Length >= 4)
        {
            CodeTextValue = "";
            
        }
        
    }


   public void AddDigit(string digit)
    {
        CodeTextValue += digit;
    }
}
