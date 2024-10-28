using UnityEngine;
using System.Collections; // Ensure we can use IEnumerator

namespace Unity.AI.Navigation.Samples
{
    public class Oscillator : MonoBehaviour
    {
        public float m_Amplitude = 1.0f; // Amplitude of the oscillation
        public float m_Period = 1.0f;     // Period of the oscillation
        public Vector3 m_Direction = Vector3.up; // Direction of the oscillation
        public float m_MaxRandomStartDelay = 5f; // Maximum random delay before oscillation starts
        public float m_MaxRandomStopDelay = 5f; // Maximum random delay before oscillation stops

        private Vector3 m_StartPosition;   // Starting position of the object
        private bool m_IsMoving = false;   // Flag to check if the object is oscillating

        void Start()
        {
            m_StartPosition = transform.position;
            StartCoroutine(OscillationRoutine());
        }

        void Update()
        {
            if (m_IsMoving)
            {
                // Calculate the new position using the oscillation formula
                float oscillationValue = Mathf.Sin(2.0f * Mathf.PI * Time.time / m_Period);
                var pos = m_StartPosition + m_Direction * m_Amplitude * oscillationValue;
                transform.position = pos;

                // Optional: Debugging log
                Debug.Log($"Current Position: {transform.position}");
            }
        }

        private IEnumerator OscillationRoutine()
        {
            while (true) // Continuous loop for start/stop
            {
                // Wait for a random amount of time before starting to move
                float startDelay = Random.Range(0f, m_MaxRandomStartDelay);
                yield return new WaitForSeconds(startDelay);

                m_IsMoving = true; // Start oscillating

                // Wait for a random amount of time while oscillating
                float stopDelay = Random.Range(0f, m_MaxRandomStopDelay);
                yield return new WaitForSeconds(stopDelay);

                m_IsMoving = false; // Stop oscillating
            }
        }
    }
}
