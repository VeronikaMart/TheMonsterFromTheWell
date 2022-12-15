using Cinemachine;
using System.Collections;
using UnityEngine;

namespace TheMonsterFromTheWell.Misc
{
    public class CinemachineShake : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float amplitudeGain = 5f;
        private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

        private void Awake()
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void ShakeCamera(float time)
        {
            if (ReferenceEquals(virtualCamera, null))
                return;

            virtualCameraNoise.m_AmplitudeGain = amplitudeGain;
            StartCoroutine(DecreaseAmplitude(time));
        }

        IEnumerator DecreaseAmplitude(float time)
        {
            yield return new WaitForSeconds(time);
            virtualCameraNoise.m_AmplitudeGain = 0f;
        }
    }
}