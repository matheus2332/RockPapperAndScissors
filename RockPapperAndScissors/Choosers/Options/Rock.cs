namespace RockPapperAndScissors
{
    public class Rock : Choose
    {
        public override string Entrada => "R";

        public override bool Ganhou(Choose choose) => choose is Rock || choose is Scissors;

        public Choose Converter(string choose)
        {
            if (choose == Entrada) return this;
            return new Scissors().Converter(choose);
        }
    }
}