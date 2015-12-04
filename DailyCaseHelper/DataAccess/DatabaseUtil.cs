using System.Configuration;
using System.Linq;

namespace com.smartwork.DataAccess
{
    /// <summary>
    /// This class contains various utilities for dealing with the SQL Server database.  Note that this will only work on Win32 Systems (not CE).
    /// </summary>
    public class DatabaseUtil
    {
        #region Constructors

        public DatabaseUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the database type.
        /// </summary>
        public static string DBType
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseType"];
            }
        }

        /// <summary>
        /// Gets the database server.
        /// </summary>
        public static string DBHost
        {
            get
            {
                return ConfigurationManager.AppSettings["DBHost"];
            }
        }

        /// <summary>
        /// Gets the database port.
        /// </summary>
        public static int DBPort
        {
            get
            {
                int port = 0;
                if (ConfigurationManager.AppSettings["DBPort"] != null 
                    && int.TryParse(ConfigurationManager.AppSettings["DBPort"], out port))
                {
                    return port;
                }
                
                //throw new InvalidCastException("Invalid Port Value");
                return 0; // Return one invalid port
            }
        }

        /// <summary>
        /// Gets the database user.
        /// </summary>
        public static string DBUser
        {
            get
            {
                return ConfigurationManager.AppSettings["DBUser"];
            }
        }

        /// <summary>
        /// Gets the database password.
        /// </summary>
        public static string DBPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["DBPassword"];
            }
        }

        /// <summary>
        /// Gets the database password.
        /// </summary>
        public static string DBInstance
        {
            get
            {
                return ConfigurationManager.AppSettings["DBInstance"];
            }
        }


        #endregion Properties

        #region Methods

        public static void Update(string type, string host, int port, string user, string password, string database)
        {
            /*** The following code is copied from http://wenku.baidu.com/link?url=ER2bDkhcnrh7y_ReiSnxJrr8KpAS6wvhht1X7KgHJtECd5PM31mS-0FXaooXyVzEEmOzKEr02a9Lk5HEzymAMt-2V4Cm3WhHA2JPDUFHgmy ***/
            // Get the configuration file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            UpdateAppSetting(config, "DBType", type);
            UpdateAppSetting(config, "DBHost", host);
            UpdateAppSetting(config, "DBPort", port.ToString());
            UpdateAppSetting(config, "DBUser", user);
            UpdateAppSetting(config, "DBPassword", password);
            UpdateAppSetting(config, "DBInstance", database);

            // Save the configuration file
            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of the changed section
            ConfigurationManager.RefreshSection("appsettings");
        }

        private static void UpdateAppSetting(Configuration config, string name, string value)
        {
            if (config.AppSettings.Settings.AllKeys.ToList<string>().Contains(name))
            {
                config.AppSettings.Settings.Remove(name);
            }

            config.AppSettings.Settings.Add(name, value);
        }

        #endregion Methods
    }
}