using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SystemConfig
{
	public class SystemSection: ConfigurationSection
	{
		#region Constructors
		static SystemSection()
		{
            s_propRecoveryPasswordLength = new ConfigurationProperty(
                "recoveryPasswordLength",
				typeof(int),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

            s_propLogin = new ConfigurationProperty(
                "login",
                typeof(Login),
                null,
                ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection
                );

            s_propRevisionCaja = new ConfigurationProperty(
                "revisioncaja",
                typeof(RevisionCaja),
                null,
                ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection
                );

            s_propVersionSistema = new ConfigurationProperty(
                "versionSistema",
                typeof(VersionSistema),
                null,
                ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsDefaultCollection
                );

			s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propRecoveryPasswordLength);
            s_properties.Add(s_propLogin);
            s_properties.Add(s_propRevisionCaja);
            s_properties.Add(s_propVersionSistema);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propRecoveryPasswordLength;
        private static ConfigurationProperty s_propLogin;
        private static ConfigurationProperty s_propRevisionCaja;
        private static ConfigurationProperty s_propVersionSistema;
		#endregion

		#region Properties
        public int RecoveryPasswordLength
		{
            get { return (int)base[s_propRecoveryPasswordLength]; }
            set { base[s_propRecoveryPasswordLength] = value; }
		}

        public Login Login
        {
            get { return (Login)base[s_propLogin]; }
            set { base[s_propLogin] = value; }
        }
        public RevisionCaja RevisionCaja
        {
            get { return (RevisionCaja)base[s_propRevisionCaja]; }
            set { base[s_propRevisionCaja] = value; }
        }
        public VersionSistema VersionSistema
        {
            get { return (VersionSistema)base[s_propVersionSistema]; }
            set { base[s_propVersionSistema] = value; }
        }
        
		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return s_properties;
			}
		}
		#endregion
	}
}