using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SystemConfig
{
	public class VersionSistema: ConfigurationElement
	{
		#region Constructors
        static VersionSistema()
		{
            s_propNumero = new ConfigurationProperty(
				"numero",
                typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
				);
            
			s_properties = new ConfigurationPropertyCollection();
            s_properties.Add(s_propNumero);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propNumero;
		#endregion

		#region Properties
        public string Numero
        {
            get { return (string)base[s_propNumero]; }
            set { base[s_propNumero] = value; }
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
