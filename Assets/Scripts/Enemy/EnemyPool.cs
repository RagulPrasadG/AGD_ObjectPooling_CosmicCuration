using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies;

        public EnemyPool(EnemyView enemyView,EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
            this.enemyData = enemyData;
            this.pooledEnemies = new List<PooledEnemy>();
        }
        public EnemyController GetEnemy()
        {
            if(pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.Find(pooledEnemy => !pooledEnemy.isUsed);
                if(pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.enemyController;
                }
            }
            return CreateEnemy();
        }

        public void ReturnEnemyToPool(EnemyController returnedEnemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(pooledEnemy => pooledEnemy.enemyController.Equals(returnedEnemy));
            pooledEnemy.isUsed = false;
        }

        public EnemyController CreateEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemyController = new EnemyController(enemyView, this.enemyData);
            pooledEnemy.isUsed = true;
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.enemyController;
        }

        public class PooledEnemy
        {
            public EnemyController enemyController;
            public bool isUsed;
        }

    }
}

