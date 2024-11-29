using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXGraphController : MonoBehaviour
{
    [System.Serializable]
    public class VFXKeyBinding
    {
        public KeyCode key;        // The key to trigger the VFX
        public VisualEffect vfx;  // The associated VisualEffect
    }

    [Header("Key Bindings")]
    public List<VFXKeyBinding> keyBindings;

    private void Update()
    {
        foreach (var binding in keyBindings)
        {
            if (Input.GetKeyDown(binding.key) && binding.vfx != null)
            {
                PlayVFX(binding.vfx);
            }
        }
    }

    private void PlayVFX(VisualEffect vfx)
    {
        vfx.Stop();  // Ensure the effect is reset
        vfx.Play();  // Start the effect
    }
}
