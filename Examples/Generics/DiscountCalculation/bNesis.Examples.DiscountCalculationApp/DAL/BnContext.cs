using bNesis.Examples.DiscountCalculationApp.DAL.Models;
using MySql.Data.Entity;
using System.Data.Entity;

namespace bNesis.Examples.DiscountCalculationApp.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BnContext : DbContext
    {
        public DbSet<ApiResponse> ApiResponses { get; set; }

        public BnContext()
            : base("ExampleDb")
        {
            Initialize();
        }

        /// <summary>
        /// Initialize database
        /// </summary>
        private void Initialize()
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // please use next SQL to create apiresponses table:
            // CREATE TABLE `apiresponses` ( `id` int(11) NOT NULL AUTO_INCREMENT,
            // `provider` varchar(20) DEFAULT NULL,
            // `service` varchar(20) DEFAULT NULL,
            // `data` mediumtext,
            // `created` datetime DEFAULT NULL,
            // PRIMARY KEY(`id`)
            // ) ENGINE = InnoDB AUTO_INCREMENT = 9 DEFAULT CHARSET = utf8;

            // this disabled, cose we have ApiResponses_Insert exception, cose we don't have stored procedure at our DB
            //  modelBuilder.Entity<ApiResponse>().MapToStoredProcedures();
        }
    }
}