using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IDamagable
{
    public int CurrentHP { get; set; }

    public void ApplyDamage(int damage);

}
