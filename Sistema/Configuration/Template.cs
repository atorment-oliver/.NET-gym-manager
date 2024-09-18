using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
	public class Template: ConfigurationElement
	{
		#region Constructors
		static Template()
		{
			s_propName = new ConfigurationProperty(
				"name",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

            s_propSubject = new ConfigurationProperty(
                "subject",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
                );

            s_propFile = new ConfigurationProperty(
				"file",
				typeof(string),
				null,
				ConfigurationPropertyOptions.IsRequired
				);

            s_propCopyTo = new ConfigurationProperty(
                "copyTo",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None
                );

			s_properties = new ConfigurationPropertyCollection();

			s_properties.Add(s_propName);
            s_properties.Add(s_propSubject);
            s_properties.Add(s_propFile);
            s_properties.Add(s_propCopyTo);
		}
		#endregion

		#region Fields
		private static ConfigurationPropertyCollection s_properties;
		private static ConfigurationProperty s_propName;
        private static ConfigurationProperty s_propSubject;
        private static ConfigurationProperty s_propFile;
        private static ConfigurationProperty s_propCopyTo;
		#endregion

		#region Properties
		public string Name
		{
			get { return (string)base[s_propName]; }
			set { base[s_propName] = value; }
		}

		public string Subject
		{
            get { return (string)base[s_propSubject]; }
            set { base[s_propSubject] = value; }
		}

        public string File
        {
            get { return (string)base[s_propFile]; }
            set { base[s_propFile] = value; }
        }

        public string CopyTo
        {
            get { return (string)base[s_propCopyTo]; }
            set { base[s_propCopyTo] = value; }
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
