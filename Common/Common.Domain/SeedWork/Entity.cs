namespace Common.Domain.SeedWork
{
    public abstract class Entity<T>
    {
        T _id;
        public virtual T Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        bool _isDeleted;
        public virtual bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            protected set
            {
                _isDeleted = value;
            }
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
