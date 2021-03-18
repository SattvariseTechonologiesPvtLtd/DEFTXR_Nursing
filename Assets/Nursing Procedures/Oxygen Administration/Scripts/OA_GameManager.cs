using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace HandsOnVR
{
    public class OA_GameManager : MonoBehaviour
    {

        // list of the audioclips required
        [SerializeField]
        private List<AudioClip> intro_VO;

        // Actions referencing Actions to be completed by user
        [SerializeField]
        private bool[] ActionsCompleted = { false };

        // Guides referencing Guide Animation to be displayed on each step
        [SerializeField]
        private List<GameObject> Guides;

        [SerializeField]
        private AudioSource audioSource;



        private bool grabbedOnce1 = false;
        private bool grabbedOnce2 = false;
        private bool grabbedOnce3 = false;
        private bool grabbedOnce4 = false;


        [SerializeField]
        private GameObject OxygenCylinder;
        [SerializeField]
        private GameObject TranstrachealCatheter;
        [SerializeField]
        private GameObject VenturiMask;
        [SerializeField]
        private GameObject NasalCanula;
        [SerializeField]
        private GameObject OxygenHood;
        [SerializeField]
        private GameObject NonRebreatherMask;
        [SerializeField]
        private GameObject FaceTent;

        public Text debugText;
        // Start is called before the first frame update
        void Start()
        {
            InitializeDefaultData();

            StartCoroutine(Introduction());
        }

        IEnumerator Introduction()
        {
            // Introduction
            Debug.Log("playing vo1");
            audioSource.PlayOneShot(intro_VO[0]);
            yield return new WaitForSeconds(intro_VO[0].length);

            audioSource.PlayOneShot(intro_VO[1]);
            yield return new WaitForSeconds(intro_VO[1].length);

            Debug.Log("playing vo2");
            audioSource.PlayOneShot(intro_VO[2]);
            yield return new WaitForSeconds(intro_VO[2].length);
            yield return new WaitForSeconds(4f);

            audioSource.PlayOneShot(intro_VO[3]);
            yield return new WaitForSeconds(intro_VO[3].length);
            yield return new WaitForSeconds(3f);

            //Show Apparatus
            audioSource.PlayOneShot(intro_VO[4]);
            yield return new WaitForSeconds(intro_VO[4].length);
            yield return new WaitForSeconds(4f);
              

        }
        

        // Update is called once per frame
        void Update()
        {
            
            if (GetComponent<GrabAttacher>().GrabbedBody == NonRebreatherMask)

            {
                debugText.text = "Inside If";
            }

            


        }
       
        
        void InitializeDefaultData()
        {
            // Disable all models
            //patient.SetActive(false);

            for (int i = 0; i < Guides.Count; i++)
            {
                Guides[i].SetActive(false);
            }

            // 1) Disable all Box Colliders to avoid getting grabbed.
            OxygenCylinder.GetComponent<BoxCollider>().enabled = false;
            FaceTent.GetComponent<BoxCollider>().enabled = false;
            NonRebreatherMask.GetComponent<BoxCollider>().enabled = false;
            TranstrachealCatheter.GetComponent<BoxCollider>().enabled = false;
            NasalCanula.GetComponent<BoxCollider>().enabled = false;
            OxygenHood.GetComponent<BoxCollider>().enabled = false;

            OxygenCylinder.GetComponent<Rigidbody>().useGravity = false;
            NonRebreatherMask.GetComponent<Rigidbody>().useGravity = false;
            TranstrachealCatheter.GetComponent<Rigidbody>().useGravity = false;
            NasalCanula.GetComponent<Rigidbody>().useGravity = false;
            OxygenHood.GetComponent<Rigidbody>().useGravity = false;






        }

    }
}
