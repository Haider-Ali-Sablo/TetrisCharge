using UnityEngine;
using Lofelt.NiceVibrations;
namespace Sablo.Gameplay.LevelProgress
{
    public class SfxController : BaseGameplayModule, ISfxController
    {
        //   For click/pick any object
        float Amplitude = 0.3f;
        float Duration = 0.02f;
        //Type = Light Impact

        //For collection/park/place etc
        float C_Amplitude = 0.5f;
        float C_Duration = 0.017f;
        //Type = Light Impact.
        
        public AudioClip PlugInSfx;
        public AudioClip LevelCompleteSfx;
        public AudioClip BatteryCellAddedSfx;
        public AudioClip BatteryCellRemovedSfx;

        public ParticleSystem confetti;

        private AudioSource audioSource => GetComponent<AudioSource>();

        void ISfxController.PlayPlugInSfx()
        {
            audioSource.PlayOneShot(PlugInSfx);
            TriggerHapticFeedback(C_Amplitude, 1, C_Duration);
        }

        void ISfxController.PlayBatteryCellAddedSfx()
        {
            audioSource.PlayOneShot(BatteryCellAddedSfx);
            TriggerHapticFeedback(C_Amplitude, 1, C_Duration);
        }

        void ISfxController.PlayBatteryCellRemovedSfx()
        {
            audioSource.PlayOneShot(BatteryCellRemovedSfx);
        }

        void ISfxController.PlayLevelCompleteSfx()
        {
            audioSource.PlayOneShot(LevelCompleteSfx);
            //confetti.Play();
        }

        public void TriggerHapticFeedback(float amplitude, float frequency, float duration)
        {
            HapticController.fallbackPreset = HapticPatterns.PresetType.LightImpact;
            HapticPatterns.PlayConstant(amplitude, frequency, duration);
        }

        //SoundManager.instance?.TriggerHapticFeedback(0.5f, 1f, 0.017f); //On Item Drop
    }
}
