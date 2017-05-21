using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerUserControl : MonoBehaviour
    {
        public Text scoreText;

        private PlayerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private ResponsiveCharacter[] responsiveCharacters;

        private void Start()
        {
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            }

            GameObject[] pets = GameObject.FindGameObjectsWithTag("Pet");
            responsiveCharacters = new ResponsiveCharacter[pets.Length];

            for (int i = 0; i < pets.Length; i++)
            {
                responsiveCharacters[i] = pets[i].GetComponent<ResponsiveCharacter>();
            }

            m_Character = GetComponent<PlayerCharacter>();
            SetScoreText(0);
        }

        private string GetScoreText(int currentScore)
        {
            return "Score: " + currentScore;
        }

        private void SetScoreText(int currentScore)
        {
            scoreText.text = GetScoreText(currentScore);
        }

        private void Update()
        {
            int score = 0;

            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            for (int i = 0; i < responsiveCharacters.Length; i++)
            {
                score += responsiveCharacters[i].counter;
            }
            SetScoreText(score);
        }

        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
