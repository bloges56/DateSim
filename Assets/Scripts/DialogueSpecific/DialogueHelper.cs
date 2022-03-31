using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueHelper : MonoBehaviour
{   
    public GameObject character;
    Animator animator;

    public int relationshipProgressEdit;
    private static int relationshipProgress;

    void Awake()
    {
        animator = character.GetComponent<Animator>();
        relationshipProgress = relationshipProgressEdit;

    }

    [YarnCommand("PlaySadAnim")]
    public void PlaySadAnim()
    {
        animator.SetBool("Sad", true);
    }
    [YarnCommand("StopSadAnim")]
    public void StopSadAnim()
    {
        animator.SetBool("Sad", false);
    }

    //current relationship status, 0 will be first interaction then 1, 2, 3 (dateable ending), 
    //if you lose it will go to -1, lose again -2, but if you win on -1 it goes to 2 but they aren't dateable
    [YarnFunction("ReturnRelationshipProgress")]
    public static int ReturnRelationshipProgress() {
       return relationshipProgress;
    }

}
