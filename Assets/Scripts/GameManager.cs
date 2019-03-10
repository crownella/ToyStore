using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    


    public Transform spawn;
    public bool computer;
    public float cash;


    

    
    //time
    public int day;
    public int hours;
    public int minutes;
    public int seconds;
    public Text dayT;
    public Text hoursT;
    public Text minutesT;
    public Text secondsT;

    public int timer;
    public int timerMod;

    public bool itemOrdered = true;
    public List<GameObject> orderedItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        
        DontDestroyOnLoad(this);
        cash = 20.00f;
        day = 1;
        hours = 12;
        minutes = 0;
        seconds = 0;



    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (SceneManager.GetActiveScene().name == "Computer")
        {
            computer = true;
        }
        else
        {
            computer = false;
            
        }

        if (timer >= timerMod)
        {
            Clock();
            timer = 0;
           
        }

        //dayT.text = day.ToString();
        //hoursT.text = hours.ToString();
        //minutesT.text = minutes.ToString();
        //secondsT.text = seconds.ToString();
        


    }

    public void OpenPackage(GameObject Package)
    {
        /*
        pM = Package.GetComponent<PackageManager>();
        spawn = Package.transform;
        Destroy(Package);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
        */
    }


    public void Clock()
    {
        if (hours == 25)
        {
            hours = 0;
            day += 1;
        }
        if (minutes == 61)
        {
            minutes = 0;
            hours += 1;
        }

        if (seconds == 61)
        {
            seconds = 0;
            minutes += 1;
        }

        seconds += 1;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
        computer = false;
    }
}
