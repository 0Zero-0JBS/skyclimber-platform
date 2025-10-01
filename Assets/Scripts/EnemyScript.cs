using UnityEditor.Build;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Set this to the computer
    public PlayerMove playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Enemy says: The player has " + playerMove.lives + "lives ");
    }
}
