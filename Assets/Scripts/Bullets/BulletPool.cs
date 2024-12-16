using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets 
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if(pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.IsUsed);

                if(pooledBullet != null)
                {
                    pooledBullet.IsUsed = true;
                    return pooledBullet.Bullet;
                }
            }

            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.IsUsed = true;
            pooledBullets.Add(pooledBullet);

            return pooledBullet.Bullet;
        }

        public void ReturnToBulletPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => item.Bullet.Equals(returnedBullet));
            pooledBullet.IsUsed = false;
        }

        public class PooledBullet 
        {
            public BulletController Bullet;
            public bool IsUsed;
        }
    }
}