namespace TheMonsterFromTheWell.Interface
{
    public interface IMovable
    {
        public void Move(float direction);
        public bool LookAt(float direction);
        public void SetAnimation();
    }
}