using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool driving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (driving == true)
            {
                SceneManager.LoadScene("MainScene");
                driving = false;
            }
            else
            {
                SceneManager.LoadScene("Driving");
                driving = true;
            }
        }
        
        
    }
}
