using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    [SerializeField] new AudioSource audio;
    [SerializeField] GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
         if (balloon == null)
        {
            balloon = GameObject.FindGameObjectWithTag("Balloon");
        }
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D (Collider2D collider)
    {
        Debug.Log(collider.name);
        

        if(collider.tag == "Balloon" ){

            Destroy(collider.gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<ScoreKeeper>().AddPoints();
            Destroy(gameObject);
            
            
        }
        else if(collider.name == "TopWall"){
            Destroy(gameObject);
        }

        
    }
}
