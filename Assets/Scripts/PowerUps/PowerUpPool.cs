using CosmicCuration.Utilities;
using System;

namespace CosmicCuration.PowerUps
{
    public class PowerUpPool : GenericObjectPool<PowerUpController>
    {
        private PowerUpData powerupData;

        public PowerUpController GetPowerUp<T>(PowerUpData powerupData) where T : PowerUpController
        {
            this.powerupData = powerupData;
            return GetItem<T>();
        }

        protected override PowerUpController CreateItem<T>()
        {
            if(typeof(T) == typeof(Shield))
            {
                return new Shield(powerupData);
            }
            else if (typeof(T) == typeof(DoubleTurret))
            {
                return new DoubleTurret(powerupData);
            }
            else if (typeof(T) == typeof(RapidFire))
            {
                return new RapidFire(powerupData);
            }

            throw new NotSupportedException("Powerup type not supported!");
        }
    }
}
