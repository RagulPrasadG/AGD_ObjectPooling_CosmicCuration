using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledbullets;

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
            pooledbullets = new List<PooledBullet>();
        }
        public BulletController GetBullet()
        {
            if(pooledbullets.Count > 0 )
            {
                PooledBullet pooledBullet = pooledbullets.Find(pooledBullet => !pooledBullet.isUsed);
                if(pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bulletController;
                }
            }
            return CreatePooledBullet();
        }

        public BulletController CreatePooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            return pooledBullet.bulletController;
        }

        public class PooledBullet
        {
            public BulletController bulletController;
            public bool isUsed;
        }


    }
}


