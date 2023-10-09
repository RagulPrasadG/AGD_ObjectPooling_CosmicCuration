using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void Configure(VFXType type, Vector2 spawnPosition)
        {
            vfxView.gameObject.SetActive(true);
            vfxView.transform.position = spawnPosition;
            foreach(var vfxData in vfxView.vfxList)
            {
                if (vfxData.type == type)
                {
                    vfxView.particleEffect = vfxData.particleSystem;
                    vfxView.particleEffect.gameObject.SetActive(true);
                    vfxView.particleEffect.Play();
                }                           
            }
        }

        public void OnVfxComplete()
        {
            GameService.Instance.GetVFXService().ReturnVFXToPool(this);
            vfxView.particleEffect.gameObject.SetActive(false);
            vfxView.gameObject.SetActive(false);

        }

    } 
}