using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlanetManager_v2 : MonoBehaviour
    {

    // Variables for matching
    public GameObject attachedObject;                   // Stores the attached object, for referencing in this script
    public int matchIndex;                          // Set individually the inspector for each copy of the orbit
    public bool[] matchBool;                                // Keeps track of matches for the purposes of activating end state animations

    public GameObject[] orbitSnaps;                     // Array of snap points on orbits
    public GameObject[] planetPrefabs;                  // Array of planet prefabs
    public int[] attachedPlanet;                        // Array of ints for keeping track of planet attachment

    public Animator sunParent;                          // Null object animator for activating Sun
    public Animator[] orbitRotParent;                      // Null object animator for activating orbit rotation
    public Animator[] orbitActParent;                      // Null object animator for placing orbits
    public Animator[] planetRotParent;                      // Null object for rotating planets

    public GameObject[] attachmentMesh;                   // Visual element to be disabled on match

    // Sound effects for matching
    public AudioSource[] orbitAudio;                      // Audiosource attached to attachment mesh
    public AudioClip matchSound;                        // Match SFX
    public AudioClip misMatchSound;                     // Mismatch SFX

    // UI Elements that change on level clear
    public GameObject mainPanel;
        public GameObject[] bottomPanels;

    public void setObject(int snapIndex)
    {
        // Grabs the object attached and assigns it
        attachedObject = orbitSnaps[snapIndex].transform.GetChild(1).gameObject;

        // Sets the index of the attached planet to the snap index
        if (attachedObject.transform.name == "1. Mercury") { attachedPlanet[snapIndex] = 0; }

            else if (attachedObject.transform.name == "2. Venus") { attachedPlanet[snapIndex] = 1; }

            else if (attachedObject.transform.name == "3. Earth") { attachedPlanet[snapIndex] = 2; }

            else if (attachedObject.transform.name == "4. Mars") { attachedPlanet[snapIndex] = 3; }

            else if (attachedObject.transform.name == "5. Jupiter") { attachedPlanet[snapIndex] = 4; }

            else if (attachedObject.transform.name == "6. Saturn") { attachedPlanet[snapIndex] = 5; }

            else if (attachedObject.transform.name == "7. Uranus") { attachedPlanet[snapIndex] = 6; }

            else if (attachedObject.transform.name == "8. Neptune") { attachedPlanet[snapIndex] = 7; }

        // Error value if any other object is attached
        else { attachedPlanet[snapIndex] = -1; }

        // Checks to see if the attached object matches the snap point
        matchCheck(snapIndex);

    }

    public void matchCheck(int snapIndex)
    {
        if (attachedPlanet[snapIndex] == snapIndex)
        {
            // Play the match sound
            orbitAudio[snapIndex].PlayOneShot(matchSound);

            // Hides the attachment mesh
            attachmentMesh[snapIndex].SetActive(false);

            // Prepares the orbit state
            orbitRotParent[snapIndex].SetTrigger("OrbitMatch");
            planetRotParent[snapIndex].SetTrigger("OrbitMatch");

            // Sets the match bool accordingly
            matchBool[snapIndex] = true;

            // Checks if we have all matches
            int tempCount = 0;                                          // Temp value for counting match number

            for (int i = 0; i < matchBool.Length; i++)
            {
                // If there are any true values, we count up
                if (matchBool[i] == true) { tempCount++; }
            }

            // Activate final animations if we have all matches
            if (tempCount >= 8)
            {
                sunParent.SetTrigger("PuzzleComplete");                            // Sun moves into place

                for (int i = 0; i < matchBool.Length; i++)
                {
                    orbitRotParent[i].SetTrigger("Activate");              // Planets start orbiting
                    orbitActParent[i].SetTrigger("Ascend");                // Planets move into place

                }

                mainPanel.SetActive(false);

                for (int i = 0; i < bottomPanels.Length; i++)
                {
                    bottomPanels[i].SetActive(true);
                }
            }
        }

        else
        {
            // Play the mismatch sound
            orbitAudio[snapIndex].PlayOneShot(misMatchSound);
        }
    }

    public void removeObject(int snapIndex)
    {
        // Resets appropriate variables
        attachedPlanet[snapIndex] = -1;

        matchBool[snapIndex] = false;

        attachedObject = null;

    }
}
