using UnityEditor.Build;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Set this to the computer
    public PlayerMove playerMove;
    HelperScript helper;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add the helper script and store a reference to it                                               
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        print("Enemy says: The player has " + playerMove.lives + "lives ");
        if (Input.GetKey("space"))
        {
            helper.DoFlipObject(true);    // this will execute the method in HelperScript.cs
        }

    }
}
