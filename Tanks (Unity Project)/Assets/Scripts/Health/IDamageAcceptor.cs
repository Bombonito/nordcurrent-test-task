namespace Health
{
    public interface IDamageAcceptor
    {
        void Process(IDamageDealer damageDealer);
    }
}