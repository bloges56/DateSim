using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void inRange();
    public abstract void interact();
    public abstract void outOfRange();
    public abstract void exitInteract();

}
