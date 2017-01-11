using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes.UnitClasses
{
    /// <summary>
    /// Базовый класс юнита
    /// </summary>
    /*
        - оценивает позицию вокруг себя и предоставляет интерфейс для способностей и дочерних классов потомков
        - интерфейс перемещения
        - какие-то переменные и какие-то функции
        - функция респауна
        - функция получения урона / функция получения хила
        - список баффов
        - функция получения баффа
        - функция смерти
        - функция трассировки действий
        - 
    */ 

    class Unit
    {
        protected float hitpoints;
        protected float maxHitpoints;
        protected Transform target;
        protected bool isDead;            //суровая реальность
        protected bool IsMoving;

        /*  недостижимый идеал
        protected enum Statuses 
        {
             IsDead = 0,
             IsMoving = 1
        }
        */
        protected void GetDamage (float  value)
        {
            hitpoints -= value;
            if(hitpoints <=0)
            {
                Death();
            }
        }

        protected void GetHeal (float value)
        {
            hitpoints = Mathf.Clamp(hitpoints + value, 0, maxHitpoints);
        }

        protected void Death()
        {
            //Convert.ToInt32(Statuses.IsDead);
            //Console.WriteLine(Statuses.IsDead); 
        }

        /*
        private enum roleType  //хз пока как реализовать и куда пихнуть эту переменную, тут пускай пока полежит
        {
            Offence = 0,
            Defence = 1,
            Tank = 2,
            Support = 4
        };*/
        

    }
}
