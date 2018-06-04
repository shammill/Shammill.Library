using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.RPG.Models
{
    interface IActor : IGameObject
    {

    }

    public enum ActorType
    {
        Humanoid = 0,
        Undead = 1,
        Beast = 2,
        Demon = 3,
        Inanimate = 99
    }

    public abstract class Actor : IActor
    {
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
            Health = Health + healAmount;
        }
        private void TakeDamage(double damageAmount)
        {
            Health = Health - damageAmount;
            CheckDeath(Health);
        }
        private void CheckDeath(double health)
        {
            if (health <= 0.0)
            {
                IsAlive = false;
            }
        }

        private double _damageReduction;
        public double DamageReduction { get; set; }

        private double _speed;
        public double Speed { get; set; }

        private bool _isMobile;
        public bool IsMobile { get; set; }

        private bool _isAlive;
        public bool IsAlive { get; set; }

        private bool _isInvulnerable;
        public bool IsInvulnerable { get; set; }

        private bool _canDie;
        public bool CanDie { get; set; }

        private bool _isDead;
        public bool IsDead { get { return !IsAlive; } }



        public Actor()
        {

        }

    }
}
