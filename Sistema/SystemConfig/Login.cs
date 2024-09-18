using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SystemConfig
{
	public class Login: ConfigurationElement
	{
        public enum LoginTypes
        {
            Automatic, 
            Manual
        }
		#region Constructors
		static Login()
		{
			s_propType = new ConfigurationProperty(
				"type",
				typeof(LoginTypes),
				null,
				ConfigurationPropertyOptions.IsRequired
				);
            
			s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propType);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propType;
		#endregion

		#region Properties
		public LoginTypes Type
		{
            get { return (LoginTypes)base[s_propType]; }
            set { base[s_propType] = value; }
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
