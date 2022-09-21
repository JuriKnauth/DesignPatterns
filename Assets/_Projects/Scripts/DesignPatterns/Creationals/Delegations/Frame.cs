namespace Delegations
{
    public class Frame : IArea
    {
        public IArea _iArea;

        public float GetArea()
        {
            return _iArea.GetArea();
        }
    }
}