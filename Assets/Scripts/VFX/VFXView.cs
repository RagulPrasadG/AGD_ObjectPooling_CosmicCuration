using UnityEngine;
using System.Collections.Generic;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        public ParticleSystem particleEffect { get; set; }
        public List<VFXData> vfxList;
  
        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        //public void ConfigureAndPlay(VFXType vfxType,Vector2 positionToSet)
        //{

        //    transform.position = positionToSet;
        //    VFXData vfxData = vfxList.Find(vfx => vfx.type == vfxType);
        //    particleEffect = vfxData.particleSystem;
        //    particleEffect.gameObject.SetActive(true);
        //    particleEffect.Play();
      
        //}

        private void Update()
        {
            if (particleEffect != null && particleEffect.isStopped)
            {
                controller.OnVfxComplete();
            }
               
        }
    }
}