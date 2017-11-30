using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool inAction = false;

    private List<Action> possibleActions;
    // Use this for initialization
    void Awake()
    {
        possibleActions = new List<Action>(GetComponents<Action>());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Action action in possibleActions)
        {
            if (Input.GetKeyDown(action.control))
            {
                inAction = true;

            }
            else if (Input.GetKey(action.control))
            {

            }
        }
    }
}
