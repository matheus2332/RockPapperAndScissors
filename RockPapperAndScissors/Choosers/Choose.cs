using System.Collections.Generic;
using System.Linq;

namespace RockPapperAndScissors
{
    public abstract class Choose
    {
        public List<string> Entradas = new List<string> { "R", "P", "S" };

        public virtual string Entrada { get; }

        public abstract bool Ganhou(Choose choose);

        public bool VerificarChoose(string choose) => Entradas.Any(x => x == TratarChoose(choose));

        public string TratarChoose(string choose) => choose.Trim().ToUpper();
    }
}