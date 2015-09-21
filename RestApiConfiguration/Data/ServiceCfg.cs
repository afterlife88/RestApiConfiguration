namespace RestApiConfiguration.Data
{
    public class ServiceCfg
    {
        private Repository.Repository _repo;

        public Repository.Repository Repository
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository.Repository(new ConfigDbContext());
                return _repo;
            }
        }
    }
}