using System;
using System.IO.Compression;

namespace Napilnik
{
    class Program
    {

        private const int PlayerHealth = 100;
        private const int WeaponDamage = 20;
        private const int MaxWeaponAmmo = 10;
        private const int BulletsPerShot = 1;

        static void Main(string[] args)
        {
            var player = new Player(PlayerHealth);
            var weapon = new Weapon(WeaponDamage, MaxWeaponAmmo, BulletsPerShot);
            var bot = new Bot(weapon);
            bot.OnSeePlayer(player);
        }
    }

    public class Weapon
    {
        public readonly int Damage;
        public readonly int MaxAmmo;
        public readonly int BulletsPerShot;
        public int Ammo { get; private set; }

        public event Action OnFired;

        public Weapon(int damage, int maxAmmo, int bulletsPerShot)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (maxAmmo <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxAmmo));

            if (bulletsPerShot <= 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            Damage = damage;
            Ammo = maxAmmo;
            MaxAmmo = maxAmmo;
            BulletsPerShot = bulletsPerShot;
        }

        public void Fire(IDamageable damageable)
        {
            if (!CanFire())
            {
                throw new InvalidOperationException();
            }

            damageable.TakeDamage(Damage);
            Ammo -= BulletsPerShot;

            OnFired?.Invoke();
        }

        public void Reload()
        {
            Ammo = MaxAmmo;
        }

        public bool CanFire()
        {
            return Ammo - BulletsPerShot > 0;
        }
    }

    public class Player : IDamageable
    {
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }

        public Player(float maxHealth)
        {
            if (maxHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHealth));
            }

            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            Health = Math.Clamp(Health - damage, 0, MaxHealth);
        }
    }

    public class Bot
    {
        public readonly Weapon Weapon;

        public Bot(Weapon weapon)
        {
            if (Weapon == null)
            {
                throw new ArgumentNullException(nameof(weapon));
            }

            Weapon = weapon;
        }

        public void OnSeePlayer(IDamageable damageable)
        {
            if (damageable == null)
            {
                throw new ArgumentNullException(nameof(damageable));
            }

            if (Weapon.CanFire())
            {
                Weapon.Fire(damageable);
            }
            else
            {
                Weapon.Reload();
            }
        }
    }

    public interface IDamageable
    {
        public void TakeDamage(float damage);
    }
}