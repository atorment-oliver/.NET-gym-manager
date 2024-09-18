using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
	public class Param: ConfigurationElement
	{
		#region Constructors
        static Param()
		{
			s_propName = new ConfigurationProperty(
				"name",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

            s_propValue = new ConfigurationProperty(
				"value",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

			s_properties = new ConfigurationPropertyCollection();

			s_properties.Add(s_propName);
            s_properties.Add(s_propValue);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
		private static ConfigurationProperty s_propName;
		private static ConfigurationProperty s_propValue;
		#endregion

		#region Properties
		public string Name
		{
			get { return (string)base[s_propName]; }
			set { base[s_propName] = value; }
		}

		public string Value
		{
            get { return (string)base[s_propValue]; }
            set { base[s_propValue] = value; }
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
