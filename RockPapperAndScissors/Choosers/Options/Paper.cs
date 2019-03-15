namespace RockPapperAndScissors
{
    public class Paper : Choose
    {
        public override string Entrada => "P";

        public override bool Ganhou(Choose choose) => choose is Paper || choose is Rock;

        public Choose Converter(string choose)
        {
            if (choose == Entrada) return this;
            return new Rock().Converter(choose);
        }
    }
}