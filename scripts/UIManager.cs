using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


    public class UIManager : MonoBehaviour
    {
        // Variables for grabbing object info
        public GameObject grabbedObject;                   // Stores the grabbed object, for referencing in this script
            public GameObject[] consoleObjects;                     // Stores the objects currently snapped to the console

        public GameObject[] planetPrefabs;                      // Array of planet prefabs

        public GameObject[] consoleSnaps;                       // Array of snap points on planet console

        public int activePlanet;                            // Index variable for setting text

        // Text variables
        public TextMeshProUGUI titleTMP;                         // TMP text object that displays title text
            public string[] titleText;                          // Title text to be adjusted when handling planets

        public TextMeshProUGUI tutorialText;                       // TMP text object that displays tutorial text, and can be hidden

        public GameObject planetFactoids;                   // Panel for showing and hiding planet factoid text
            public TextMeshProUGUI shortDescriptTMP;                 // TMP text object for flavor text            
            [TextArea]
            public string[] shortDescriptText;              // Flavor text for each planets

        public TextMeshProUGUI[] infoTMP;                      // TMP text objects for inputing planet info
            public string[] infoText;                       // Planet-specific info

    public void grabObject(int snapIndex)
    {
        // Grabs the object stored in the array
        grabbedObject = consoleObjects[snapIndex];

        // Sets the index of the attached planet to the snap index
        if (grabbedObject.transform.name == "1. Mercury") { activePlanet = 0; }

            else if (grabbedObject.transform.name == "2. Venus") { activePlanet = 1; }

            else if (grabbedObject.transform.name == "3. Earth") { activePlanet = 2; }

            else if (grabbedObject.transform.name == "4. Mars") { activePlanet = 3; }

            else if (grabbedObject.transform.name == "5. Jupiter") { activePlanet = 4; }

            else if (grabbedObject.transform.name == "6. Saturn") { activePlanet = 5; }

            else if (grabbedObject.transform.name == "7. Uranus") { activePlanet = 6; }

            else if (grabbedObject.transform.name == "8. Neptune") { activePlanet = 7; }

        else { activePlanet = 8; }

        // Clears the array slot
        consoleObjects[snapIndex] = null;

        changeUIText();
    }

    public void setObject(int snapIndex)
    {
        // Resets appropriate variables
        grabbedObject = null;

        // Stores the placed object in the consoleObjects array
        consoleObjects[snapIndex] = consoleSnaps[snapIndex].transform.GetChild(2).gameObject;

        // Sets the index of the attached planet to the snap index
        if (grabbedObject.transform.name == "1. Mercury") { activePlanet = 0; }

            else if (grabbedObject.transform.name == "2. Venus") { activePlanet = 1; }

            else if (grabbedObject.transform.name == "3. Earth") { activePlanet = 2; }

            else if (grabbedObject.transform.name == "4. Mars") { activePlanet = 3; }

            else if (grabbedObject.transform.name == "5. Jupiter") { activePlanet = 4; }

            else if (grabbedObject.transform.name == "6. Saturn") { activePlanet = 5; }

            else if (grabbedObject.transform.name == "7. Uranus") { activePlanet = 6; }

            else if (grabbedObject.transform.name == "8. Neptune") { activePlanet = 7; }

        else { activePlanet = 8; }

        changeUIText();
    }


    public void changeUIText()
        {
            // Update the text accordingly
            titleTMP.text = titleText[activePlanet];

                // Default tutorial text is shown
                if (activePlanet == 8)
                {
                    tutorialText.gameObject.SetActive(true);

                    planetFactoids.gameObject.SetActive(false);
                }

                else
                {

                tutorialText.gameObject.SetActive(false);

                planetFactoids.gameObject.SetActive(true);

                    shortDescriptTMP.text = shortDescriptText[activePlanet];
                    // Fills in each factoid field with the relevant info from the array
                    for (int i = 0; i < 5; i++)
                    {
                        infoTMP[i].text = infoText[5 * activePlanet + i];
                    }

                }
        }  
    }
