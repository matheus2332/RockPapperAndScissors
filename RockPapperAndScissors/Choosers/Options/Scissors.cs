namespace RockPapperAndScissors
{
    public class Scissors : Choose
    {
        public override string Entrada => "S";

        public override bool Ganhou(Choose choose) => choose is Scissors || choose is Paper;

        public Choose Converter(string choose)
        {
            if (choose == Entrada) return this;
            return new Paper().Converter(choose);
        }
    }
}