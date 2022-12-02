using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonScripts : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] string curName;


    // Start is called before the first frame update
    void Start()
    {
        curName = PersistentData.Instance.GetName();
        playerNameInput.text = curName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("level 1");
    }

    public  void GoToInstructions()
    {
        
        SceneManager.LoadScene("Instructions");
    }

    public  void GoToSettings()
    {

        SceneManager.LoadScene("Settings");
    }
}
