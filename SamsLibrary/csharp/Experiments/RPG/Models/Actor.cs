using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.RPG.Models
{
    public enum ActorType
    {
        Humanoid = 0,
        Undead = 1,
        Beast = 2,
        Demon = 3,

        Projectile = 98,
        Inanimate = 99
    }

    public abstract class Actor : GameObject
    {
        private double _maxHealth;
        public double MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
            }
        }

        private double _health;
        public double Health
        {
            get { return _health; }
            set
            {
                _health = value;
            }
        }

        private void RestoreHealth(double healAmount)
        {
            if (Health + healAmount >= MaxHealth)
                Health = MaxHealth;
            else if (Health > 0)
                Health = Health + healAmount;
        }
        private void TakeDamage(double damageAmount)
        {
            if (Health - damageAmount <= 0)
                Health = 0;
            else 
                Health = Health - damageAmount;

            CheckDeath(Health);
        }
        private void CheckDeath(double health)
        {
            if (health <= 0.0 && CanDie && !IsInvulnerable)
            {
                IsAlive = false;
                IsMobile = false;
            }
        }

        private double _baseDamageReduction;
        public double BaseDamageReduction { get; set; }

        private double _baseSpeed = 0.0;
        public double BaseSpeed { get; set; }

        private double _MaxSpeed = 0.0;
        public double MaxSpeed { get; set; }

        private bool _isMobile = true;
        public bool IsMobile { get; set; }

        private bool _isAlive;
        public bool IsAlive { get; set; }

        private bool _isInvulnerable = false;
        public bool IsInvulnerable { get; set; }

        private bool _canDie = true;
        public bool CanDie { get; set; }

        private bool _isDead;
        public bool IsDead { get { return !IsAlive; } }



        public Actor()
        {

        }

    }
}
