using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HandleInputData : MonoBehaviour
{

    [SerializeField] GameObject Play;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject Instructions;
    [SerializeField] private Dropdown Drop;


    // Start is called before the first frame update
    void Start()
    {
        Play = GameObject.FindGameObjectWithTag("Play");
        MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        Instructions = GameObject.FindGameObjectWithTag("Instructions");

        Play.SetActive(false);
        MainMenu.SetActive(false);
        Instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Handle(Drop);
    }

    public void Handle(Dropdown val)
    {
        if (val.value == 0){
            Play.SetActive(false);
            MainMenu.SetActive(false);
            Instructions.SetActive(false);
        }
        if (val.value == 1){
            Play.SetActive(true);
            MainMenu.SetActive(false);
            Instructions.SetActive(false);
        }
        if (val.value == 2){
            MainMenu.SetActive(true);
            Play.SetActive(false);
            Instructions.SetActive(false);
        }
        if (val.value == 3){
            Instructions.SetActive(true);
            Play.SetActive(false);
            MainMenu.SetActive(false);
        }

    }
}
