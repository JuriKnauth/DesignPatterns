namespace Delegations
{
    public sealed class Square : Shape
    {
        public float _sideLength;

        public override float GetArea()
        {
            return _sideLength * 2f;
        }
    }
}