using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BNG
{
    public class PlanetManager : MonoBehaviour
    {
        // Scaling variables
        public Vector3 origScale;
            public float[] scaleFactor;

        // Variables for matching
        public GameObject attachedObject;                   // Stores the attached object, for referencingin this script
            public int matchIndex;                          // Set individually the inspector for each copy of the orbit

        public Animator orbitParent;                      // Null object animator for activating an orbit
        public GameObject attachmentMesh;                   // Visual element to be disabled on match

        // Sound effects for matching
        public AudioSource orbitAudio;                      // Audiosource attached to attachment mesh
            public AudioClip matchSound;                        // Match SFX
            public AudioClip misMatchSound;                     // Mismatch SFX

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setObject()
        {

            // Grabs the object attached and assigns it
            attachedObject = this.gameObject.transform.GetChild(1).gameObject;

            // Sets relative scale according to attached object
            if (attachedObject.transform.name == "1. Mercury")
            {
                this.GetComponent<SnapZone>().ScaleItem = scaleFactor[0];
                    matchCheck(0);
            }

                else if (attachedObject.transform.name == "2. Venus")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[1];
                        matchCheck(1);
                }

                else if (attachedObject.transform.name == "3. Earth")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[2];
                        matchCheck(2);
                }

                else if (attachedObject.transform.name == "4. Mars")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[3];
                        matchCheck(3);            
                }

                else if (attachedObject.transform.name == "5. Jupiter")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[4];
                        matchCheck(4);            
                }

                else if (attachedObject.transform.name == "6. Saturn")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[5];
                        matchCheck(5);
                }

                else if (attachedObject.transform.name == "7. Uranus")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[6];
                        matchCheck(6);
                }

                else if (attachedObject.transform.name == "8. Neptune")
                {
                    this.GetComponent<SnapZone>().ScaleItem = scaleFactor[7];
                        matchCheck(7);
                }

                    else { this.GetComponent<SnapZone>().ScaleItem = 1; }

            // Checks to see if the attached object matches the snap point

        }

        public void matchCheck(int planetIndex)
        {
            if (planetIndex == matchIndex)
            {
                // Play the match sound
                orbitAudio.PlayOneShot(matchSound);

                // Hides the attachment mesh
                attachmentMesh.SetActive(false);

                // Activate the orbit state
                orbitParent.SetTrigger("OrbitMatch");
            }

            else
            {
                // Play the mismatch sound
                orbitAudio.PlayOneShot(misMatchSound);
            }
        }

        public void resetScale()
        {
            attachedObject.transform.localScale = origScale;
        }
    }
}
