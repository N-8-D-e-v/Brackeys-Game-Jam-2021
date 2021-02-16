namespace com.N8Dev.Brackeys.Movement
{
    public interface IFreezable
    {
        public void Freeze(float _seconds);

        public bool IsFrozen();
    }
}