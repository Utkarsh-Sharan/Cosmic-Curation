using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private BulletPool bulletPool;
        private PlayerController playerController;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            bulletPool = new BulletPool(bulletPrefab, bulletScriptableObject);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPool);
        }

        public PlayerController GetPlayerController() => playerController;

        public void ReturnBulletToPool(BulletController returnedBullet) => bulletPool.ReturnToBulletPool(returnedBullet);

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();
        
    } 
}