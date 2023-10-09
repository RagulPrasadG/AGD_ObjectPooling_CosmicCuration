using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXView vfxView;
        private VFXPool vfxPool;

        public VFXService(VFXView vfxView)
        {
            this.vfxView = vfxView;
            this.vfxPool = new VFXPool(vfxView);
        }

        public void ReturnVFXToPool(VFXController vfxController) => vfxPool.ReturnItem(vfxController);

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vfxPool.GetVFX();
            vfxToPlay.Configure(type,spawnPosition);
        }

    } 
}