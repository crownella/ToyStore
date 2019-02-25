using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerStart : MonoBehaviour
{
    public GameManager gM;
    public GameObject gO;

    // Start is called before the first frame update

    private void Start()
    {
    }

    private void OnMouseOver()
    {
        gM.message.text = ("Press E to turn on");
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Computer");

        }
    }

    private void OnMouseExit()
    {
        gM.message.text = ("");
    }
}
