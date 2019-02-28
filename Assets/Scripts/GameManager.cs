using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text message;
    public bool holdingObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
