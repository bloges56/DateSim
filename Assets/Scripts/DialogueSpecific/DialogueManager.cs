using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{   
    public class DialogueCharacter {
        public string charName;
        public int relationshipProgress;

        public DialogueCharacter(string charName, int relationshipProgress) {
            this.charName = charName;
            this.relationshipProgress = relationshipProgress;
        }

    }

    public string activeCharacter;
    public DialogueCharacter Deon;
    public DialogueCharacter activeDialogue;

    public void changeRelationship(DialogueCharacter character, int change) {
        character.relationshipProgress += change;
    }

    public void changeActive(string activeCharacter) {
        this.activeCharacter = activeCharacter;
    }

    // Start is called before the first frame update
    void Start()
    {
        Deon = new DialogueCharacter("Deon", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
