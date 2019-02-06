namespace MyBrainCategories.Persistence
{
    public class MongoSettings
    {
        private int port = 27017;
        public string ServerUrl { get; set; }


        public int? Port
        {
            get { return port; }
            set
            {
                if (value.HasValue)
                {
                    port = value.Value;
                }
            }
        }

        public string Protocol { get; set; } = "mongodb";

        public string Database { get; set; }

        public string ConnectionString()
        {
            return $"{Protocol}://{ServerUrl}:{Port}";
        }
        public override string ToString()
        {
            return this.ConnectionString();
        }
    }
}
